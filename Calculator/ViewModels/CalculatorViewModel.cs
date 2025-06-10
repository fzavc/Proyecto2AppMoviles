using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace Calculator.ViewModels
{
    
    public partial class CalculatorViewModel : ObservableObject
    {
        [ObservableProperty]
        private double billAmount;

        [ObservableProperty]
        private int tipPercentage;

        [ObservableProperty]
        private int numberOfPeople = 1; 
      
        [ObservableProperty]
        private double totalPerPerson;

        [ObservableProperty]
        private double subtotalPerPerson;

        [ObservableProperty]
        private double tipPerPerson;
        
        public CalculatorViewModel()
        {
          
          

            TipPercentage = 10;
        }

     
        private void CalculateTotals()
        {
   
            if (NumberOfPeople <= 0)
            {
                TotalPerPerson = 0;
                SubtotalPerPerson = 0;
                TipPerPerson = 0;
                return;
            }

            var totalTip = BillAmount * (TipPercentage / 100.0);
            var totalBill = BillAmount + totalTip;

            SubtotalPerPerson = BillAmount / NumberOfPeople;
            TipPerPerson = totalTip / NumberOfPeople;
            TotalPerPerson = totalBill / NumberOfPeople;
        }

      
        partial void OnBillAmountChanged(double value) => CalculateTotals();
        partial void OnTipPercentageChanged(int value) => CalculateTotals();
        partial void OnNumberOfPeopleChanged(int value) => CalculateTotals();

        [RelayCommand]
        private void SetTip(string percentage)
        {
            if (int.TryParse(percentage, out int tip))
            {
                
                TipPercentage = tip;
            }
        }

        [RelayCommand]
        private void IncrementPeople()
        {
            NumberOfPeople++;
        }

        [RelayCommand]
        private void DecrementPeople()
        {

            if (NumberOfPeople > 1)
            {
                NumberOfPeople--;
            }
        }
    }
}