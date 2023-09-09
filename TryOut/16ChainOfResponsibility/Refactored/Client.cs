using System.Collections;

namespace TryOut.ChainOfResponsibility.Refactored;

public class Client {
    public Client() {
        // example 
        var courier = new DeliverCompany("acme");
        courier.Add(new CountryRestriction());

        // other


        var package = new Package();
        new CalcDeliveryService().Calc(package, new List<DeliverCompany>());

        var companies = package.PossibleCouriers;
    }


    public class CalcDeliveryService {
        public void Calc(Package package, List<DeliverCompany> couriers) {
           
            Dictionary<DeliverCompany, Constraint> rules = new Dictionary<DeliverCompany, Constraint>();
            foreach (var courier in couriers) {
                rules.Add(courier,  new EmptyConstraint());

                foreach (var r in courier.Restrictions) {
                    Constraint c = r switch {
                                CountryRestriction cr => new CountryConstraint(cr.Value)
                              , WeightRestriction wr => new WeightConstraint(wr.Value)
                                // ...
                              , _ => new EmptyConstraint()
                            };
                    rules[courier].SetNext(c);
                }
            }


            couriers.ForEach(x => rules[x].Handle(package, x));


        }
    }

    public interface IConstraint {
        void Handle(Package package, DeliverCompany company);
    }

    public abstract class Constraint : IConstraint {
        IConstraint? next;

        protected Constraint() { }

        protected Constraint(IConstraint next) {
            this.next = next;
        }

        public void Handle(Package package, DeliverCompany company) {
            if (Validate(package) == false)
                return;

            if (next == null)
                package.PossibleCouriers.Add(company);
            else
                next.Handle(package, company);
        }

        public Constraint SetNext(Constraint next) {
            this.next = next;

            return next;
        }

        internal abstract bool Validate(Package package);
    }

    public class EmptyConstraint : Constraint {
        internal override bool Validate(Package package) {
            return true;
        }
    }

    public class CountryConstraint : Constraint {
        readonly List<string> availableCountries;

        public CountryConstraint(List<string> availableCountries) {
            this.availableCountries = availableCountries;
        }

        public CountryConstraint(List<string> availableCountries, IConstraint next) : base(next) {
            this.availableCountries = availableCountries;
        }

        internal override bool Validate(Package package) {
            return availableCountries.Contains(package.Destination.Country);
        }
    }

    public class SizeConstraint : Constraint {
        readonly Dimension maxSize;

        public SizeConstraint(Dimension maxSize) {
            this.maxSize = maxSize;
        }

        public SizeConstraint(Dimension maxSize, IConstraint next) : base(next) {
            this.maxSize = maxSize;
        }

        internal override bool Validate(Package package) {
            return package.Size < maxSize;
        }
    }

    public class WeightConstraint : Constraint {
        readonly double maxWeight;

        public WeightConstraint(double maxWeight) {
            this.maxWeight = maxWeight;
        }

        public WeightConstraint(double maxWeight, IConstraint next) : base(next) {
            this.maxWeight = maxWeight;
        }

        internal override bool Validate(Package package) {
            return package.Weight < maxWeight;
        }
    }

    public class ValuableConstrain : Constraint {
        readonly bool acceptValuable;

        public ValuableConstrain(bool acceptValuable) {
            this.acceptValuable = acceptValuable;
        }

        public ValuableConstrain(bool acceptValuable, IConstraint next) : base(next) {
            this.acceptValuable = acceptValuable;
        }

        internal override bool Validate(Package package) {
            if (package.IsValuable &&
                !acceptValuable)
                return false;

            return true;
        }
    }

    public class DangerousConstrain : Constraint {
        readonly bool acceptDangerous;

        public DangerousConstrain(bool acceptDangerous) {
            this.acceptDangerous = acceptDangerous;
        }

        public DangerousConstrain(bool acceptDangerous, IConstraint next) : base(next) {
            this.acceptDangerous = acceptDangerous;
        }

        internal override bool Validate(Package package) {
            if (package.IsDangerous &&
                !acceptDangerous)
                return false;

            return true;
        }
    }

    public class Package {
        public Address Destination { get; set; }
        public Dimension Size { get; set; }

        public double Weight { get; set; }

        public bool IsValuable { get; set; }
        public bool IsDangerous { get; set; }

        public List<DeliverCompany> PossibleCouriers = new();
    }

    public class Dimension {
        public static bool operator <(Dimension d1, Dimension d2) {
            return true;
        }

        public static bool operator >(Dimension d1, Dimension d2) {
            return false;
        }
    }

    public class DeliverCompany {
        public DeliverCompany(string argo) { }
        public List<IRestriction> Restrictions { get; set; }

        public void Add(IRestriction restriction) {
            Restrictions.Add(restriction);
        }
    }


    public class Address {
        public Address(string address) { }

        public string Country { get; set; }
    }

    public interface IRestriction {
        
    }

    public interface Restriction<T> : IRestriction {
        T Value { get; set; }
    }

    public class CountryRestriction : Restriction<List<string>> {
        public List<string> Value { get; set; }
    }


    public class WeightRestriction : Restriction<double> {
        public double Value { get; set; }
    }
    public class SizeRestriction : Restriction<Dimension> {
        public Dimension Value { get; set; }
    }
    public class DangerousRestriction : Restriction<bool> {
        public bool Value { get; set; }
    }
    public class ValueRestriction : Restriction<bool> {
        public bool Value { get; set; }
    }

    public class Country { }
}



