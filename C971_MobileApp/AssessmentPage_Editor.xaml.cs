using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentPage_Editor : ContentPage
    {
        public ICommand NavigateCommand { private set; get; }

        public AssessmentPage_Editor()
        {
            InitializeComponent();

            NavigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
               // How to add the courses to the list here?
              
                await Navigation.PushAsync(page);
            });

            BindingContext = this;
        }

      
    }
}