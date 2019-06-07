using Microsoft.Extensions.Logging;

namespace LazyRegApp
{
    public class SomeTransient : ISomeTransient
    {
        public SomeTransient(ILogger<SomeTransient> logger)
        {
            _logger = logger;
            Name = nameof(SomeTransient);
            _logger.LogDebug($"Constructor Fired ");
        }

        private ILogger<SomeTransient> _logger;

        public string Name { get; }
    }
}