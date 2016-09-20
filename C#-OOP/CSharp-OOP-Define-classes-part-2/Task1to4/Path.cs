namespace Task1to4
{
    using System.Collections.Generic;

    public class Path
    {
        private ICollection<Point3D> points;

        public Path(params Point3D[] points)
        {
            this.Points = new List<Point3D>(points);
        }

        public ICollection<Point3D> Points
        {
            get
            {
                return new List<Point3D>(this.points);
            }

            private set
            {
                this.points = value;
            }
        }
    }
}
