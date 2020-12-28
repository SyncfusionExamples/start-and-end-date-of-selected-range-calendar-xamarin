using Syncfusion.SfCalendar.XForms;
using System;
using Xamarin.Forms;

namespace CalendarXamarin
{
    public class CalendarBehavior : Behavior<ContentPage>
    {
        SfCalendar calendar;
        CalendarViewmodel viewModel;
        private DateTime startDate;
        private DateTime endDate;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.calendar = bindable.Content.FindByName<SfCalendar>("calendar");
            this.viewModel = bindable.Content.FindByName<CalendarViewmodel>("viewModel");

            this.WireEvents();
        }
        private void WireEvents()
        {
            this.calendar.SelectionChanged += Calendar_SelectionChanged;
        }

        private void Calendar_SelectionChanged(object sender, Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs e)
        {
            if (this.calendar.SelectedRange != null)
            {
                startDate = viewModel.SelectedRange.StartDate;
                endDate = viewModel.SelectedRange.EndDate;
                App.Current.MainPage.DisplayAlert("StartDate" + " " + ":"+" "+ startDate.ToString(), "EndDate" + " " + ":"+"  " + endDate.ToString(),"OK");
            }
        }
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            this.UnWireEvents();
        }
        private void UnWireEvents()
        {
            this.calendar.SelectionChanged += Calendar_SelectionChanged;
        }
    }
}

