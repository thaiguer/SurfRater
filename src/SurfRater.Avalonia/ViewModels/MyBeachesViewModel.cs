using CommunityToolkit.Mvvm.Input;
using SurfRater.Avalonia.ViewModels.Base;
using SurfRater.Avalonia.ViewModels.Components;
using SurfRater.Core.Model.Entities;
using System.Collections.ObjectModel;
using SurfRater.Core.Model.ValueObjects;

namespace SurfRater.Avalonia.ViewModels;

public partial class MyBeachesViewModel : ViewModelBase
{
    public ObservableCollection<MyBeachItemViewModel> MyBeaches { get; set; } = [];

    [RelayCommand]
    private void AddBeach()
    {
        var beach = new Beach(new Coordinate(-28.492899811875024, -48.75767207194235));
        beach.Name = "aaaaaaaaaaaaa";
        beach.SurfCondition = Core.Enumerators.SurfCondition.Poor;

        var viewModel = new MyBeachItemViewModel(beach);
        MyBeaches.Add(viewModel);
    }

    public MyBeachesViewModel()
    {
        var beach0 = new Beach(new Coordinate(-28.492899811875024, -48.75767207194235));
        beach0.Name = "Mar Grosso";
        beach0.SurfCondition = Core.Enumerators.SurfCondition.Unknown;
        var viewModel0 = new MyBeachItemViewModel(beach0);
        MyBeaches.Add(viewModel0);

        var beach1 = new Beach(new Coordinate(-28.434375470529396, -48.74452520638368));
        beach1.Name = "Gi";
        beach1.SurfCondition = Core.Enumerators.SurfCondition.Unknown;
        var viewModel1 = new MyBeachItemViewModel(beach1);
        MyBeaches.Add(viewModel1);

        var beach2 = new Beach(new Coordinate(-28.332082860653856, -48.70125616919678));
        beach2.Name = "Itapirubá";
        beach2.SurfCondition = Core.Enumerators.SurfCondition.Unknown;
        var viewModel2 = new MyBeachItemViewModel(beach2);
        MyBeaches.Add(viewModel2);

        var beach3 = new Beach(new Coordinate(-28.249476943319888, -48.65973045209686));
        beach3.Name = "Imbituba";
        beach3.SurfCondition = Core.Enumerators.SurfCondition.Unknown;
        var viewModel3 = new MyBeachItemViewModel(beach3);
        MyBeaches.Add(viewModel3);
    }
}