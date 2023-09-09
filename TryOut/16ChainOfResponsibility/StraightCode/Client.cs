namespace TryOut.ChainOfResponsibility.StraightCode; 

public class Client {
        public Client() {
            var address = new Address("Poland, Wroclaw, Kowalska, 42");
            var calc = new CalcDeliveryService().Calc(address);
        }
    }

    public class CalcDeliveryService {
        public List<DeliverPrice> Calc(Address address) {
            var deliverers = new List<DeliverPrice>();
            if (address.Country == "Poland") {
                var deliverer1 = new LocalDeliverer("Argo").CheckPrice(address);
                var deliverer2 = new LocalDeliverer("Ters").CheckPrice(address);
                if (deliverer1.Price > deliverer2.Price) {
                    deliverers.Add(deliverer2);
                }
                if (deliverer1.Price < deliverer2.Price) {
                    deliverers.Add(deliverer1);
                }
                deliverers.Add(deliverer1);
                deliverers.Add(deliverer2);
            }
            if (EUDelivererCanHandle(address)) {
                var deliverer1 = new LocalDeliverer("EuroExpress").CheckPrice(address);
                var deliverer2 = new LocalDeliverer("PigeonMail").CheckPrice(address);
                var deliverer3 = new LocalDeliverer("WheelsOfPost").CheckPrice(address);
                var deliverer4 = new LocalDeliverer("DHL").CheckPrice(address);
                var deliverer5 = new LocalDeliverer("EmPost").CheckPrice(address);
                if (deliverer1.Price > deliverer2.Price) {
                    return new List<DeliverPrice> {deliverer2};
                }
                if (deliverer1.Price < deliverer2.Price) {
                    return new List<DeliverPrice> {deliverer1};
                }
                return new List<DeliverPrice> {deliverer1, deliverer2};
            }

            else {
                var deliverer1 = new LocalDeliverer("DHL").CheckPrice(address);
                var deliverer2 = new LocalDeliverer("PonyExpress").CheckPrice(address);
                var deliverer3 = new LocalDeliverer("FedEx").CheckPrice(address);
                var deliverer4 = new LocalDeliverer("EmPost").CheckPrice(address);

                if (deliverer1.Price > deliverer2.Price) {
                    deliverers.Add(deliverer1);
                }
                if (deliverer1.Price < deliverer2.Price) {
                    deliverers.Add(deliverer2);
                }
            }

            return deliverers;
        }

        private bool EUDelivererCanHandle(Address argo) {
            return false;
        }
    }

    public class LocalDeliverer {
        public LocalDeliverer(string argo) {}

        public DeliverPrice CheckPrice(Address address) {
            return new DeliverPrice();
        }
    }

    public class DeliverPrice {
        public Money Price { get; set; }
    }

    public class Money : IComparable {
        public int CompareTo(object obj) {
            return 0;
        }

        public static bool operator >(Money m1, Money m2) {
            return true;
        }

        public static bool operator <(Money m1, Money m2) {
            return true;
        }
    }

    public class Address {
        public Address(string address) {}

        public string Country { get; set; }
    }