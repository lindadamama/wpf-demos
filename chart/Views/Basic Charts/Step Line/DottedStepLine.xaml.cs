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

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for StepLineChartDemo.xaml
    /// </summary>
    public partial class DottedStepLine : DemoControl
    {
        public DottedStepLine()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            SteplineChart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://data.worldbank.org/indicator/EN.ATM.CO2E.KT?end=2011&locations=IN-DE-KZ&start=2006") { UseShellExecute = true });
        }

        private void NumericalAxis_LabelCreated(object sender, LabelCreatedEventArgs e)
        {
            double position = e.AxisLabel.Position;
            if (position > 0 && position <= 2)
            {
                string text = position.ToString("0.0");
                e.AxisLabel.LabelContent = $"{text}M";
            }
            else
            {
                e.AxisLabel.LabelContent = $"{position:0}M";
            }
        }
    } 
}
