rmdir selfcontained
mkdir selfcontained
"C:\Program Files (x86)\Microsoft\ILMerge\ILMerge.exe" /lib:"C:\Windows\Microsoft.NET\Framework\v4.0.30319" /out:selfcontained\ConsoleApp1.exe /target:winexe ConsoleApp1.exe Autofac.dll Microsoft.Threading.Tasks.dll Microsoft.Threading.Tasks.Extensions.Desktop.dll Microsoft.Threading.Tasks.Extensions.dll Newtonsoft.Json.dll System.Net.Http.Extensions.dll System.Net.Http.Primitives.dll Tweetinvi.dll
"C:\Program Files (x86)\Microsoft\ILMerge\ILMerge.exe" /lib:"C:\Windows\Microsoft.NET\Framework\v4.0.30319" /out:selfcontained\ConsoleApp1.exe /target:exe ConsoleApp1.exe Autofac.dll Microsoft.Threading.Tasks.dll Microsoft.Threading.Tasks.Extensions.Desktop.dll Microsoft.Threading.Tasks.Extensions.dll Newtonsoft.Json.dll System.Net.Http.Extensions.dll System.Net.Http.Primitives.dll Tweetinvi.dll