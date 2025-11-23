using Avalonia.Controls;
using SurfRater.Avalonia.ViewModels.Components;

namespace SurfRater.Avalonia.Views.Components;

public partial class BeachStatusView : UserControl
{
    public BeachStatusView()
    {
        InitializeComponent();
        DataContext = new BeachStatusViewModel(new Model.Beach());
    }
}