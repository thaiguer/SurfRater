using CommunityToolkit.Mvvm.Input;
using SurfRater.Avalonia.ViewModels.Base;
using SurfRater.Avalonia.ViewModels.Components;
using System.Collections.ObjectModel;

namespace SurfRater.Avalonia.ViewModels;

public partial class MyBeachesViewModel : ViewModelBase
{
    public ObservableCollection<MyBeachItemViewModel> MyBeaches { get; set; } = [];

    [RelayCommand]
    private void AddBeach()
    {
        var viewModel = new MyBeachItemViewModel
        {
            Name = "aaaaaaaaaaaaa",
            Color = "Blue"
        };
        MyBeaches.Add(viewModel);
    }

    public MyBeachesViewModel()
    {
        var viewModel0 = new MyBeachItemViewModel
        {
            Name = "Praia 0",
            Color = "Green"
        };
        MyBeaches.Add(viewModel0);

        var viewModel1 = new MyBeachItemViewModel
        {
            Name = "Praia 1",
            Color = "Red"
        };
        MyBeaches.Add(viewModel1);

        var viewModel2 = new MyBeachItemViewModel
        {
            Name = "Praia 2",
            Color = "Black"
        };
        MyBeaches.Add(viewModel2);

        var viewModel3 = new MyBeachItemViewModel
        {
            Name = "Praia 3",
            Color = "Yellow"
        };
        MyBeaches.Add(viewModel3);
    }
}