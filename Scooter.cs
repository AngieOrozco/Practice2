namespace Practice2
{
    class Scooter : Vehicle
    {
        private static string typeOfVehicle = "Scooter";

        public Scooter() : base(typeOfVehicle, "")
        {
            SetSpeed(20.0f);  // velocidad inicial
        }

        public override string WriteMessage(string message)
        {
            return $"{typeOfVehicle}: {message}";
        }


    }
}