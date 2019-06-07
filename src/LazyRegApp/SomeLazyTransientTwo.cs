using Microsoft.Extensions.Logging;

namespace LazyRegApp
{
    public class SomeLazyTransientTwo : ISomeTransient, ISomeLazyTransient
    {
        public SomeLazyTransientTwo(ILogger<SomeLazyTransientTwo> logger)
        {
            _logger = logger;
            Name = nameof(SomeLazyTransientTwo);
            _logger.LogDebug($"Constructor Fired ");
        }

        private ILogger<SomeLazyTransientTwo> _logger;

        public string Name { get; }
    }
}