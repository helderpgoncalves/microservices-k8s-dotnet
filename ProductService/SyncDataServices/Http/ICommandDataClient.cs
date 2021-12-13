using ProductService.Dtos;
using System.Threading.Tasks;

namespace ProductService.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendProductToUser(ProductReadDto product);
    }
}