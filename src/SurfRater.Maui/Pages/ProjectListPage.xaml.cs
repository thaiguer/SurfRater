using SurfRater.Maui.Notifications;

namespace SurfRater.Maui.Pages;

public partial class ProjectListPage : ContentPage
{
    public ProjectListPage(ProjectListPageModel model)
    {
        BindingContext = model;
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var sampleNotifier = new SampleNotifier();
        sampleNotifier.ShowNoticationAsync();
        sampleNotifier.ShowAsync();
    }
}