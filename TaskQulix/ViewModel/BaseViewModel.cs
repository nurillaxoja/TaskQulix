using CommunityToolkit.Mvvm.ComponentModel;


namespace TaskQulix.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {

        }
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !isBusy;


    }
}
