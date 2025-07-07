using NewsApp.Models;

namespace NewsApp.Pages
{
    public partial class NewsDetailPage : ContentPage
    {
        public NewsDetailPage(Article article)
        {
            InitializeComponent();

            // Populate UI with article data
            ArticleImage.Source = article.Image;
            ArticleTitle.Text = article.Title;
            ArticleContent.Text = article.Content;
        }
    }
}
