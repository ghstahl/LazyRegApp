using Microsoft.Extensions.Logging;

namespace LazyRegApp
{
    public class SomeLazyTransientOne : ISomeTransient, ISomeLazyTransient
    {
        public SomeLazyTransientOne(ILogger<SomeLazyTransientOne> logger)
        {
            _logger = logger;
            Name = nameof(SomeLazyTransientOne);
            _logger.LogDebug($"Constructor Fired ");
        }

        private ILogger<SomeLazyTransientOne> _logger;

        public string Name { get; }
    }
}