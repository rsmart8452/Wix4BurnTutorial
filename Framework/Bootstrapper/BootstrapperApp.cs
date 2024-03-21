using Bootstrapper.Models;
using Bootstrapper.Models.Util;
using System;
using WixToolset.Mba.Core;

namespace Bootstrapper
{
  internal class BootstrapperApp : BootstrapperApplication
  {
    private readonly Model _model;

    public BootstrapperApp(Model model)
      : base(model.Engine)
    {
      _model = model;
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
        var exitCode = ErrorHelper.HResultToWin32(hResult);
        _model.SaveEmbeddedLog(exitCode);
        _model.Engine.Quit(exitCode);
      }
    }
  }
}