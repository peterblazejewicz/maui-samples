using TodoRealm.ViewModels;

namespace TodoRealm.Views;

public partial class TodoItemPage : ContentPage
{
    public TodoItemPage(TodoItemViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}