namespace EfCorePlayground.Framework
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class ValueObject<T>
        where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            return !ReferenceEquals(valueObject, null) && EqualsCore(valueObject);
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents().Aggregate(1, (current, obj) => (current * 23) + (obj?.GetHashCode() ?? 0));
        }

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (a is null && b is null) return true;

            if (a is null || b is null) return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        private bool EqualsCore(ValueObject<T> other)
        {
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }
    }
}