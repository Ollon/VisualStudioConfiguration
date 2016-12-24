@if not defined EchoOn @echo off
@setlocal enabledelayedexpansion

set RepositoryRoot=%~dp0
set DevDivPackages=%RepositoryRoot%src\Setup\DevDivPackages

:ParseArguments
if /I "%1" == "/?" goto :Usage
if /I "%1" == "/clean" set RestoreClean=true&&shift&& goto :ParseArguments
if /I "%1" == "/fast" set RestoreFast=true&&shift&& goto :ParseArguments
goto :DoneParsing

:DoneParsing

REM Allow for alternate solutions to be passed as restore targets.
set Solution=%1
if "%Solution%" == "" set Solution=%RepositoryRoot%\Roslyn.sln

REM Load in the inforation for NuGet
call "%RepositoryRoot%build\scripts\LoadNuGetInfo.cmd" || goto :LoadNuGetInfoFailed

if "%RestoreClean%" == "true" (
    echo Clearing the NuGet caches
    call "%NugetExe%" locals all -clear || goto :CleanFailed
)

if "%RestoreFast%" == "" (
    echo Deleting project.lock.json files
    pushd "%RepositoryRoot%src"
    echo "Dummy lock file to avoid error when there is no project.lock.json file" > project.lock.json
    del /s /q project.lock.json > nul
    popd
)

echo Restoring packages: Toolsets
call "%NugetExe%" restore "%RepositoryRoot%build\ToolsetPackages\project.json" %NuGetAdditionalCommandLineArgs% || goto :RestoreFailed

echo Restoring packages: Toolsets (Dev14 VS SDK build tools)
call "%NugetExe%" restore "%RepositoryRoot%build\ToolsetPackages\dev14.project.json" %NuGetAdditionalCommandLineArgs% || goto :RestoreFailed

echo Restoring packages: Toolsets (Dev15 VS SDK RC build tools)
call "%NugetExe%" restore "%RepositoryRoot%build\ToolsetPackages\dev15rc.project.json" %NuGetAdditionalCommandLineArgs% || goto :RestoreFailed

echo Locating MSBuild for Solution restore
call "%RepositoryRoot%SetDevCommandPrompt.cmd" || goto :RestoreFailed

REM If we have an applocal copy of MSBuild, pass it to NuGet.  Otherwise, assume NuGet knows how to find it.
if exist "%DevenvDir%\..\..\MSBuild\15.0\Bin\MSBuild.exe" (
    set NuGetAdditionalCommandLineArgs=%NuGetAdditionalCommandLineArgs% -msbuildpath "%DevenvDir%\..\..\MSBuild\15.0\Bin"
)

echo Restoring packages: Templates
call "%NugetExe%" restore "%RepositoryRoot%Src\Templates\Templates.sln" %NuGetAdditionalCommandLineArgs% || goto :RestoreFailed

echo Restoring packages: Dependencies
call "%NugetExe%" restore "%RepositoryRoot%Build\Dependencies\Dependencies.sln" %NuGetAdditionalCommandLineArgs% || goto :RestoreFailed

echo Restoring packages: Roslyn (this may take some time)
call "%NugetExe%" restore "%Solution%" %NuGetAdditionalCommandLineArgs% || goto :RestoreFailed

echo Restoring packages: DevDiv tools
call "%NugetExe%" restore "%RepositoryRoot%src\Setup\DevDivInsertionFiles\DevDivInsertionFiles.sln" %NuGetAdditionalCommandLineArgs% || goto :RestoreFailed
call "%NugetExe%" restore "%DevDivPackages%\Roslyn\project.json" %NuGetAdditionalCommandLineArgs% || goto :RestoreFailed
call "%NugetExe%" restore "%DevDivPackages%\Debugger\project.json" %NuGetAdditionalCommandLineArgs% || goto :RestoreFailed

exit /b 0

:CleanFailed
echo Clean failed with ERRORLEVEL %ERRORLEVEL%
exit /b 1

:RestoreFailed
echo Restore failed with ERRORLEVEL %ERRORLEVEL%
exit /b 1

:LoadNuGetInfoFailed
echo Error loading NuGet.exe information %ERRORLEVEL%
exit /b 1

:Usage
@echo Usage: Restore.cmd /clean [Solution File]
exit /b 1
