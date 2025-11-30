using CommunityToolkit.Mvvm.Input;
using SurfRater.Avalonia.ViewModels.Base;
using SurfRater.Avalonia.ViewModels.Components;
using System;
using System.Collections.ObjectModel;

namespace SurfRater.Avalonia.ViewModels;

public partial class MyBeachesViewModel : ViewModelBase
{
    public ObservableCollection<MyBeachItemViewModel> MyBeaches { get; set; } = [];

    [RelayCommand]
    private void AddBeach()
    {
        var guid = Guid.NewGuid();
        var viewModel = new MyBeachItemViewModel
        {
            Name = "aaaaaaaaaaaaa",
            Color = "Blue"
        };
        MyBeaches.Add(viewModel);
    }
}