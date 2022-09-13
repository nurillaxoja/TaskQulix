namespace TaskQulix;

public partial class MainPage : ContentPage
{
	public MainPage(CurrencyViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

