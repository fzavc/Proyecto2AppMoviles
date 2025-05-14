using CommunityToolkit.Mvvm.ComponentModel;

namespace CalculoPropinas.Models;

public partial class NewModel : ObservableObject {
    [ObservableProperty]
    private double billAmount;

    [ObservableProperty]
    private double tipPercentage;

    [ObservableProperty]
    private int numberOfPeople;

    public double TipAmount => BillAmount * (TipPercentage / 100);
    public double TotalAmount => BillAmount + TipAmount;
    public double AmountPerPerson => NumberOfPeople > 0 ? TotalAmount / NumberOfPeople : 0;
}
