using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MessagingCenter.Messages;

public class HiMessage(string? message = null) : ValueChangedMessage<string?>(message);