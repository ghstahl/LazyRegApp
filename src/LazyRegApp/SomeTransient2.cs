namespace LazyRegApp
{
    public class SomeTransient2 : ISomeTransient
    {
        public SomeTransient2()
        {
            Name = nameof(SomeTransient2);
        }

        public string Name { get; }
    }
}