using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolkovConsoleApplication
{
    public class Vehicle
    {
        double x;
        double y;
        double volume;
        double maxVolume;
        double speed;
        double maxSpeed;

        string name;

        public Vehicle()
        {
            x = 0;
            y = 0;
            volume = 0;
            maxVolume = 100;
            speed = 0;
            maxSpeed = 300;
            name = string.Empty;
        }

        public Vehicle(string name, double maxVolume, double maxSpeed)
        {
            x = 0;
            y = 0;
            volume = 0;
            speed = 0;
            this.maxSpeed = maxSpeed;
            this.maxVolume = maxVolume;
            this.name = name;
        }

        public double Volume
        {
            set
            {
                if (value < 0)
                    volume = 0;
                else if (value > maxVolume)
                    volume = maxVolume;
                else
                    volume = value;
            }
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public double MaxVolume
        {
            get { return maxVolume; }
        }

        public double Speed
        {
            set
            {
                if (value < 0)
                    speed = 0;
                else if (value > maxSpeed)
                    speed = maxSpeed;
                else
                    speed = value;
            }
        }

        public double MaxSpeed
        {
            get { return maxSpeed; }
        }

        public virtual void Move(double x, double y)
        {
            this.x = x;
            this.y = y;

            Console.Write("x = ");
            Console.Write(x);
            Console.Write(", y = ");
            Console.Write(y);
            Console.WriteLine();
        }
    }

    public class AirVehicle : Vehicle
    {
        int engines;

        public AirVehicle()
            : base()
        {
            engines = 2;
        }

        public AirVehicle(string name, double maxVolume, int engines, double maxSpeed)
            : base(name, maxVolume, maxSpeed)
        {
            this.engines = engines;
        }

        public int Engines
        {
            get { return engines; }
        }

        public void Fly(double x, double y)
        {
            Console.WriteLine("Fly");
            Move(x, y);
        }
    }

    public class WaterVehicle : Vehicle
    {
        double displacement;
        public WaterVehicle()
            : base()
        {
            displacement = 100;
        }

        public WaterVehicle(string name, double maxVolume,   double displacement, double maxSpeed)
            : base(name, maxVolume, maxSpeed)
        {
            this.displacement = displacement;
        }

        public double Displacement
        {
            get { return displacement; }
        }

        public void Sails(double x, double y)
        {
            Console.WriteLine("Sails");
            Move(x, y);
        }

    }

    public class LandVehicle : Vehicle
    {
        int wheels;

        public LandVehicle()
            : base()
        {
            wheels = 4;
        }

        public LandVehicle(string name, double maxVolume, int wheels,double maxSpeed)
            : base(name, maxVolume, maxSpeed)
        {
            this.wheels = wheels;
        }

        public int Wheels
        {
            get { return wheels; }
        }

        public void Roll(double x, double y)
        {
            Console.WriteLine("Roll");
            Move(x, y);
        }
    }
}
