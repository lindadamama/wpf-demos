#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
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
using Syncfusion.UI.Xaml.Grid.Helpers;
using System.ComponentModel;
using System.Collections.ObjectModel;
using syncfusion.demoscommon.wpf;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Interaction logic for ScrollPerformanceDemo.xaml
    /// </summary>
    public partial class ScrollPerformanceDemo : DemoControl
    {
        public ScrollPerformanceDemo(string themename) : base(themename)
        {
            InitializeComponent();            
        }

        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.datagrid != null)
            {
                this.datagrid.Dispose();
                this.datagrid = null;
            }

            if (this.DataContext != null)
            {
                var dataContext = this.DataContext as StockDetailsViewModel;
                dataContext.Dispose();
                this.DataContext = null;
            }

            base.Dispose(disposing);
        }
    }
}
