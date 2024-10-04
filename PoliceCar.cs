namespace Practice2

{
    class PoliceCar : Vehicle
    {
        //añado aqui mis cosas extra

        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;
        private bool isChasing; //está persiguiendo?
        private Vehicle vehicleBeingChased;
        private PoliceStation police_station;//para que pueda interactuar con la comisaría
        private SpeedRadar speedRadar;

        public PoliceCar(string plate, PoliceStation police_station) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            isChasing = false;
            speedRadar = new SpeedRadar();
            this.police_station = police_station;  // Asignar la referencia a la comisaría
            police_station.Register(this);  // Registrar el coche de policía en la comisaría
        }

        public void UseRadar(Vehicle vehicle)
        {
            if (isPatrolling)
            {
                speedRadar.TriggerRadar(vehicle);
                string meassurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                if (vehicle.GetSpeed() > 50.0f) //  límite legal 
                {
                    police_station.ActivateAlert(vehicle.GetPlate());  // Activar la alerta en la comisaría, enviando la placa
                    StartChase(vehicle); // Iniciar persecución si excede la velocidad
                }
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }




        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public bool IsChasing()
        {
            return isChasing;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }


        public void StartChase(Vehicle vehicle)
        {
            if (!isChasing)
            {
                isChasing = true;
                vehicleBeingChased = vehicle;
                Console.WriteLine(WriteMessage($"started chasing vehicle with plate {vehicleBeingChased.GetPlate()}."));
            }
            else
            {
                Console.WriteLine(WriteMessage($"is already chasing a vehicle."));
            }
        }

        public void StopChase()
        {
            if (isChasing)
            {
                isChasing = false;
                Console.WriteLine(WriteMessage($"stopped chasing vehicle with plate {vehicleBeingChased.GetPlate()}."));
                vehicleBeingChased = null; // Deja de perseguir cualquier vehículo
            }
            else
            {
                Console.WriteLine(WriteMessage("was not chasing any vehicle."));
            }
        }

        public void ReceiveAlert(string vehiclePlate)
        {
            Console.WriteLine(WriteMessage($"received alert about vehicle with plate {vehiclePlate}."));
        }

        public void PrintRadarHistory()
        {
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            foreach (float speed in speedRadar.SpeedHistory) //foreach
            {
                Console.WriteLine(speed);
            }
        }
    }
}