namespace TryOut.Commands.Refactored; 

public class SendNotification : Command {
    public string Message { get; }

    public SendNotification(string message) {
        Message = message;
    }
}



public class NotificationService {
    readonly CommandHandler commandHandler;

    public NotificationService(CommandHandler commandHandler) {
        this.commandHandler = commandHandler;
    }

    public async Task Handle<T>(T command){
        switch (command) {
            case SendNotification c:
                Send(c.Message);
                return;
        }
    }

    public void Send(string message) {
        Console.WriteLine($"NotificationService - {message}");
    }
}
