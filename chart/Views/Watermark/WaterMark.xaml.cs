#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for WaterMark.xaml
    /// </summary>
    public partial class WaterMark : DemoControl
    {
        public WaterMark()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            WatermarkChart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }
    }
}
