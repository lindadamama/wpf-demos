#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Controls.Gantt;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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

namespace syncfusion.ganttdemos.wpf
{

    public class CustomMetroStyleModel : NotificationObject
    {
        public CustomMetroStyleModel()
        {
            ChildTask = new ObservableCollection<CustomMetroStyleModel>();
            Predecessor = new ObservableCollection<Predecessor>();
            Resource = new ObservableCollection<Resource>();
        }

        private int id;
        private string name;
        private DateTime stDate;
        private DateTime endDate;
        private TimeSpan duration;
        private ObservableCollection<Resource> resource;
        private double complete;
        private ObservableCollection<CustomMetroStyleModel> childTask;
        private ObservableCollection<Predecessor> predecessor;

        /// <summary>
        /// Gets or sets the complete.
        /// </summary>
        /// <value>
        /// The complete.
        /// </value>
        public double Complete
        {
            get
            {
                return Math.Round(complete, 2);
            }
            set
            {
                if (value <= 100)
                {
                    if (childTask != null && childTask.Count >= 1)
                    {
                        var sum = 0d;
                        complete = ((childTask.Aggregate(sum, (cur, task) => cur + task.Complete)) / childTask.Count);
                    }
                    else
                        complete = value;
                    RaisePropertyChanged("Complete");
                }
            }
        }

        /// <summary>
        /// Gets or sets the resource.
        /// </summary>
        /// <value>
        /// The resource.
        /// </value>
        public ObservableCollection<Resource> Resource
        {
            get
            {
                return resource;
            }
            set
            {
                resource = value;
                RaisePropertyChanged("Resource");
            }
        }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public TimeSpan Duration
        {
            get
            {
                if (childTask != null && childTask.Count >= 1)
                {
                    var sum = new TimeSpan(0, 0, 0, 0);
                    sum = childTask.Aggregate(sum, (current, task) => current + task.Duration);
                    return sum;
                }

                /// Calculating the difference between Start And End Date Accurately
                duration = endDate.Subtract(stDate);
                return duration;
            }

            set
            {
                if (childTask != null && childTask.Count >= 1)
                {
                    var sum = new TimeSpan(0, 0, 0, 0);
                    sum = childTask.Aggregate(sum, (current, task) => current + task.Duration);
                    duration = sum;
                    return;
                }

                duration = value;

                /// When calculating finish date from duration  we need to remove the extra date that we have added in duration to make the it fill the finish date too.
                /// End date is beeing calcuated here to make the change in endate based on duration. Duration is interlinked with start and end date, so will affect both based on the change.
                EndDate = stDate.AddDays(Double.Parse((duration.TotalDays).ToString()));

            }
        }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                if (childTask != null && childTask.Count >= 1)
                {
                    /// If this task is a parent task, then it should have the maximum end time. Hence comparing the date with maximum date of its children.

                    if (value >= childTask.Max(s => s.EndDate) && endDate != value)
                        endDate = value;
                }
                else
                    endDate = value;
                RaisePropertyChanged("EndDate");
                /// Duration changed is invoked to notify the chagne in duration based on the new end date.
                RaisePropertyChanged("Duration");
            }
        }

        /// <summary>
        /// Gets or sets the st date.
        /// </summary>
        /// <value>
        /// The st date.
        /// </value>
        public DateTime StDate
        {
            get
            {
                return stDate;
            }
            set
            {
                /// If this task is a parent task, then it should have the minimum start time. Hence comparing the date with minimum date of its children.

                if (childTask != null && childTask.Count >= 1)
                {
                    if (value <= childTask.Min(s => s.stDate) && stDate != value)
                        stDate = value;
                }
                else
                    stDate = value;
                RaisePropertyChanged("StDate");

                /// Duration chagned is invoked to notify the chagne in duration based on the new start date.
                RaisePropertyChanged("Duration");
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }

        /// <summary>
        /// Gets or sets the predecessor.
        /// </summary>
        /// <value>
        /// The predecessor.
        /// </value>
        public ObservableCollection<Predecessor> Predecessor
        {
            get
            {
                return predecessor;
            }
            set
            {
                predecessor = value;
                RaisePropertyChanged("Predecessor");
            }
        }

        #region ChildTask Collection

        public ObservableCollection<CustomMetroStyleModel> ChildTask
        {
            get
            {
                if (childTask == null)
                {
                    childTask = new ObservableCollection<CustomMetroStyleModel>();
                    /// Collection changed of child tasks are hooked to listen and refresh the parent node based on the changes made in Child.
                    childTask.CollectionChanged += ChildNodesCollectionChanged;
                }
                return childTask;
            }
            set
            {
                childTask = value;
                ///Collection changed of child tasks are hooked to listen and refresh the parent node based on the changes made in Child.

                childTask.CollectionChanged += ChildNodesCollectionChanged;

                if (value.Count > 0)
                {
                    childTask.ToList().ForEach(n =>
                    {
                        /// To listen the changes occuring in child task.
                        n.PropertyChanged += ChildNodePropertyChanged;

                    });
                    UpdateData();
                }
                RaisePropertyChanged("ChildTask");
            }
        }

        /// <summary>
        /// The following does the calculations to update the Parent Task, when child collection property changes.
        /// </summary>
        /// <param name="sender">The source</param>
        /// <param name="e">Property changed event args</param>
        void ChildNodePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != null)
                if (e.PropertyName == "StDate" || e.PropertyName == "EndDate" || e.PropertyName == "Complete")
                {
                    UpdateData();
                }
        }

        /// <summary>
        /// Updates the data.
        /// </summary>
        private void UpdateData()
        {
            /// Updating the start and end date based on the chagne occur in the date of child task
            if (childTask == null || childTask.Count == 0)
            {
                return;
            }

            StDate = childTask.Select(c => c.StDate).Min();
            EndDate = childTask.Select(c => c.EndDate).Max();
            Complete = (childTask.Aggregate(0d, (cur, task) => cur + task.Complete)) / childTask.Count;
        }

        /// <summary>
        /// Childs the nodes collection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Collections.Specialized.NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        public void ChildNodesCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (CustomMetroStyleModel node in e.NewItems)
                {
                    node.PropertyChanged += ChildNodePropertyChanged;
                }
            }
            else
            {
                foreach (CustomMetroStyleModel node in e.OldItems)
                    node.PropertyChanged -= ChildNodePropertyChanged;
            }
            UpdateData();
        }

        #endregion

        internal void Dispose()
        {
            ChildTask.CollectionChanged -= ChildNodesCollectionChanged;

            if (ChildTask.Count > 0)
            {
                ChildTask.ToList().ForEach(n =>
                {
                    n.PropertyChanged -= ChildNodePropertyChanged;
                });
            }
        }
    }

    /// <summary>
    /// Class contains Metro Style Names and Corrsponding Brushes
    /// </summary>
    public class MetroStyleColor
    {
        public Brush Brush { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetroStyleColor"/> class.
        /// </summary>
        public MetroStyleColor()
        {
        }
    }
}
