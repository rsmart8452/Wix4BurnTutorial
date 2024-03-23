# Custom Bootstrapper for WiX v4 Burn Tutorial

Welcome to this tutorial on using Burn in WiX 4 to build a software installation bundle with your own custom .NET bootstrapper application. It includes two working solutions, one targeting .NET 4.6.2 and another for .NET 8.0.

## Audience

This is for intermediate to advanced .NET and WiX users. You should also have a basic understanding of the workings of Windows Installer and the databases (MSI files) it uses to deploy software.

## How to Use the Tutorial

[The wiki](https://github.com/rsmart8452/Wix4BurnTutorial/wiki) covers concepts and provides a code walkthrough.

This repo includes both .NET Framework and .NET Core solutions. Each of the important source files have accompanying pages in the wiki which go into much more detail than can be reasonably be provided in code comments.

For an organized walkthrough, the wiki provides navigation links at the bottom of each page. Starting with the [Home](https://github.com/rsmart8452/Wix4BurnTutorial/wiki) page, following these links will guide the reader through building their own bundle.

## How to Build the Sample Solutions

There is no build script. Open either _Framework\Framework.sln_ or _Core\Core.sln_ in Visual Studio and build.

A [Windows Sandbox configuration](https://github.com/rsmart8452/Wix4BurnTutorial/wiki/Windows-Sandbox-Configuration) is provided so the installers can be run without affecting your development environment.
