using System;

namespace Geodesy
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      Point x = new Point(1, 2);
      Point y = new Point(3, 4);
      Point z = new Point(5, 6);
      Angle alpha = new Angle(7, 8, 9);
      Angle beta = new Angle(10, 11, 12);
      
      var test = Geodesy.ReversedAngular(x, y, z, alpha, beta);
    }
  }
}