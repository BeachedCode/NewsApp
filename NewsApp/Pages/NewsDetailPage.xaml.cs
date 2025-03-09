using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewsDetailPage : ContentPage
{
	public NewsDetailPage(Article item)
	{
		InitializeComponent();
		LblTitle.Text = item.Title;
		ArticleImg.Source = item.Image;
		LblContent.Text = item.Content;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}