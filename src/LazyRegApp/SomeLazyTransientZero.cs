namespace LazyRegApp
{
    public class SomeLazyTransientZero : ISomeTransientZero, ISomeLazyTransient
    {
        public SomeLazyTransientZero()
        {
            Name = nameof(SomeLazyTransientZero);
        }

        public string Name { get; }
    }
}