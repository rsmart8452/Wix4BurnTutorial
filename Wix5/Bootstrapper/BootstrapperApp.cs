using Bootstrapper.Models;
using Bootstrapper.Models.Util;
using System;
using WixToolset.BootstrapperApplicationApi;

namespace Bootstrapper;

internal class BootstrapperApp : BootstrapperApplication
{
  private Model _model;

  public int ExitCode { get; private set; }

  protected override void OnCreate(CreateEventArgs args)
  {
    try
    {
      // Let base populate args before accessing its members
      base.OnCreate(args);

      var factory = new WpfBaFactory();
      _model = factory.Create(args.Engine, args.Command);
      factory.SubscribeCancelEvents(this, _model);
      factory.SubscribeProgressEvents(this, _model);
      factory.SubscribeDetectEvents(this, _model);
      factory.SubscribePlanEvents(this, _model);
      factory.SubscribeApplyEvents(this, _model);
    }
    catch (Exception ex)
    {
      var hResult = ex.HResult;
      ExitCode = ErrorHelper.HResultToWin32(hResult);
      engine.Log(LogLevel.Error, ex.ToString());
      throw;
    }
  }

  protected override void Run()
  {
    var hResult = 0;
    try
    {
      _model.Log.Write("Running bootstrapper application.");

      try
      {
        _model.UiFacade.Initialize(_model);
        _model.Engine.Detect();
        _model.UiFacade.RunMessageLoop();
      }
      finally
      {
        hResult = _model.State.PhaseResult;
      }
    }
    catch (Exception ex)
    {
      hResult = ex.HResult;
      _model.Log.Write(ex);
    }
    finally
    {
      // If the HRESULT is an error, convert it to a win32 error code
      ExitCode = ErrorHelper.HResultToWin32(hResult);
      _model.SaveEmbeddedLog(ExitCode);
      _model.Engine.Quit(ExitCode);
    }
  }
}