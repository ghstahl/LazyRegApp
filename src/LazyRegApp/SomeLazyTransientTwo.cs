namespace LazyRegApp
{
    public class SomeLazyTransientTwo : ISomeTransient, ISomeLazyTransient
    {
        public SomeLazyTransientTwo()
        {
            Name = nameof(SomeLazyTransientTwo);
        }

        public string Name { get; }
    }
}