; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "TrumpTwitter"
#define MyAppVersion "1.0"
#define MyAppPublisher "Jacob Ebey"
#define MyAppExeName "ConsoleApp1.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{1A91EA3A-F8BA-4EBC-9826-6D88ACD33B81}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={pf}\{#MyAppName}
DisableDirPage=yes
DisableProgramGroupPage=yes
OutputDir=publish
OutputBaseFilename={#MyAppName}
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "bin\Release\ConsoleApp1.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\Autofac.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\Autofac.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\ConsoleApp1.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\ConsoleApp1.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\Microsoft.Threading.Tasks.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\Microsoft.Threading.Tasks.Extensions.Desktop.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\Microsoft.Threading.Tasks.Extensions.Desktop.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\Microsoft.Threading.Tasks.Extensions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\Microsoft.Threading.Tasks.Extensions.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\Microsoft.Threading.Tasks.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\Newtonsoft.Json.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\search.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\System.Net.Http.Extensions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\System.Net.Http.Extensions.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\System.Net.Http.Primitives.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\System.Net.Http.Primitives.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\Tweetinvi.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\tweets.json"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
