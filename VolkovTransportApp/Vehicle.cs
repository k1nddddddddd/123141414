using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VolkovTransportApp
{
    public enum VehicleTypes
    {
        AirVehicle,
        WaterVehicle,
        LandVehicle,
        Unknown
    }

    public class Vehicle
    {
        double x;
        double y;
        double volume;
        double maxVolume;

        string name;

        public Vehicle()
        {
            x = 0;
            y = 0;
            volume = 0;
            maxVolume = 100;
            name = string.Empty;
        }

        public Vehicle(string name, double maxVolume)
        {
            x = 0;
            y = 0;
            volume = 0;
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
            get { return volume; }
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

        public virtual void Move(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return name;
        }

        public virtual VehicleTypes VehicleType
        {
            get { return VehicleTypes.Unknown; }
        }

        public virtual string GetDataString()
        {
            return string.Empty;
        }

        public double X
        {
            set { x = value; }
            get { return x; }
        }
        public double Y
        {
            set { y = value; }
            get { return y; }
        }
        public static int SortAZ(Vehicle a, Vehicle b)
        {
            return a.name.CompareTo(b.name);
        }

        public static int SortZA(Vehicle a, Vehicle b)
        {
            return b.name.CompareTo(a.name);
        }

        public static Vehicle FromString(string text)
        {
            Vehicle v = null;
            if (string.IsNullOrEmpty(text) ||
                string.IsNullOrWhiteSpace(text))
                return v;

            char[] del = { ';' };
            string[] sub = text.Split(del);
            if (sub.Length < 7)
                return v;
            // значения
            int type;
            if (!int.TryParse(sub[0], out type))
                return v;

            double maxVolume;
            if (!double.TryParse(sub[2], out maxVolume))
                return v;

            double volume;
            if (!double.TryParse(sub[3], out volume))
                return v;

            double x;
            if (!double.TryParse(sub[4], out x))
                return v;

            double y;
            if (!double.TryParse(sub[5], out y))
                return v;

            double fValue;
            int iValue;

            switch (type)
            {
                case 0: // воздушный транспорт
                    if (int.TryParse(sub[6], out iValue))
                    {
                        AirVehicle a = new AirVehicle(
                            sub[1], maxVolume, iValue);
                        a.volume = volume;
                        a.x = x;
                        a.y = y;
                        v = a;
                    }
                    break;
                case 1: // водный транспорт
                    if (double.TryParse(sub[6], out fValue))
                    {
                        WaterVehicle w = new WaterVehicle(
                            sub[1], maxVolume, fValue);
                        w.volume = volume;
                        w.x = x;
                        w.y = y;
                        v = w;
                    }
                    break;
                case 2: // наземный транспорт
                    if (int.TryParse(sub[6], out iValue))
                    {
                        LandVehicle l = new LandVehicle(
                            sub[1], maxVolume, iValue);
                        l.volume = volume;
                        l.x = x;
                        l.y = y;
                        v = l;
                    }
                    break;
            }
            return v;
        }

        public static bool SaveFile(string fileName,
            List<Vehicle> vehicles)
        {
            bool success = false;
            if (string.IsNullOrEmpty(fileName) ||
                string.IsNullOrWhiteSpace(fileName) ||
                vehicles == null || vehicles.Count == 0)
                return success;

            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(fileName, false,
                    Encoding.Default);

                foreach (Vehicle v in vehicles)
                    writer.WriteLine(v.GetDataString());// сохранить в файле

                writer.Close();
                success = true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    ex.Message, "Ошибка при сохранении файла");
            }
            finally
            {
                if (writer != null)
                    writer.Dispose();
            }


            return success;
        }

        public static bool ReadFile(string fileName,
            List<Vehicle> vehicles)
        {
            bool success = false;
            if (string.IsNullOrEmpty(fileName) ||
                string.IsNullOrWhiteSpace(fileName) ||
                vehicles == null)
                return success;

            // очистить список
            vehicles.Clear();

            StreamReader reader = null;

            try
            {
                reader = new StreamReader(fileName,
                    Encoding.Default);
                string str;
                Vehicle v = null;
                while (!reader.EndOfStream)
                {
                    str = reader.ReadLine();

                    v = FromString(str);
                    if (v != null)
                        vehicles.Add(v);
                }

                reader.Close();

                success = true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    ex.Message, "Ошибка при чтении файла");
            }
            finally
            {
                if (reader != null)
                    reader.Dispose();
            }

            return success;
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

        public AirVehicle(string name, double maxVolume, int engines)
            : base(name, maxVolume)
        {
            this.engines = engines;
        }

        public int Engines
        {
            get { return engines; }
        }

        public void Fly(double x, double y)
        {
            Move(x, y);
        }

        public override VehicleTypes VehicleType
        {
            get { return VehicleTypes.AirVehicle; }
        }

        public override string GetDataString()
        {
            string format = "0;{0};{1};{2};{3};{4};{5}";
            return string.Format(format, Name, MaxVolume, Volume,
                X, Y, Engines);
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

        public WaterVehicle(string name, double maxVolume,
            double displacement)
            : base(name, maxVolume)
        {
            this.displacement = displacement;
        }

        public double Displacement
        {
            get { return displacement; }
        }

        public void Sails(double x, double y)
        {
            Move(x, y);
        }
        public override VehicleTypes VehicleType
        {
            get { return VehicleTypes.WaterVehicle; }
        }
        public override string GetDataString()
        {
            string format = "1;{0};{1};{2};{3};{4};{5}";
            return string.Format(format, Name, MaxVolume, Volume,
                X, Y, Displacement);
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

        public LandVehicle(string name, double maxVolume,
            int wheels)
            : base(name, maxVolume)
        {
            this.wheels = wheels;
        }

        public int Wheels
        {
            get { return wheels; }
        }

        public void Roll(double x, double y)
        {
            Move(x, y);
        }
        public override VehicleTypes VehicleType
        {
            get { return VehicleTypes.LandVehicle; }
        }

        public override string GetDataString()
        {
            string format = "2;{0};{1};{2};{3};{4};{5}";
            return string.Format(format, Name, MaxVolume, Volume,
                X, Y, Wheels);
        }
    }
}
