@ECHO OFF

IF "%~1"=="" (
	ECHO Please Specify version
) ELSE (
	IF NOT EXIST Releases MD Releases
	IF NOT EXIST Releases\%1 MD Releases\%1

	del .\bin\debug\*.pdb
	
	ECHO Merging ...

	ilmerge /log:merge.log /targetplatform:v4,C:\Windows\Microsoft.NET\Framework\v4.0.30319 /out:lsmcg.exe ^
		.\bin\debug\Locust.Service.Moon.CodeGenerator.exe ^
		.\bin\debug\INIFileParser.dll ^
		.\bin\debug\Locust.AppPath.dll ^
		.\bin\debug\Locust.Base.dll ^
		.\bin\debug\Locust.Collections.dll ^
		.\bin\debug\Locust.Configuration.dll ^
		.\bin\debug\Locust.ConsoleHelper.dll ^
		.\bin\debug\Locust.Conversion.dll ^
		.\bin\debug\Locust.Date.dll ^
		.\bin\debug\Locust.Expressions.dll ^
		.\bin\debug\Locust.Extensions.dll ^
		.\bin\debug\Locust.Logging.dll ^
		.\bin\debug\Locust.Reflection.dll ^
		.\bin\debug\Locust.Serialization.dll ^
		.\bin\debug\Locust.Service.dll ^
		.\bin\debug\Newtonsoft.Json.dll ^
		.\bin\debug\RazorEngine.dll ^
		.\bin\debug\System.Web.Razor.dll

	move /Y lsmcg.* Releases\%1
	IF NOT "%LOCUST_TOOLS%" == "" (
		copy /Y Releases\%1\lsmcg.exe %LOCUST_TOOLS%
		copy /Y Releases\%1\lsmcg.pdb %LOCUST_TOOLS%
	)
	ECHO Done!
)

