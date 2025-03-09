using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsListPage : ContentPage
{
    public List<Article> ArticleList;
    private string selectedGenre;
    public NewsListPage(Category item)
	{
		InitializeComponent();
        selectedGenre = item.Name;
        GetBreakingNews();
        ArticleList = new List<Article>();
    }
    private async Task GetBreakingNews()
    {
        var apiService = new ApiService();
        var newsResult = await apiService.GetNews(selectedGenre);
        foreach (var item in newsResult.Articles)
        {
            ArticleList.Add(item);
        }
        CvNews.ItemsSource = ArticleList;
    }
    private void CvNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedArticle = e.CurrentSelection.FirstOrDefault() as Article;
        if (selectedArticle == null) return;
        Navigation.PushAsync(new NewsDetailPage(selectedArticle));
        ((CollectionView)sender).SelectedItem = null;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();
    }
}