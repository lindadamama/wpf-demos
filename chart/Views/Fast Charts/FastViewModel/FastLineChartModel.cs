#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace syncfusion.chartdemos.wpf
{
    public class FastLineChartModel
    {
        public DateTime Date { get; set; }

        public double Value { get; set; }

        public FastLineChartModel(DateTime date, double value)
        {
            Date = date;
            Value = value;
        } 
    }
}
