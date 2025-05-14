using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CalculoPropinas.Models;

namespace CalculoPropinas.ViewModels;

public partial class MainViewModel : ObservableObject {
    public NewModel Model { get; set; } = new();

    [RelayCommand]
    private void SetTip(double percentage) {
        Model.TipPercentage = percentage;
        OnPropertyChanged(nameof(Model.TipAmount));
        OnPropertyChanged(nameof(Model.TotalAmount));
        OnPropertyChanged(nameof(Model.AmountPerPerson));
    }
}
