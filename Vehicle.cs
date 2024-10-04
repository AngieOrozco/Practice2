
namespace Practice2
{
    abstract class Vehicle : IMessageWritter
    {
        private string typeOfVehicle;
        private string plate;
        private float speed;

        public Vehicle(string typeOfVehicle, string plate)
        {
            this.typeOfVehicle = typeOfVehicle;
            this.plate = plate;
            speed = 0f;
        }

        //Override ToString() method with class information

        public override string ToString()// esto es lo qeu aparecerá cunado hagamos (this)
        {
            if (plate == null || plate == "")
            {
                return GetTypeOfVehicle();
            }
            else
            {
                return GetTypeOfVehicle() + " with plate " + GetPlate();
            }
        }


        public string GetTypeOfVehicle()
        {
            return typeOfVehicle;
        }

        public string GetPlate()
        {
            return plate;
        }


        public float GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(float speed) //void no devuelve nada ---> NO RETURN
        {
            this.speed = speed;
        }

        //Implment interface with Vechicle message structure
        public virtual string WriteMessage(string message)
        {
            return $"{this}: {message}"; //proporciona su propia versión del método WriteMessage
        }
    }

}