using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoRealm.Contract;
using TodoRealm.Models;
using TodoRealm.Views;

namespace TodoRealm.ViewModels;

public partial class TodoListViewModel(ITodoItemDatabase database) : ObservableObject
{
    [ObservableProperty] private TodoItem? _selectedItem;
    public ObservableCollection<TodoItem> Items { get; set; } = [];

    [RelayCommand]
    private async Task ItemAdded()
    {
        await NavigateToItemPage();
    }

    [RelayCommand]
    private async Task NavigatedTo()
    {
        var items = await database.GetItemsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            foreach (var item in items) Items.Add(item);
        });
    }

    [RelayCommand]
    private void NavigatedFrom()
    {
        SelectedItem = null;
    }

    [RelayCommand]
    private async Task SelectionChanged()
    {
        if (SelectedItem is null) return;

        await NavigateToItemPage(SelectedItem);
    }

    private static async Task NavigateToItemPage(TodoItem? item = null)
    {
        await Shell.Current.GoToAsync(nameof(TodoItemPage), true, new Dictionary<string, object>
        {
            { "Item", item ?? new TodoItem() }
        });
    }
}