using System;
using c971_MobileApplication.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace c971_MobileApplication.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class TermPageEditor : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadCourse(value);
            }
        }
        public TermPageEditor()
        {
            InitializeComponent();

            BindingContext = new Term();

            // This should set the minimumdate to be a month prior the current date.
            TermDateStart.MinimumDate = DateTime.Now;
            TermDateEnd.MinimumDate = DateTime.Now;
        }

        async void LoadCourse(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);

                // Retrieve the instructor and set it as the BindingContext of the page.
                Instructor instructor = await App.Database.GetInstructorAsync(id);
                BindingContext = instructor;

                // Retrieve the course and set it as the BindingContext of the page.
                Course course = await App.Database.GetCourseAsync(id);
                BindingContext = course;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load course.");
            }
        }

        protected override async void OnAppearing()
        {

            base.OnAppearing();


            // Load all the terms
            TermItems.ItemsSource = await App.Database.GetTermsAsync();

            // Retrieve all the courses from the database, and set them as the
            // data source for the CollectionView.

            CourseItems.ItemsSource = await App.Database.GetCoursesAsync();
        }
        async void OnSelectedItem(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the CoursePage, passing the ID as a query parameter.
                Course course = (Course)e.CurrentSelection.FirstOrDefault();

                await Shell.Current.GoToAsync($"{nameof(CoursePageEditor)}?{nameof(CoursePageEditor.ItemId)}={course.Course_Id.ToString()}");
            }
        }


        async void OnAddTermClick(object sender, EventArgs e)
        {
            var term = (Term)BindingContext;
            term.Term_Name = TermName.Text;
            term.Term_Start = TermDateStart.Date;
            term.Term_End = TermDateEnd.Date;

            await App.Database.SaveTermAsync(term);

            await Application.Current.MainPage.Navigation.PopAsync();

        }

        async void OnDeleteCourseButtonClick(object sender, EventArgs e)
        {
            ImageButton button = sender as ImageButton;
            var course = button.BindingContext as Course;
            await App.Database.DeleteCourseAsync(course);
            await Shell.Current.GoToAsync(nameof(TermPageEditor));
            await Application.Current.MainPage.Navigation.PopAsync();

        }

        private async void AddCourseHandler(Object sender, EventArgs e)
        {
            var term = (Term)BindingContext;

            /*await Navigation.PushAsync(new CoursePageEditor(term.Term_Name));*/
            await Navigation.PushAsync(new CoursePageEditor());
        }


        // TODO: Get this to load a term with assocaited courses information
        void OnTermSelection(object sender, SelectionChangedEventArgs e)
        {
            
            if (e.CurrentSelection != null)
            {
                // Navigate to the TermPageEditor, passing the ID as a query parameter.
                Term term = (Term)e.CurrentSelection.FirstOrDefault();
                TermName.Text = term.Term_Name;
                TermDateStart.Date = term.Term_Start;
                TermDateEnd.Date = term.Term_End;

            }
        }

         async void OnTermDeleteClick(object sender, EventArgs e)
        {

            ImageButton button = sender as ImageButton;
            var term = button.BindingContext as Term;

            await App.Database.DeleteTermAsync(term.Term_Id);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
