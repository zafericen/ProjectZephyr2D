using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public partial class ObjectBVM: ObservableRecipient
{
    public ObjectBVM()
    {
        IsActive = true;
    }
    public void SendAnswer()
    {
        Messenger.Send(new TestMessage(1));
    }

    public void SendRequest()
    {
        var request = Messenger.Send(new TestRequestMessage());
    }
}

