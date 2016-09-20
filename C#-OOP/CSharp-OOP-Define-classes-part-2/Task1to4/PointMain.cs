namespace Task1to4
{
    using System;
    using System.Threading.Tasks;
    using System.Globalization;

    public class PointMain
    {
        public static void Main(string[] args)
        {
            // Making some points
            var firstPoint = new Point3D(2, 1, 5);
            var secondPoint = new Point3D(0, 2, 4);
            var thirdPoint = new Point3D(3, 4, 9);

            // Calculating the distance between two points
            var distance = PointDistance.FindDistance(firstPoint, secondPoint);
            Console.WriteLine(distance);

            // Create isntance of the call Path
            Path points = new Path(firstPoint, secondPoint, thirdPoint);

            // Get the coletion of points from the property
            var pointColection = points.Points;

            foreach (var item in pointColection)
            {
                Console.WriteLine(item);
            }

            // writes Points to file  
            PathStorage.SavePointsToFile(firstPoint, secondPoint, thirdPoint);

            // reads Points from a file
            var readFromFilePoints = PathStorage.ReadPointsFromFile(@"..\..\ReadPoints.txt");

            // prints the readFromFilePoints
            foreach (var readPoint in readFromFilePoints)
            {
                Console.WriteLine(readPoint);
            }

            // get the version of the point Problem 11. Version attribute
            Type type = typeof(Point3D);
            object[] attr = type.GetCustomAttributes(false);
            foreach (var item in attr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
