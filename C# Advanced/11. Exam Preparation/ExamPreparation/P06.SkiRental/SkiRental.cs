using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            data = new List<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count 
        {
            get
            {
                return data.Count;
            }
        }

        public void Add(Ski ski)
        {
            if (this.Capacity > 0)
            {
                data.Add(ski);

                Capacity--;
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            foreach (var ski in data)
            {
                if (ski.Manufacturer == manufacturer &&
                    ski.Model == model)
                {
                    data.Remove(ski);
                    Capacity++;

                    return true;
                }
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            int newestSki = 0;

            if (Capacity > 0)
            {
                foreach (var ski in data)
                {
                    if (newestSki < ski.Year)
                    {
                        newestSki = ski.Year;
                    }
                }

                return data.Find(x => x.Year == newestSki);
            }

            return null;
        }

        public Ski GetSki(string manufacturer, string model)
            => data.Find(x => x.Manufacturer == manufacturer && x.Model == model);

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {this.Name}:");

            foreach (var ski in data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
