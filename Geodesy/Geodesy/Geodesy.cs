using System;

namespace Geodesy
{
    public static class Geodesy
    {
        public static Point StraightLinear(Point point, Angle dir, double d)
        {
            double dx = d * Math.Cos(dir.ToRad());
            double dy = d * Math.Sin(dir.ToRad());

            return new Point(point.X + dx, point.Y + dy);
        }

        public static Directional ReversedLinear(Point a, Point b)
        {
            double dx = b.X - a.X;
            double dy = b.Y - a.Y;

            double rumba = Math.Atan(Math.Abs(dy / dx)) * 180.0 / Math.PI;

            Directional dir;
            if (dx <= 0 && dy >= 0)
            {
                dir = new Directional(180 - rumba);
            }
            else if (dx <= 0 && dy <= 0)
            {
                dir = new Directional(180 + rumba);
            }
            else
            {
                dir = new Directional(360 - rumba);
            }

            dir.D = Math.Sqrt(dx * dx + dy * dy);
            
            return dir;
        }
        
        public static Point StraightAngular(Point a, Angle alpha, Point b, Angle beta)
        {
            double x = (a.X * ctg(beta) + b.X * ctg(alpha) + b.Y - a.Y) / (ctg(alpha) + ctg(beta));
            double y = (a.Y * ctg(beta) + b.Y * ctg(alpha) - b.X + a.X) / (ctg(alpha) + ctg(beta));
            
            return new Point(x, y);
        }

        public static Point ReversedAngular(Point a, Point b, Point c, Angle alpha, Angle beta)
        {
            double ctgGamma = ((b.Y - a.Y) * ctg(alpha) - (c.Y - b.Y) * ctg(beta) + (a.X - c.X))
                              / ((b.X - a.X) * ctg(alpha) - (c.X - b.X) * ctg(beta) - (a.Y - c.Y));
            double z1 = (b.Y - a.Y) * (ctg(alpha) - ctgGamma) - (b.X - a.X) * (1.0 + ctg(alpha) * ctgGamma);
            double z2 = (c.Y - b.Y) * (ctg(beta) + ctgGamma) + (c.X - b.X) * (1.0 - ctg(beta) * ctgGamma);
            double z = (z1 + z2) / 2;

            double dx = z / (1 + ctgGamma * ctgGamma);
            double dy = dx * ctgGamma;

            return new Point(b.X + dx, b.Y + dy);
        }

        private static double ctg(double rad) => 1.0 / Math.Tan(rad);

        private static double ctg(Angle angle) => 1.0 / Math.Tan(angle.ToRad());
    }
}