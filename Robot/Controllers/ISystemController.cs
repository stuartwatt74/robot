using Microsoft.AspNet.SignalR;
using Robot.Models;

namespace Robot.Controllers
{
    public interface ISystemController
    {
        void SetHub<T>() where T : Hub;
        void Stop(bool immediate);
        void ReceiveMessage(IInputModel model);
    }
}
