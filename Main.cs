namespace Practice2
{
    internal class Program
    {
        static void Main()
        {
           
            City city = new City();
            Console.WriteLine("City created.");

            PoliceStation comisaria = city.GetPoliceStation();
            Console.WriteLine("Police station created within the city.");

            // introducimos taxis a la ciudad
            city.RegisterTaxi("0001 AAA");
            city.RegisterTaxi("0002 BBB");
            city.RegisterTaxi("0003 CCC");

            // introducimos coches de policía (algunos con radar y otros sin radar)
            PoliceCar policeCar1 = new PoliceCar("0001 CNP", comisaria);
            PoliceCar policeCar2 = new PoliceCar("0002 CNP", comisaria);
            PoliceCar policeCar3 = new PoliceCar("0003 CNP", comisaria, null); 

            Console.WriteLine(policeCar1.WriteMessage("Created with radar."));
            Console.WriteLine(policeCar2.WriteMessage("Created with radar."));
            Console.WriteLine(policeCar3.WriteMessage("Created without radar."));

            //se empieza a patrullar
            policeCar1.StartPatrolling();
            policeCar2.StartPatrolling();
            policeCar3.StartPatrolling();

            //  usar el radar en el coche de policía sin radar
            Console.WriteLine("Attempting to use radar on police car without radar.");
            policeCar3.UseRadar(city.GetTaxiByPlate("0001 AAA"));

       
            Taxi taxi2 = city.GetTaxiByPlate("0002 BBB");
            taxi2.StartRide();

            policeCar1.UseRadar(taxi2);

            policeCar1.StartChase(taxi2);

            //  comisaría avisa a otros coches patrullando sobre la persecución
            comisaria.ActivateAlert(taxi2.GetPlate());

            taxi2.StopRide();

            //retiramos la licencia
            city.RegisterTaxi("0002 BBB");

          
            policeCar1.PrintRadarHistory();
            policeCar2.PrintRadarHistory();
            policeCar3.PrintRadarHistory();
        }
    }
}