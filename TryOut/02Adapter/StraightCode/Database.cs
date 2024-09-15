using System.Collections;
using System.Linq.Expressions;

namespace TryOut.Adapter.StraightCode {
    /*
     * технические классы
     */
    public class DbAccessor {
        public Table<T> GetTable<T>() where T : IDto {
            return new Table<T>();
        }

        public List<T> Select<T>(IQueryable<T> query) where T : IDto {
            // access to db, parsing and so on
            var result = query.ToList();

            return result;
        }
    }

    public class Table<T> : IQueryable<T> where T : IDto{
        public IEnumerator<T> GetEnumerator() {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public Expression Expression { get; private set; }
        public Type ElementType { get; private set; }
        public IQueryProvider Provider { get; private set; }
    }

    public interface IDto{}

    public class CustomerDto : IDto {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class OrderDto : IDto {
        public Guid Id { get; set; }
        public CustomerDto Customer { get; set; }
    }
}