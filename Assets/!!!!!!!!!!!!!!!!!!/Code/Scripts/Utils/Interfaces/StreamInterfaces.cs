

namespace ProjectZephyr
{
    public interface IStream<T>
    {
        StreamList<T> stream { get; set; }

        void InitializeStream(int capacity = 20);

        public void AddStream(T item)
        {
            stream.Add(item);
        }
    }

    public interface IStreamAddable<T>
    {
        IStream<T> streamHandler { get; set; }

        void InitializeStream(IStream<T> stream);

    }
}
