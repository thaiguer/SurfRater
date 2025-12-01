using CommunityToolkit.Mvvm.Input;
using SurfRater.Avalonia.ViewModels.Base;
using SurfRater.Avalonia.ViewModels.Components;
using SurfRater.Core.Model.Entities;
using System.Collections.ObjectModel;

namespace SurfRater.Avalonia.ViewModels;

public partial class MyBeachesViewModel : ViewModelBase
{
    public ObservableCollection<MyBeachItemViewModel> MyBeaches { get; set; } = [];

    [RelayCommand]
    private void AddBeach()
    {
        var beach = new Beach();
        beach.Name = "aaaaaaaaaaaaa";
        beach.SurfCondition = Core.Enumerators.SurfCondition.Poor;

        var viewModel = new MyBeachItemViewModel(beach);
        MyBeaches.Add(viewModel);
    }

    public MyBeachesViewModel()
    {
        var beach0 = new Beach();
        beach0.Name = "Praia 0";
        beach0.SurfCondition = Core.Enumerators.SurfCondition.Bad;
        var viewModel0 = new MyBeachItemViewModel(beach0);
        MyBeaches.Add(viewModel0);

        var beach1 = new Beach();
        beach1.Name = "Praia 1";
        beach1.SurfCondition = Core.Enumerators.SurfCondition.Good;
        var viewModel1 = new MyBeachItemViewModel(beach1);
        MyBeaches.Add(viewModel1);

        var beach2 = new Beach();
        beach2.Name = "Praia 2";
        beach2.SurfCondition = Core.Enumerators.SurfCondition.VeryBad;
        var viewModel2 = new MyBeachItemViewModel(beach2);
        MyBeaches.Add(viewModel2);

        var beach3 = new Beach();
        beach3.Name = "Praia 3";
        beach3.SurfCondition = Core.Enumerators.SurfCondition.VeryGood;
        var viewModel3 = new MyBeachItemViewModel(beach3);
        MyBeaches.Add(viewModel3);
    }
}