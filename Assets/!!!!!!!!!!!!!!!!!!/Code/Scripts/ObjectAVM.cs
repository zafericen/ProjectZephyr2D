using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

public partial class ObjectAVM : ObservableRecipient, IRecipient<TestMessage>, IRecipient<TestRequestMessage>
{
    [ObservableProperty]
    private int _sendValue;
    public ObjectAVM()
    {
        IsActive = true;
    }
    public void Receive(TestMessage message)
    {
        SendValue = message.Value;
    }

    public void Receive(TestRequestMessage message)
    {
        message.Reply(SendValue);
    }
}

public sealed class TestMessage : ValueChangedMessage<int>
{
    public TestMessage(int value) : base(value)
    {
    }
}
public sealed class TestRequestMessage: RequestMessage<int>
{

}

