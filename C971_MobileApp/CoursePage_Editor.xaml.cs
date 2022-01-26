using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void OpenAssessmentsPage_Editor(Object sender, EventArgs e)
        {
            App.Current.MainPage = new AssessmentPage_Editor();
        }
    }
}