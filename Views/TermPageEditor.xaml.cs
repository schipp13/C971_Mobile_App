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
         public ObservableCollection<Course> CourseList { get; set; }
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
                // TODO: Delete this because the courses will be selected when the Term is clicked.
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
            
            // TODO: Delete this line because when the term is clicked it will populate the coursee list.
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
    
    // TODO: Pass the selected term_id to associate the course to the selected term.
    // IF TermName field is empty then display an empty field error.
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
                TermId = term.Term_Id;
                
                
                // Get all courses where Term_Id == TermId
                // Try swapping TermId for just term.Term_Id
               // Method 1: 
               //This.CourseList =  await App.Database.GetAssociatedCourseAsync(TermId);
               // Method 2:
               // this.Customers = new ObservableCollection<Customer> (App.Database.GetAssociatedCourseAsync(TermId));
               // Additional Methods:
               // List/Collection = Query results of Courses where Term_Id == TermId
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
