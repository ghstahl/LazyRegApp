namespace LazyRegApp
{
    public class SomeTransient : ISomeTransient
    {
        public SomeTransient()
        {
            Name = nameof(SomeTransient);
        }

        public string Name { get; }
    }
}