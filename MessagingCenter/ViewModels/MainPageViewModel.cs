using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MessagingCenter.Messages;

namespace MessagingCenter.ViewModels;

public partial class MainPageViewModel : ObservableRecipient, IRecipient<HiMessage>
{
    public ObservableCollection<string> Greetings { get; set; } = [];

    public void Receive(HiMessage message)
    {
        Greetings.Add(message.Value is not null ? $"Hi {message.Value}" : "Hi");
    }

    private async Task ShowToast(string text)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var toast = Toast.Make(text);
        await toast.Show(cancellationTokenSource.Token);
    }

    [RelayCommand]
    private void SayHi()
    {
        this.Messenger.Send(new HiMessage());
    }

    [RelayCommand]
    private void SayHiToJohn()
    {
        this.Messenger.Send(new HiMessage("John"));
    }

    [RelayCommand]
    private async Task Subscribe()
    {
        const string inactiveText = "This page has stopped listening, so no more alerts.";
        const string activeText = "This page has started listening!";
        IsActive = !IsActive;
        await ShowToast(IsActive ? activeText : inactiveText);
    }

    [RelayCommand]
    private void Loaded()
    {
        IsActive = true;
    }

    [RelayCommand]
    private void Unloaded()
    {
        IsActive = false;
    }
}