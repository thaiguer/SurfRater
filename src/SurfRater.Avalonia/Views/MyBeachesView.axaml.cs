using Avalonia.Controls;
using SurfRater.Avalonia.ViewModels;

namespace SurfRater.Avalonia;

public partial class MyBeachesView : UserControl
{
    public MyBeachesView()
    {
        InitializeComponent();
        DataContext = new MyBeachesViewModel();
    }
}