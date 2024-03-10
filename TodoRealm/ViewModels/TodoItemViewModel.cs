using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoRealm.Contract;
using TodoRealm.Models;

namespace TodoRealm.ViewModels;

[QueryProperty(nameof(Item), nameof(Item))]
public partial class TodoItemViewModel(ITodoItemDatabase database) : ObservableObject
{
    [ObservableProperty] private TodoItem? _item;

    [RelayCommand]
    private async Task Cancel()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task Delete()
    {
        if (Item?.Id is not null)
        {
            await database.DeleteItemAsync(Item);
            await Shell.Current.GoToAsync("..");
        }
    }

    [RelayCommand]
    private async Task Save()
    {
        if (string.IsNullOrEmpty(Item?.Name))
        {
            await Shell.Current.DisplayAlert("Name Required",
                "Please enter a name for the todo item.", "OK");
            return;
        }

        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }
}