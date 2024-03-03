using MessagingCenter.ViewModels;

namespace MessagingCenter;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }
}