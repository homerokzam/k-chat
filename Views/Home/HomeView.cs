using System;
using System.Threading.Tasks;
using KChat.Models;
using MauiReactor;
using Microsoft.Maui.Devices;

namespace KChat.Views.Home;

class HomeView : Component<HomeViewState>
{
  private CollectionView _collectionView;
  private Grid _gridCollectionView;

  public HomeView()
  {
  }

  public override VisualNode Render()
  {
    _collectionView = new CollectionView().ItemsSource(State.Messages, item => {
          bool left = item.User == "USER1";
          var labelUser = new Label(item.User).TextColor(Colors.LightGray);
          var labelText = new Label(item.Text).TextColor(left ? Colors.Yellow : Colors.Blue).FontSize(18);

          if (left)
          {
            labelUser = labelUser.HStart();
            labelText = labelText.HStart();
          }
          else
          {
            labelUser = labelUser.HEnd();
            labelText = labelText.HEnd();
          }

          Console.WriteLine($"User: {item.User} <==> {item.Text}");

          var stack = new VStack
              {
                labelUser,
                labelText
              };

          return stack;
        }).VerticalOptions(Microsoft.Maui.Controls.LayoutOptions.FillAndExpand).ItemsUpdatingScrollMode(Microsoft.Maui.Controls.ItemsUpdatingScrollMode.KeepLastItemInView);

    if (DeviceInfo.Current.Platform != DevicePlatform.Android)
      _collectionView.MaximumHeightRequest(350);

    return new ContentPage
    {
      new Grid("60, *, 60", "*")
      {
        new VStack
        {
          new Label("Homero").TextColor(Colors.Black).FontSize(18),
        }.BackgroundColor(Colors.White),

        _collectionView.GridRow(1).BackgroundColor(Colors.Black),
        
        new HStack
        {
          new Button().Text("USUARIO (1)").OnClicked(async () => await OnSendUsuario1MessageAsync()),
          new Button().Text("USUARIO (2)").OnClicked(async () => await OnSendUsuario2MessageAsync()),
        }.GridRow(2).BackgroundColor(Colors.Gray),
      }
    };
  }

  public async Task OnSendUsuario1MessageAsync()
  {
    var message = new Message { User = "USER1", Date = DateTime.Now, Text = $"Text {DateTime.Now.ToLongDateString()}" };
    SetState(state => state.Messages.Add(message));
  }

  public async Task OnSendUsuario2MessageAsync()
  {
    SetState(state => state.Messages.Add(new Message { User = "USER2", Date = DateTime.Now, Text = $"Text {DateTime.Now.ToLongDateString()}" }));
    // _collectionView.ItemsUpdatingScrollMode(Microsoft.Maui.Controls.ItemsUpdatingScrollMode.KeepLastItemInView);
  }
}