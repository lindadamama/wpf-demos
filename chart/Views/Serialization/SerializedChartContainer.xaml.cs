#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Controls;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for SerializedChartContainer.xaml
    /// </summary>
    public partial class SerializedChartContainer : UserControl , IDisposable
    {
        public SerializedChartContainer()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            chart.Dispose();
        }
    }
}
