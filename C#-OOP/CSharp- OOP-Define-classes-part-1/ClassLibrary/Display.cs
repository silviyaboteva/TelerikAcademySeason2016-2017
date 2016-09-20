namespace Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Display
    {
        public Display()
        {
        
        }

        public Display(double size, int numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        public double? Size { get; private set; }
        public int? NumberOfColors { get; private set; }

        public override string ToString()
        {
            //I don't use String.Format, because I use Microsoft Visual Studio 2013
            return "***Display information***" 
                + "\nSize: " + this.Size + "\nNumber of colors: " + this.NumberOfColors + "\n";
        }
    }
}
