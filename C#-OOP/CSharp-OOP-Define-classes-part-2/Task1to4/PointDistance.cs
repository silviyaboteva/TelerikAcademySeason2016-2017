namespace Task1to4
{
    using System;

    public static class PointDistance
    {
        //Task 3
        public static double FindDistance(Point3D a, Point3D b)
        {
            double distance = 0;
            distance = Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2) + Math.Pow(b.z - a.z, 2));

            return distance;
        }

    }
}
