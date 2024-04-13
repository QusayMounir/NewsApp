
using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsHomePage : ContentPage
{
	public List<Article> ArticlesList;
    public List<Category> CategoryList = new List<Category>()
    {
        new Category(){Name = "world", ImageUrl="world.png"},
        new Category(){Name = "nation", ImageUrl="nation.png"},
        new Category(){Name = "science", ImageUrl="science.png"},
        new Category(){Name = "business", ImageUrl="business.png"},
        new Category(){Name = "health", ImageUrl="health.png"},
        new Category(){Name = "entertainment", ImageUrl="entertainment.png"},
        new Category(){Name = "sports", ImageUrl="sports.png"},
        new Category(){Name = "technology", ImageUrl="technology.png"}
    };
    public NewsHomePage()
    {
        InitializeComponent();
        GetBreakingNews();
        ArticlesList = new List<Article>();
        CvCat.ItemsSource = CategoryList;
    }

    private async void GetBreakingNews()
    {
		var apiSrevice = new ApiService();
		var newsResult = await apiSrevice.GetNews("general");

		foreach (var item in newsResult.Articles)
		{
            ArticlesList.Add(item);
		}

        CvNews.ItemsSource = ArticlesList;
    }

    private void CvCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Category;
        if (selectedItem == null)return;
        Navigation.PushAsync(new NewsListPage(selectedItem.Name));
        ((CollectionView)sender).SelectedItem = null;
    }
}