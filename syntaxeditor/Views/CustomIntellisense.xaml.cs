#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Interaction logic for CustomIntellisense.xaml
    /// </summary>
    public partial class CustomIntellisense:DemoControl
    {
        public CustomIntellisense()
        {
            InitializeComponent();
        }

        public CustomIntellisense(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            if (this.editText != null)
            {
                this.editText = null;
            }

            if (this.Mainmenu != null)
                this.Mainmenu = null;

            if (this.expander != null)
                this.expander = null;

            if (this.Toolbar != null)
                this.Toolbar = null;

            if (this.DataContext != null)
                this.DataContext = null;

            base.Dispose(disposing);
        }
    }
}
