#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class ZoomingViewModel : IDisposable
    {
        public ObservableCollection<ZoomingModel> ZoomData { get; set; }
        public ZoomingViewModel()
        {
            DateTime date = new DateTime(1950, 3, 01);
            Random r = new Random();
            ZoomData = new ObservableCollection<ZoomingModel>();
            for (int i = 0; i < 20; i++)
            {
                ZoomData.Add(new ZoomingModel(date, r.Next(45, 75)));
                date = date.AddDays(5);
            }
        }

        public void Dispose()
        {
            if(ZoomData != null)
                ZoomData.Clear();
        }
    }
}
