using Avalonia.Controls;
using SurfRater.Avalonia.ViewModels;

namespace SurfRater.Avalonia.Views;

public partial class BeachStatusView : UserControl
{
    public BeachStatusView()
    {
        InitializeComponent();
        DataContext = new BeachStatusViewModel(new Model.Beach());
    }
}