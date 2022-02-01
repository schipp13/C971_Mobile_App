using System;
using System.Collections.Generic;
using c971_MobileApplication.Views;
using System.Text;
using Xamarin.Forms;

namespace c971_MobileApplication
{
    public partial class AppShell : Shell
    {

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CoursePage), typeof(CoursePage));
        }
    }
}
