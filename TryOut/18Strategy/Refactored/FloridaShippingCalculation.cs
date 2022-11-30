namespace TryOut.Strategy.Refactored {
    public class FloridaShippingCalculation : IShippingCalculation {
        public decimal Calculate() {
            return 3m;
        }
    }
}