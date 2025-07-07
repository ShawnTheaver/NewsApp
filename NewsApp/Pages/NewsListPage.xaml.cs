using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages
{
    public partial class NewsListPage : ContentPage
    {
        public string PageTitle { get; set; }

        public NewsListPage(string category)
        {
            InitializeComponent();
            PageTitle = category;
            Title = category;
            LoadNews(category);
        }

        private async void LoadNews(string category)
        {
            try
            {
                var apiService = new ApiService();
                var result = await apiService.GetNews(category.ToLower());
                CvArticles.ItemsSource = result.Articles;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load news: {ex.Message}", "OK");
            }
        }

        private async void CvArticles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedArticle = e.CurrentSelection.FirstOrDefault() as Article;
            if (selectedArticle != null)
            {
                await Navigation.PushAsync(new NewsDetailPage(selectedArticle));
            }

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
