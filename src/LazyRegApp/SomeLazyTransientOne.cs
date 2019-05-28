namespace LazyRegApp
{
    public class SomeLazyTransientOne : ISomeTransient, ISomeLazyTransient
    {
        public SomeLazyTransientOne()
        {
            Name = nameof(SomeLazyTransientOne);
        }

        public string Name { get; }
    }
}