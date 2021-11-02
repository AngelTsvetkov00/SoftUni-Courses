using System;

namespace ClassBoxData
{
    public class Program
    {
        static void Main(string[] args)
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            Box box = new Box(width, height, length);

            if (length >= 0 && width >= 0 && height >= 0)
            {
                box.SurfaceArea(box);
                box.LateralSurfaceArea(box);
                box.Volume(box);
            }
        }
    }
}
