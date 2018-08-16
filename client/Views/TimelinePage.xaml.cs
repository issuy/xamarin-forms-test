using System;
using System.Collections.Generic;

using Xamarin.Forms;

using client.ViewModels;

namespace client.Views
{
    public partial class TimelinePage : ContentPage
    {
        public TimelinePage()
        {
            InitializeComponent();
            BindingContext = new TimelineViewModel();
        }
    }
}
