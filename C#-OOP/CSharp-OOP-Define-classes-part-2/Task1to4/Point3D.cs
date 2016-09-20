namespace Task1to4
{
    using System;
    using System.Text;

    public struct Point3D
    {
        //Task2
        private static readonly Point3D point0;

        //Task 1
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        //Constructors
        static Point3D()
        {
            point0 = new Point3D(0, 0, 0);
        }

        public Point3D(double x, double y, double z)
            : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        //Properties
        public double X  // Task 1
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public double Y // Task 1
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public double Z // Task 1
        {
            get { return this.z; }
            set { this.z = value; }
        }

        public static Point3D Point0
        {
            get { return point0; }
        }

        //Methods
        public override string ToString()
        {
            StringBuilder coordinates = new StringBuilder();
            coordinates.AppendLine(string.Format("[{0}, {1}, {2}]", this.x, this.y, this.z));
            return coordinates.ToString();
        }

        public static Point3D Parse(string input) //method for parsing the 3dPoints from the saved txt file
        {
            StringBuilder coordinates = new StringBuilder();
            double[] xyz = new double[3];
            int xyzIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]) || input[i] == '-')
                {

                    while (i < input.Length && (Char.IsDigit(input[i]) || input[i] == '-' || input[i] == '.'))
                    {
                        coordinates.Append(input[i]);
                        i++;
                    }
                }

                if (coordinates.Length > 0)
                {
                    double coord = double.Parse(coordinates.ToString());
                    xyz[xyzIndex] = coord;
                    xyzIndex++;
                    coordinates.Clear();
                }
            }

            return new Point3D(xyz[0], xyz[1], xyz[2]);
        }
    }
}
