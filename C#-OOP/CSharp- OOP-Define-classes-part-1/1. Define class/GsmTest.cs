
namespace Define_class
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MobilePhone;
    using Tools;

    class GsmTestClass
    {
        static void Main()
        {
            GsmTest();
            CallHistoryTest();
        }

        private static void GsmTest()
        {
            Console.WriteLine("***GSMTest***");
            Console.WriteLine();

            var lion = new Battery("Lion", 48, 100, BatteryType.LiIon);
            var gorilla = new Display(5, 16000000);
            var HTC = new GSM("Desire 820", "HTC", 599.99, "Silviya", lion, gorilla);
            var sony = new GSM("Xperia Tipo", "Sony", 249.99, "Deni", lion, gorilla);
            var samsung = new GSM("Galaxy S6", "Samsung", 859.99, "Pesho", lion, gorilla);

            var listOfGSMs = new List<GSM> { HTC, sony, samsung };

            Console.WriteLine(string.Join(Environment.NewLine, listOfGSMs));
            Console.WriteLine(GSM.iPhone4S);
        }

        private static void CallHistoryTest()
        {
            Console.WriteLine("***Call History Test***");
            Console.WriteLine();

            var lion = new Battery("Lion", 48, 100, BatteryType.LiIon);
            var gorilla = new Display(5, 16000000);

            var HTC = new GSM("Desire 820", "HTC", 599.99, "Silviya", lion, gorilla);

            var firstCall = new Call(DateTime.Now, 5, "0899 88 88 88");
            var secondCall = new Call(new DateTime(2016, 05, 12), 8, "0899 77 77 77");
            var thirdCall = new Call(new DateTime(2016, 02, 11), 15, "0897 33 33 33");

            HTC.AddCall(firstCall);
            HTC.AddCall(secondCall);
            HTC.AddCall(thirdCall);

            List<Call> listOfCalls = HTC.ListOfCalls;

            Console.WriteLine(string.Join(Environment.NewLine, listOfCalls));

            decimal price = HTC.TotalPriceOfCalls();
            Console.WriteLine(price);
            Console.WriteLine();

            HTC.DeleteCall(HTC.ListOfCalls.OrderByDescending(c => c.CallDuration).First());
            Console.WriteLine(string.Join(Environment.NewLine, HTC.ListOfCalls));

            decimal priceWhenLongestCallIsRemoved = HTC.TotalPriceOfCalls();
            Console.WriteLine(priceWhenLongestCallIsRemoved);

            HTC.ClearCallHistory();
            Console.WriteLine("History has been cleared!!!");
        }

    }
}
