using Microsoft.AspNet.SignalR;
using Robot.Controllers;
using Robot.Models;

namespace Robot.Hubs
{
    public class DisplayHub : Hub
    {
        public void ReceiveMessage(InputModel model)
        {
            TestController.Instance.ReceiveMessage(model);
        }
    }
}
