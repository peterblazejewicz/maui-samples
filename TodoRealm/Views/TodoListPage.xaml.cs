using TodoRealm.ViewModels;

namespace TodoRealm.Views;

public partial class TodoListPage : ContentPage
{
    public TodoListPage(TodoListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}