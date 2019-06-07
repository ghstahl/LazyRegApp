using System.Threading.Tasks;

namespace LazyRegApp
{
    public interface IExpensiveService
    {
        Task<string> GetDataAsync();
    }
}
