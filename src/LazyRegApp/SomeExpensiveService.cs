using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace LazyRegApp
{
    public class SomeExpensiveService : IExpensiveService
    {
        private ILogger<SomeExpensiveService> _logger;
        private string _name;

        public SomeExpensiveService(System.IServiceProvider sp, string name)
        {
            _logger = sp.GetRequiredService<ILogger<SomeExpensiveService>>();
            _name = name;
            _logger.LogDebug($"Constructor {name}");
        }
        public Task<string> GetDataAsync()
        {
            return Task.FromResult($"{nameof(SomeExpensiveService)}_{_name}");
        }
    }
}
