namespace Practice2
{
    class Taxi : Vehicle
    {

        private static string typeOfVehicle = "Taxi";  //static: significa que no puedes cambiar este valor una vez que se ha definido
        private bool isCarryingPassengers;

        public Taxi(string plate) : base(typeOfVehicle, plate)// Llama al constructor de la clase base Vehicle, inicializando los valores de typeOfVehicle y plate en la clase base.
        {

            isCarryingPassengers = false;
            SetSpeed(45.0f);
        }

        public void StartRide()
        {
            if (!isCarryingPassengers)
            {
                isCarryingPassengers = true;
                SetSpeed(100.0f);
                Console.WriteLine(WriteMessage("starts a ride."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already in a ride."));
            }
        }

        public void StopRide()
        {
            if (isCarryingPassengers)
            {
                isCarryingPassengers = false;
                SetSpeed(45.0f);
                Console.WriteLine(WriteMessage("finishes ride."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is not on a ride."));
            }
        }
    }
}