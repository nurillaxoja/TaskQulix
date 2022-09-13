using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TaskQulix.Services;


namespace TaskQulix.ViewModel
{
    public partial class CurrencyViewModel : BaseViewModel
    {
        public ObservableCollection<Currency> Currency { get; } = new ();

        CurrencyService currencyService;

        public CurrencyViewModel(CurrencyService service)
        {
            Title = "Курсы валют";
            this.currencyService = service;

            GetCurrencyCommand.Execute(this);
            
        }

       [RelayCommand]
        async Task GetCurrencyAsync()
        {
            if(IsBusy)
                return;

            try
            {
                IsBusy = true;

                var currencies = await currencyService.GetCurrency();

                if (Currency.Count != 0)
                    Currency.Clear();

                foreach(var currency in currencies)
                    Currency.Add(currency);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error",
                    $"Unable to get Currencies {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
