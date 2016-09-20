namespace Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Call
    {
        public const decimal PricePerMinute = 0.37M;

        public Call(DateTime date, int duration, string phone)
        {
            this.Date = date;
            this.CallDuration = duration;
            this.DialedPhoneNumber = phone;
        }

        public DateTime Date { get; private set; }

        public int CallDuration { get; private set; }

        public string DialedPhoneNumber { get; private set; }

        public override string ToString()
        {
            //I don't use String.Format, because I use Microsoft Visual Studio 2013
            return "Dialed phone: " + this.DialedPhoneNumber
                + "\nDate: " + this.Date
                + "\nCall duration: " + this.CallDuration
                + "\n";
        }
    }
}
