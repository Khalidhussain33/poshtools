﻿using System;
using System.ComponentModel;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Shell;

namespace PowerShellTools.Diagnostics
{
    internal class DiagnosticsDialogPage : DialogPage
    {
        public DiagnosticsDialogPage()
        {
            InitializeSettings();
        }

        private event EventHandler<bool> DiagnosticLoggingSettingChanged;

        [DisplayName(@"Enable Diagnostic Logging")]
        [Description("Diagnostic logging messages will be written to the output pane.")]
        public bool EnableDiagnosticLogging { get; set; }

        private void InitializeSettings()
        {
            EnableDiagnosticLogging = false;

            DiagnosticLoggingSettingChanged += PowerShellToolsPackage.Instance.DiagnosticLoggingSettingChanged;
        }

        protected override void OnApply(DialogPage.PageApplyEventArgs e)
        {
            base.OnApply(e);

            DiagnosticLoggingSettingChanged(this, EnableDiagnosticLogging);
        }
    }
}
