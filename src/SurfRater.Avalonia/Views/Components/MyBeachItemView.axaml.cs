using Avalonia.Controls;
using SurfRater.Avalonia.ViewModels.Components;

namespace SurfRater.Avalonia.Views.Components;

public partial class MyBeachItemView : UserControl
{
    public MyBeachItemView()
    {
        InitializeComponent();
        DataContext = new MyBeachItemViewModel();
    }
}