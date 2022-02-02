using Xamarin.Forms;
using LocalDatabaseTutorial.Views;

namespace LocalDatabaseTutorial
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CoursePage), typeof(CoursePage));
            Routing.RegisterRoute(nameof(CourseEntryPage), typeof(CourseEntryPage));
            Routing.RegisterRoute(nameof(AssessmentPageEditor), typeof(AssessmentPageEditor));
        }
    }
}