#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for FastColumnChartDemo.xaml
    /// </summary>
    public partial class FastColumnChartDemo : DemoControl
    {
        public FastColumnChartDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            FastColumn.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }

        private void DateTimeAxis_LabelCreated(object sender, LabelCreatedEventArgs e)
        {
            DateTimeAxisLabel dateTimeLabel = e.AxisLabel as DateTimeAxisLabel;
            bool isTransition = dateTimeLabel.IsTransition;
            switch (dateTimeLabel.IntervalType)
            {
                case DateTimeIntervalType.Days:
                    {
                        if (isTransition)
                            e.AxisLabel.LabelContent = dateTimeLabel.Position.FromOADate().ToString("MMM-dd");
                        else
                            e.AxisLabel.LabelContent = dateTimeLabel.Position.FromOADate().ToString("dd");
                    }
                    break;

                case DateTimeIntervalType.Hours:
                    {
                        if (isTransition)
                            e.AxisLabel.LabelContent =
                            dateTimeLabel.Position.FromOADate().ToString("dd.HH:mm");

                        else
                            e.AxisLabel.LabelContent =
                            dateTimeLabel.Position.FromOADate().ToString("HH");
                    }
                    break;
            }
        }
    }   
}
