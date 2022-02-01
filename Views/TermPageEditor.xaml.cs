using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace c971_MobileApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermPageEditor : ContentPage
    {
        public TermPageEditor()
        {
            InitializeComponent();
        }

        private async void AddCourseHandler(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursePageEditor());
        }
    }
}