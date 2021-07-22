using System;

namespace Geodesy
{
    public class Angle
    {
        public int Deg;
        public uint Min;
        public uint Sec;

        public Angle(int deg, uint min, uint sec)
        {
            Deg = deg;
            Min = min;
            Sec = sec;
        }

        public Angle(double degrees)
        {
            Deg = (int) Math.Floor(degrees);
            Min = (uint) ((degrees - Deg) * 60);
            Sec = (uint) ((((degrees - Deg) * 60) - Min) * 60);
        }

        protected Angle()
        {
            Deg = 0;
            Min = 0;
            Sec = 0;
        }

        public double ToGrad() 
            => Deg + Min / 60.0 + Sec / 3600.0;

        public double ToRad() 
            => ToGrad() * Math.PI / 180.0;
    }

    public class Directional : Angle
    {
        public double D;
        
        public Directional(int deg, uint min, uint sec, double d = 0) : base(deg, min, sec)
        {
            D = d;
        }

        public Directional(Angle angle, double d = 0)
        {
            Deg = angle.Deg;
            Min = angle.Min;
            Sec = angle.Sec;
            D = d;
        }

        public Directional(double degrees) : base(degrees) {}
    }
}