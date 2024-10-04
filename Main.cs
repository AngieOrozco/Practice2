
namespace Practice2
{
    internal class Program
{
    static void Main()
    {
        // Crear la ciudad y la comisaría
        Ciudad ciudad = new Ciudad();
        PoliceStation comisaria = ciudad.GetComisaria();

        // Registrar taxis en la ciudad
        ciudad.RegistrarTaxi("0001 AAA");
        ciudad.RegistrarTaxi("0002 BBB");

        // Registrar coches de policía en la comisaría
        PoliceCar policeCar1 = new PoliceCar("0001 CNP", comisaria);
        PoliceCar policeCar2 = new PoliceCar("0002 CNP", comisaria);

        // Comenzar patrullaje
        policeCar1.StartPatrolling();
        policeCar1.UseRadar(ciudad.GetTaxiByPlate("0001 AAA")); // Usar radar con un taxi

        // Iniciar una carrera con el taxi2
        Taxi taxi2 = ciudad.GetTaxiByPlate("0002 BBB");
        taxi2.StartRide();

        // Usar radar sin patrullar
        policeCar2.UseRadar(taxi2);

        // Comenzar patrullaje del segundo coche de policía
        policeCar2.StartPatrolling();
        policeCar2.UseRadar(taxi2);

        // El taxi termina su carrera
        taxi2.StopRide();
        policeCar2.EndPatrolling();

        // Iniciar una carrera con el taxi1
        Taxi taxi1 = ciudad.GetTaxiByPlate("0001 AAA");
        taxi1.StartRide();

        // Patrullaje y uso de radar
        policeCar1.UseRadar(taxi1);

        // El taxi termina su carrera
        taxi1.StopRide();

        // Terminar patrullaje
        policeCar1.EndPatrolling();

        // Imprimir el historial del radar de ambos coches de policía
        policeCar1.PrintRadarHistory();
        policeCar2.PrintRadarHistory();
    }
}
}
