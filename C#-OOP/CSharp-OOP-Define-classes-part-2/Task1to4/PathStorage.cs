namespace Task1to4
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;

    public static class PathStorage
    {
        public static void SavePointsToFile(params Point3D[] points)
        {
            var writter = new StreamWriter(@"..\..\Points.txt");
            using (writter)
            {
                foreach (var point in points)
                {
                    writter.WriteLine(point);
                }
            }
        }

        public static ICollection<Point3D> ReadPointsFromFile(string path)
        {
            ICollection<Point3D> points = new List<Point3D>();
            var builder = new StringBuilder();

            var reader = new StreamReader(path);
            using (reader)
            {
                builder.AppendLine(reader.ReadToEnd());
            }

            var splittedPointCoords = builder.ToString()
                .Split(new char[] { ',', ' ', '[', ']', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splittedPointCoords.Length - 2; i += 3)
            {
                var x = double.Parse(splittedPointCoords[i]);
                var y = double.Parse(splittedPointCoords[i + 1]);
                var z = double.Parse(splittedPointCoords[i + 2]);

                var point = new Point3D(x, y, z);
                points.Add(point);
            }

            return points;
        }
    }
}
