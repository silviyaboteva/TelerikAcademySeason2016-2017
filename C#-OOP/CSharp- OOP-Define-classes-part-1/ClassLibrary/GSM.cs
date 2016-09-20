namespace MobilePhone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Tools;

    public class GSM
    {
        public static GSM iPhone4S;

        private string model;
        private string manufacturer;
        private double? price;
        private string owner;
        private Battery batteryCharacteristics;
        private Display displayCharacteristics;

        private List<Call> listOfCalls;

        static GSM()
        {
            iPhone4S = new GSM(
                "Iphone 4S",
                "Apple",
                1099.99,
                "John",
                new Battery("AppleBat", 10, 10, BatteryType.LiIon),
                new Display(6, 2));
        }

        public GSM()
        {
            this.batteryCharacteristics = new Battery();
            this.displayCharacteristics = new Display();
            this.listOfCalls = new List<Call>();
        }

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;

            this.batteryCharacteristics = new Battery();
            this.displayCharacteristics = new Display();
            this.listOfCalls = new List<Call>();
        }

        public GSM(string model, string manufacturer, double price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.batteryCharacteristics = battery;
            this.displayCharacteristics = display;
            this.listOfCalls = new List<Call>();
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Value of the {0} can'tt be null", this.Model);
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Value of the {0} can't be null", this.Manufacturer);
                }

                this.manufacturer = value;
            }
        }

        public double? Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            private set
            {
                this.owner = value;
            }
        }

        public Battery BatteryCharacteristics
        {
            get
            {
                return this.batteryCharacteristics;
            }

            private set
            {
                this.batteryCharacteristics = value;
            }
        }

        public Display DisplayCharacteristics
        {
            get
            {
                return this.displayCharacteristics;
            }

            private set
            {
                this.displayCharacteristics = value;
            }
        }

        public List<Call> ListOfCalls
        {
            get
            {
                return new List<Call>(this.listOfCalls);
            }

            private set
            {
                this.listOfCalls = value;
            }
        }

        public string CallHistory()
        {
            var callhistory = new StringBuilder();
            foreach (var call in this.ListOfCalls)
            {
                callhistory.AppendLine(call.ToString());
            }

            return callhistory.ToString();
        }

        public void AddCall(Call call)
        {
            this.listOfCalls.Add(call);
        }

        public void DeleteCall(Call call)
        {
            if (!this.ListOfCalls.Contains(call))
            {
                throw new ArgumentException("Call doesn't exist!");
            }

            this.listOfCalls.Remove(call);
        }

        public void ClearCallHistory()
        {
            this.listOfCalls.Clear();
        }

        public decimal TotalPriceOfCalls()
        {
            decimal result = 0;

            foreach (var call in this.listOfCalls)
            {
                result += (call.CallDuration / 60) * Call.PricePerMinute;
            }

            return result;
        }

        public override string ToString()
        {
            //I don't use String.Format, because I use Microsoft Visual Studio 2013
            return "***GSM information***"
            + "\nModel: " + this.Model
            + "\nPrice: " + this.Price
            + "\n" + this.BatteryCharacteristics.ToString()
            + "\n";
        }
    }
}
