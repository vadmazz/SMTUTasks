using System.IO;

namespace Task7
{
    public class Tractor
    {
        protected double FuelConsumption; //расход
        public double GetTotalConsumption(double square) =>
            FuelConsumption * square;
    }

    public class SmallTractor : Tractor
    {
        public SmallTractor(string path)
        {
            ReadSmallConsumptionFromFile(path);
        }
        private void ReadSmallConsumptionFromFile(string path) =>
            FuelConsumption = double.Parse(File.ReadAllText(path).Split(' ')[0]);
    }
    
    public class BigTractor : Tractor
    {
        public BigTractor(string path)
        {
            ReadBigConsumptionFromFile(path);
        }
        private void ReadBigConsumptionFromFile(string path) =>
            FuelConsumption = double.Parse(File.ReadAllText(path).Split(' ')[1]);
    }
}