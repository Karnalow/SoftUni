using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length
        {
            get { return this.length; }
            set 
            {
                if (value == 0 || value < 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        private double Width
        {
            get { return this.width; }
            set
            {
                if (value == 0 || value < 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        private double Height
        {
            get { return this.height; }
            set
            {
                if (value == 0 || value < 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        private double SurfaceArea()
        {
            // 2lw + 2lh + 2wh

            double surfaceArea = (2 * this.Length * this.Width) +
                (2 * this.Length * this.Height) +
                (2 * this.Width * this.Height);

            return surfaceArea;
        }

        public double LateralSurfaceArea()
        {
            // 2lh + 2wh

            double lateralArea = (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

            return lateralArea;
        }

        public double Volume()
        {
            // lwh

            double volume = this.Length * this.Width * this.Height;

            return volume;
        }

        public override string ToString()
        {
            return $"Surface Area - {SurfaceArea():f2}\n" +
                   $"Lateral Surface Area - {LateralSurfaceArea():f2}\n" +
                   $"Volume - {Volume():f2}";
        }
    }
}
