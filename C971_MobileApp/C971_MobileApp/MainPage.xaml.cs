using System;
using Xamarin.Forms;

namespace C971_MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void NewCourseHandler(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursePage_Editor());
        }

    }
}
