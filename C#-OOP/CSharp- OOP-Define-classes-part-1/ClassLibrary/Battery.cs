namespace Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Battery
    {
        private string model;

        public Battery()
        {

        }

        public Battery(string model, double hoursIdle, double hoursTalk, BatteryType batteryType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
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
                    throw new ArgumentException("Value of the {0} can't be null!", this.model);
                }

                this.model = value;
            }
        }

        public double? HoursIdle { get; private set; }

        public double? HoursTalk { get; private set; }

        public BatteryType BatteryType { get; private set; }

        public override string ToString()
        {
            //I don't use String.Format, because I use Microsoft Visual Studio 2013
            return "***Battery information***"
                + "\nModel: " + this.Model
                + "\nHours idle: " + this.HoursIdle
                + "\nHours talk: " + this.HoursTalk
                + "\nType: " + this.BatteryType
                + "\n";
        }
    }
}
