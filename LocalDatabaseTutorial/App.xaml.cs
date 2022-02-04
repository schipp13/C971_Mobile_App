using System;
using System.IO;
using Xamarin.Forms;
using c971_MobileApplication.Models;
using c971_MobileApplication.Views;

namespace c971_MobileApplication
{
    public partial class App : Application
    {
        static Database database;

        // Create the database connection as a singleton.
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Courses.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            /*MainPage = new NavigationPage(new c971_MobileApplication.MainPage());*/
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
