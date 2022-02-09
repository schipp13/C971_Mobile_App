using System;
using c971_MobileApplication.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Plugin.LocalNotifications;

namespace c971_MobileApplication.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class TermPageEditor : ContentPage
    {        
        // Term_Id Value
        public int TermId;
       
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

         

            TermDateStart.Date = DateTime.Now;
            TermDateEnd.Date = DateTime.Now;
        }

        async void LoadCourse(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);

                // Retrieve the instructor and set it as the BindingContext of the page.
                Instructor instructor = await App.Database.GetInstructorAsync(id);
                BindingContext = instructor;                
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
        }

        async void OnSelectedItem(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the CoursePage, passing the ID as a query parameter.
                Course course = (Course)e.CurrentSelection.FirstOrDefault();               
                await Application.Current.MainPage.Navigation.PushAsync(new CoursePageEditor(course.Course_Id, true));
            }

        }

        // Creates a new term 
        async void OnAddTermClick(object sender, EventArgs e)
        {
            if (TermDateStart.Date > TermDateEnd.Date)
            {
                //Popup error
               await DisplayAlert("Alert", "The start date is after the end date. Please set the start date prior to the end date.", "OK");
            }
            else
            {
                var term = (Term)BindingContext;
                term.Term_Name = TermName.Text;
                term.Term_Start = TermDateStart.Date;
                term.Term_End = TermDateEnd.Date;

                await App.Database.SaveTermAsync(term);

                var CurrentPage = new TermPageEditor();
                Navigation.InsertPageBefore(CurrentPage, this);
                await Navigation.PopAsync();
            }
           
        }
        // Deletes the course
        async void OnDeleteCourseButtonClick(object sender, EventArgs e)
        {
            ImageButton button = sender as ImageButton;
            var course = button.BindingContext as Course;
            await App.Database.DeleteCourseAsync(course);
           
            var CurrentPage = new TermPageEditor();
            Navigation.InsertPageBefore(CurrentPage, this);
            await Navigation.PopAsync();
        }

        private async void AddCourseHandler(Object sender, EventArgs e)
        {
            // Navigate to CoursePageEditor passing in the current term id
            await Application.Current.MainPage.Navigation.PushAsync(new CoursePageEditor(TermId, false));
        }

       async void OnTermSelection(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the TermPageEditor, passing the ID as a query parameter.
                Term term = (Term)e.CurrentSelection.FirstOrDefault();
                TermName.Text = term.Term_Name;
                TermDateStart.Date = term.Term_Start;
                TermDateEnd.Date = term.Term_End;
                TermId = term.Term_Id;

                // Get all courses where Term_Id == TermId
                CourseItems.ItemsSource =  await App.Database.GetAssociatedCourseAsync(TermId);                
            }
        }

        async void OnTermDeleteClick(object sender, EventArgs e)
        {
            ImageButton button = sender as ImageButton;
            var term = button.BindingContext as Term;
            await App.Database.DeleteTermAsync(term.Term_Id);
           
            var CurrentPage = new TermPageEditor();
            Navigation.InsertPageBefore(CurrentPage, this);
            await Navigation.PopAsync();
        }

     
       
    }
}