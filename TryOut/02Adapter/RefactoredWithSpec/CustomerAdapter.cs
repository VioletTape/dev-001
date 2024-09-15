namespace TryOut._02Adapter.RefactoredWithSpec {
    public class CustomerAdapter : Adapter<Customer> {
        public CustomerAdapter(Table<Customer> table) : base(table) {
            // тут по идее должен быть весь маппинг свойств
        }

        // тут по факту адаптация намерений 
        public override IQueryable<Customer> Convert(Specification<Customer> specification) {
            var query = CommonConditions(specification);

            var name = specification.ExtractSupersetSpecification<CustomerNameStartFrom>();
            if (name != null) {
                query = query.Where(c => c.Name.StartsWith(name.NameStartsFrom));
            }

            return query;
        }
    }
}