
using ClientService.Models;
using System.Net;
using System.Threading.Tasks;

namespace ClientService.IService
{
    public interface IRequest
    {
        Task<TokenValidation> Login();
        Task<DeviceRegisteredModel> RegisterNewDevice(DeviceRegisterModel model);
        Task<HttpStatusCode> PostState(DeviceState model); 
    }
}
