
using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsListPage : ContentPage
{
    public List<Article> ArticlesList;
    public NewsListPage(string categoryName)
	{
		InitializeComponent();
		Title = categoryName;
		GetNews(categoryName);
        ArticlesList = new List<Article>();
	}

    private async void GetNews(string catName)
    {
        var apiSrevice = new ApiService();
        var newsResult = await apiSrevice.GetNews(catName);

        foreach (var item in newsResult.Articles)
        {
            ArticlesList.Add(item);
        }

        CvNews.ItemsSource = ArticlesList;
    }

    private void CvNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Article;
        if (selectedItem == null) return;
        Navigation.PushAsync(new NewsDetailPage(selectedItem));
        ((CollectionView)sender).SelectedItem = null;
    }
}