using CommunityToolkit.Mvvm.Input;
using SurfRater.Avalonia.Model;
using SurfRater.Avalonia.ViewModels.Base;
using System.Collections.ObjectModel;

namespace SurfRater.Avalonia.ViewModels;

public partial class MyBeachesViewModel : ViewModelBase
{
    public ObservableCollection<Beach> MyBeaches { get; set; } = [];

    [RelayCommand]
    private void AddBeach()
    {

    }
}