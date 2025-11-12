using CommunityToolkit.Mvvm.ComponentModel;

namespace SurfRater.Avalonia.ViewModels;

public abstract class ViewModelBase : ObservableObject
{
    private bool _isBusy = false;
    private bool _isNotBusy = true;

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (_isBusy != value)
            {
                _isBusy = value;
                OnPropertyChanged();
                _isNotBusy = !value;
                OnPropertyChanged(nameof(IsNotBusy));
            }
        }
    }

    public bool IsNotBusy
    {
        get => _isNotBusy;
        set
        {
            if (_isNotBusy != value)
            {
                _isNotBusy = value;
                OnPropertyChanged();
                _isBusy = !value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }
    }
}