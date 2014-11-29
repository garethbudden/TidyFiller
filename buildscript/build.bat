"C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe" ".\tidy-filler-build-requirements.proj"
"C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe" ".\tidy-filler.proj" /target:UpdateVersion;build;test;package
pause