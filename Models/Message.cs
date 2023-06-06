using System;

namespace KChat.Models;

public class Message
{
  public DateTime Date { get; set; }
  public string User { get; set; }
  public string Text { get; set; }
}