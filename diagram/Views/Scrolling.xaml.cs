#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for Scrolling.xaml
    /// </summary>
    public partial class Scrolling : DemoControl
    {
        public Scrolling()
        {
            InitializeComponent();
        }

        public Scrolling(string themename) : base(themename)
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
        }

        protected override void Dispose(bool disposing)
        {
            if (this.DataContext != null)
            {
                this.DataContext = null;
            }

            if (this.Diagram != null)
            {
                this.Diagram = null;
            }

            if (this.stencil != null)
            {
                this.stencil.SymbolGroups = null;
                (this.stencil.SymbolSource as Syncfusion.UI.Xaml.Diagram.SymbolCollection).Clear();
                this.stencil = null;
            }

            base.Dispose(disposing);
        }
    }
}
