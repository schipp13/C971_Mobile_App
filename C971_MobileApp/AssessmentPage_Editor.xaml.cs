using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentPage_Editor : ContentPage
    {

        public AssessmentPage_Editor()
        {
            InitializeComponent();
        }

        async void SaveNewCourseHandler(Object sender, EventArgs e)
        {
            // Future Update: Add the course to the list here.

            await Navigation.PopToRootAsync();
        }
    }
}