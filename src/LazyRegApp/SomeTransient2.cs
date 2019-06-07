using Microsoft.Extensions.Logging;

namespace LazyRegApp
{
    public class SomeTransient2 : ISomeTransient
    {
        public SomeTransient2(ILogger<SomeTransient2> logger)
        {
            _logger = logger;
            Name = nameof(SomeTransient2);
            _logger.LogDebug($"Constructor Fired ");
        }

        private ILogger<SomeTransient2> _logger;

        public string Name { get; }
    }
}