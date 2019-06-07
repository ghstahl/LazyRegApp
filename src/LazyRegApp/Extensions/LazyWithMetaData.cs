using System;

namespace LazyRegApp.Extensions
{
    public class LazyWithMetaData<T, TMetaData> : Lazy<T> where T : class where TMetaData : class
    {
        public LazyWithMetaData(T value, TMetaData metaData) : base(value)
        {
            MetaData = metaData;
        }
        public LazyWithMetaData(Func<T> valueFactory, TMetaData metaData) : base(valueFactory)
        {
            MetaData = metaData;
        }

        public TMetaData MetaData { get; }
    }
}
