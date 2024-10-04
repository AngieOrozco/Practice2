
namespace Practice2
{
    class City
    {
        private List<Taxi> taxis;   // Lista de taxis
        private PoliceStation police_station; // Comisaría de policía

        public City()
        {
            taxis = new List<Taxi>();
            police_station = new PoliceStation(); // Inicializar la comisaría
        }

        // Métodos para gestionar taxis
        public void RegisterTaxi(string plate)
        {
            Taxi newTaxi = new Taxi(plate);
            taxis.Add(newTaxi);
            Console.WriteLine($"Taxi with plate {plate} registered in the city.");
        }

        public void RemoveTaxi(string plate)
        {
            Taxi taxiToRemove = taxis.Find(t => t.GetPlate() == plate);
            if (taxiToRemove != null)
            {
                taxis.Remove(taxiToRemove);
                Console.WriteLine($"Taxi with plate {plate} removed from the city.");
            }
            else
            {
                Console.WriteLine($"Taxi with plate {plate} not found.");
            }
        }


        public Taxi GetTaxiByPlate(string plate)
        {
            Taxi taxiWanted = taxis.Find(t => t.GetPlate() == plate);
            if (taxiWanted != null)
            {
                return taxiWanted;

            }
            else
            {
                Console.WriteLine($"Taxi with plate {plate} not found.");
                return null;
            }
        }

        // Obtener la comisaría para otras operaciones si es necesario
        public PoliceStation GetPoliceStation()
        {
            return police_station;
        }
    }
}

