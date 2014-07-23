.nuget\NuGet.exe restore Metrics.Log4Net.sln

set MSBUILD="C:\Program Files (x86)\MSBuild\12.0\Bin\MSBuild.exe"
set XUNIT=".\packages\xunit.runners.1.9.2\tools\xunit.console.clr4.exe"

%MSBUILD% Metrics.Log4Net.sln /p:Configuration="Debug"
if %errorlevel% neq 0 exit /b %errorlevel%

%MSBUILD% Metrics.Log4Net.sln /p:Configuration="Release"
if %errorlevel% neq 0 exit /b %errorlevel%

%XUNIT% .\Src\Metrics.Log4Net.Tests\bin\Debug\Metrics.Log4Net.Tests.dll
if %errorlevel% neq 0 exit /b %errorlevel%

%XUNIT% .\Src\Metrics.Log4Net.Tests\bin\Release\Metrics.Log4Net.Tests.dll
if %errorlevel% neq 0 exit /b %errorlevel%
