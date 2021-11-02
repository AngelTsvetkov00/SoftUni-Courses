using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        //length, width,height
        private double _width;
        private double _height;
        private double _length;

        public Box(double width, double height, double length)
        {
            Width = width;
            Height = height;
            Length = length;
        }

        public double Width
        { 
            get => _width;
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                }
                else
                {
                    _width = value;
                }
            }
        }

        public double Height 
        {
            get => _height; 
           private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Height cannot be zero or negative.");
                }
                else
                {
                    _height = value;
                }
            }
        }

        public double Length 
        { 
            get => _length; 
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                }
                else
                {
                    _length = value;
                }
            }
        }

        public void Volume(Box box)
        {
            Console.WriteLine($"Volume - {(box.Length * box.Height * box.Width):f2}");
        }

        public void SurfaceArea(Box box)
        {
            Console.WriteLine($"Surface Area - {(2 * box.Width * box.Height) + (2 * box.Length * box.Width) + (2 * box.Height * box.Length):f2}");
        }

        public void LateralSurfaceArea(Box box)
        {
            Console.WriteLine($"Lateral Surface Area - {(2 * box.Length * box.Height) + (2 * box.Width * box.Height ):f2}");
        }
    }
}
