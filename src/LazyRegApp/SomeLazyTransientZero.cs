using Microsoft.Extensions.Logging;

namespace LazyRegApp
{
    public class SomeLazyTransientZero : ISomeTransientZero, ISomeLazyTransient
    {
        public SomeLazyTransientZero(ILogger<SomeLazyTransientZero> logger)
        {
            _logger = logger;
            Name = nameof(SomeLazyTransientZero);
            _logger.LogDebug($"Constructor Fired ");
        }

        private ILogger<SomeLazyTransientZero> _logger;

        public string Name { get; }
    }
}