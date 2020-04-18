namespace EfCorePlayground.Model
{
    using System.Collections;
    using System.Collections.Generic;

    public class Tags : ICollection<Tag>
    {
        private readonly ICollection<Tag> _tags = new HashSet<Tag>();

        public Tags() { }

        public Tags(params Tag[] tags)
        {
            _tags = new HashSet<Tag>(tags);
        }

        public int Count => _tags.Count;

        public bool IsReadOnly => true;

        public IEnumerator<Tag> GetEnumerator() => _tags.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(Tag item) => _tags.Add(item);

        public void Clear() => _tags.Clear();

        public bool Contains(Tag item) => _tags.Contains(item);

        public void CopyTo(Tag[] array, int arrayIndex) => _tags.CopyTo(array, arrayIndex);

        public bool Remove(Tag item) => _tags.Remove(item);

    }
}