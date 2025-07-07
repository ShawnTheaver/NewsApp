using NewsApp.Pages;

namespace NewsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Enables stack-based navigation for the entire app
            MainPage = new NavigationPage(new NewsHomePage());
        }
    }
}
