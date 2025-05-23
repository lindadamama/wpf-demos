#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.PropertyGrid;
using System.Collections.Generic;
using System.ComponentModel;

namespace syncfusion.propertygriddemos.wpf
{
    public class DeliveryAgent
    {
        public int AgentID { get; set; }
        public string AgentName { get; set; }
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
