ECHO OFF

IF "%~1"=="" (
	ECHO Please Specify version
) ELSE (
	IF NOT EXIST Releases MD Releases
	IF NOT EXIST Releases\%1 MD Releases\%1

	ECHO Merging ...

	ilmerge /log:merge.log /out:lsmcg.exe ^
		./bin/release/Locust.Service.Moon.CodeGenerator.exe ^
		./bin/release/INIFileParser.dll ^
		./bin/release/Locust.AppPath.dll ^
		./bin/release/Locust.Base.dll ^
		./bin/release/Locust.Collections.dll ^
		./bin/release/Locust.Configuration.dll ^
		./bin/release/Locust.ConsoleHelper.dll ^
		./bin/release/Locust.Conversion.dll ^
		./bin/release/Locust.Expressions.dll ^
		./bin/release/Locust.Extensions.dll ^
		./bin/release/Locust.Logging.dll ^
		./bin/release/Locust.Reflection.dll ^
		./bin/release/Locust.Serialization.dll ^
		./bin/release/Locust.Service.dll ^
		./bin/release/Newtonsoft.Json.dll ^
		./bin/release/RazorEngine.dll ^
		./bin/release/System.Web.Razor.dll

	move /Y lsmcg.* Releases\%1

	ECHO Done!
)

