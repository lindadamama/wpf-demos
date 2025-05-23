#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for BoxAndWhiskerChartDemo.xaml
    /// </summary>
    public partial class BoxAndWhiskerChartDemo : DemoControl
    {
        public BoxAndWhiskerChartDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            boxWhiskerChart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.itl.nist.gov/div898/handbook/datasets/SPLETT2.DAT") { UseShellExecute = true });
        }

        private void Mode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = groupTo.SelectedIndex;
            if (index != -1)
            {
                switch (index)
                {
                    case 0:
                        {
                            boxSeries.BoxPlotMode = BoxPlotMode.Exclusive;
                            break;
                        }
                    case 1:
                        {
                            boxSeries.BoxPlotMode = BoxPlotMode.Inclusive;
                            break;
                        }
                    case 2:
                        {
                            boxSeries.BoxPlotMode = BoxPlotMode.Normal;
                            break;
                        }
                }
            }
        }
    }
}

