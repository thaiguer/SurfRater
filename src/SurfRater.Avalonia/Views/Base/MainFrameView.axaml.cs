using Avalonia.Controls;
using SurfRater.Avalonia.ViewModels.Base;

namespace SurfRater.Avalonia.Views.Base;

public partial class MainFrameView : UserControl
{
    public MainFrameView()
    {
        InitializeComponent();
        DataContext = new MainFrameViewModel();
    }
}