rd /S /Q .\Publishing\lib

call build.bat
if %errorlevel% neq 0 exit /b %errorlevel%

md .\Publishing\lib
md .\Publishing\lib\net45

copy .\Src\Metrics.Log4Net\bin\Release\metrics.log4net.dll .\Publishing\lib\net45\
copy .\Src\Metrics.Log4Net\bin\Release\metrics.log4net.xml .\Publishing\lib\net45\
copy .\Src\Metrics.Log4Net\bin\Release\metrics.log4net.pdb .\Publishing\lib\net45\

.\.nuget\NuGet.exe pack .\Publishing\Metrics.Log4Net.nuspec -OutputDirectory .\Publishing
if %errorlevel% neq 0 exit /b %errorlevel%