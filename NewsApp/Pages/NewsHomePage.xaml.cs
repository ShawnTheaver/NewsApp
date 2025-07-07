using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages
{
    public partial class NewsHomePage : ContentPage
    {
        public List<Category> CategoryList { get; set; }
        public List<Article> ArticleList { get; set; }

        public NewsHomePage()
        {
            InitializeComponent();
            LoadCategories();
            LoadBreakingNews();
        }

        private void LoadCategories()
        {
            CategoryList = new List<Category>()
            {
                new Category() { Name = "World", ImageUrl = "world.png" },
                new Category() { Name = "Nation", ImageUrl = "nation.png" },
                new Category() { Name = "Business", ImageUrl = "business.png" },
                new Category() { Name = "Technology", ImageUrl = "technology.png" },
                new Category() { Name = "Entertainment", ImageUrl = "entertainment.png" },
                new Category() { Name = "Sports", ImageUrl = "sports.png" },
                new Category() { Name = "Science", ImageUrl = "science.png" },
                new Category() { Name = "Health", ImageUrl = "health.png" },
            };

            CvCategories.ItemsSource = CategoryList;
        }

        private async void LoadBreakingNews()
        {
            var apiService = new ApiService();
            var newsResult = await apiService.GetNews("sports"); // Default: sports
            ArticleList = new List<Article>();

            foreach (var item in newsResult.Articles)
            {
                ArticleList.Add(item);
            }

            CvNews.ItemsSource = ArticleList;
        }

        private async void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = e.CurrentSelection.FirstOrDefault() as Category;
            if (selectedCategory != null)
            {
                await Navigation.PushAsync(new NewsListPage(selectedCategory.Name));
            }

            // Reset selection so user can re-select same item
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
