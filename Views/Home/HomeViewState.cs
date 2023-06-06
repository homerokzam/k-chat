using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KChat.Models;

namespace KChat.Views.Home;

public class HomeViewState
{
  public HomeViewState()
  {
    Messages.Add(new Message { User = "USER1", Date = DateTime.Now, Text = "Message 1" });
    Messages.Add(new Message { User = "USER1", Date = DateTime.Now, Text = "Message 2" });
    Messages.Add(new Message { User = "USER1", Date = DateTime.Now, Text = "Message 3" });
    Messages.Add(new Message { User = "USER1", Date = DateTime.Now, Text = "Message 4" });
    Messages.Add(new Message { User = "USER2", Date = DateTime.Now, Text = "Message 5" });
    Messages.Add(new Message { User = "USER1", Date = DateTime.Now, Text = "Message 6" });
    Messages.Add(new Message { User = "USER2", Date = DateTime.Now, Text = "Message 7" });
    Messages.Add(new Message { User = "USER2", Date = DateTime.Now, Text = "Message 8" });
    Messages.Add(new Message { User = "USER2", Date = DateTime.Now, Text = "Message 9" });
    Messages.Add(new Message { User = "USER2", Date = DateTime.Now, Text = "Message 10" });
  }

  public ObservableCollection<Message> Messages { get; set;} = new ObservableCollection<Message>();
}