using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace Calculator.ViewModels
{
    public partial class CalculatorViewModel : ObservableObject
    {
        [ObservableProperty]
        private double montoDeLaCuenta;

        [ObservableProperty]
        private int porcentajeDePropina;

        [ObservableProperty]
        private int cantidadDePersonas = 1;

        [ObservableProperty]
        private double totalPorPersona;

        [ObservableProperty]
        private double subtotalPorPersona;

        [ObservableProperty]
        private double propinaPorPersona;
        
        public CalculatorViewModel()
        {
            PorcentajeDePropina = 10;
        }
        
        private void CalcularTodoDeNuevo()
        {
            if (CantidadDePersonas <= 0)
            {
                TotalPorPersona = 0;
                SubtotalPorPersona = 0;
                PropinaPorPersona = 0;
                return;
            }

            var propinaTotal = MontoDeLaCuenta * (PorcentajeDePropina / 100.0);
            var cuentaTotal = MontoDeLaCuenta + propinaTotal;

            SubtotalPorPersona = MontoDeLaCuenta / CantidadDePersonas;
            PropinaPorPersona = propinaTotal / CantidadDePersonas;
            TotalPorPersona = cuentaTotal / CantidadDePersonas;
        }
        
        partial void OnMontoDeLaCuentaChanged(double value) => CalcularTodoDeNuevo();
        partial void OnPorcentajeDePropinaChanged(int value) => CalcularTodoDeNuevo();
        partial void OnCantidadDePersonasChanged(int value) => CalcularTodoDeNuevo();

        [RelayCommand]
        private void FijarPropina(string porcentaje)
        {
            if (int.TryParse(porcentaje, out int nuevoPorcentaje))
            {
                PorcentajeDePropina = nuevoPorcentaje;
            }
        }

        [RelayCommand]
        private void AgregarPersona()
        {
            CantidadDePersonas++;
        }

        [RelayCommand]
        private void QuitarPersona()
        {
            if (CantidadDePersonas > 1)
            {
                CantidadDePersonas--;
            }
        }
    }
}