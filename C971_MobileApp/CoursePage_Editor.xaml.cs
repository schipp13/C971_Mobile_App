using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursePage_Editor : ContentPage
    {
        public CoursePage_Editor()
        {
            InitializeComponent();
        }

        private async void OpenAssessmentsPage_Editor(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssessmentPage_Editor());
        }


    }
}