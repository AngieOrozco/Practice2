namespace Practice2
{
    class PoliceStation : IMessageWritter
    {
        //Radar doesn't know about Vechicles, just speed and plates
        private List<PoliceCar> PoliceCars;

        public PoliceStation()
        {
            PoliceCars = new List<PoliceCar>();
        }


        public void Register(PoliceCar policeCar)
        {
            PoliceCars.Add(policeCar);
            Console.WriteLine($"Police car with plate {policeCar.GetPlate()} registered.");
        }


        public void ActivateAlert(string vehiclePlate)
        {
            Console.WriteLine(WriteMessage($"Infringement of the vehicle with plate {vehiclePlate}. Notifying patrolling police cars..."));

            foreach (var policeCar in PoliceCars)
            {
                if (policeCar.IsPatrolling())
                {
                    policeCar.ReceiveAlert(vehiclePlate);
                }
            }
        }

        public virtual string WriteMessage(string message)
        {
            return $"Police Station Statement: {message} ";
        }
    }
}