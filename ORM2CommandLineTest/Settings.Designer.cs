﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Neumont.Tools.ORM.SDK.TestReportViewer {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Program Files\\Microsoft Visual Studio 8\\Common7\\Tools\\Bin\\WinDiff.exe")]
        public string diffProgram {
            get {
                return ((string)(this["diffProgram"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Embedded Report File {0}.{1}.Report.xml Not Found. ")]
        public string FailReportMessageText {
            get {
                return ((string)(this["FailReportMessageText"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("failReportMissingBaseline")]
        public string MissingReportBaseline {
            get {
                return ((string)(this["MissingReportBaseline"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\ORM2\\TestSuites")]
        public string projectPath {
            get {
                return ((string)(this["projectPath"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("failReportDiffgram")]
        public string ReportDiffgram {
            get {
                return ((string)(this["ReportDiffgram"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\ORM2\\TestSuites\\TestSample\\TestSample.sln")]
        public string solution {
            get {
                return ((string)(this["solution"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("VisualStudio.DTE.8.0")]
        public string testEnv {
            get {
                return ((string)(this["testEnv"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("!VisualStudio.DTE.8.0:")]
        public string testEnvMonikerDisplayNameStart {
            get {
                return ((string)(this["testEnvMonikerDisplayNameStart"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("pass")]
        public string TestPassed {
            get {
                return ((string)(this["TestPassed"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\ORM2\\ORM2CommandLineTest\\Settings.settings")]
        public string SettingLocation {
            get {
                return ((string)(this["SettingLocation"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(";NotA\\Real.dll|C:\\temp\\fake.sln;TestSample\\TestSample.dll|C:\\ORM2\\TestSuites\\Test" +
            "Sample\\TestSample.sln;TestSample\\Extra Text\\Default.dll|C:\\Orm2\\DefaultSolution." +
            "sln;TestSample\\TestSample.dll|C:\\ORM2\\ORM2CommandLineTest\\ORM2CommandLineTest.sl" +
            "n;")]
        public string DllMapping {
            get {
                return ((string)(this["DllMapping"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\ORM2\\ORM2CommandLineTest\\App.config")]
        public string AppConfigLocation {
            get {
                return ((string)(this["AppConfigLocation"]));
            }
        }
    }
}