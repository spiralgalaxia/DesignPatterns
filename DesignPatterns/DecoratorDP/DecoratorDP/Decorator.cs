using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    //Our original Vehicle class which needs to be decorated so that it can perform additional operations
    //For example, in this tutorial, Vehicle class is being used to add a method for maximum turning radius
    //without modifying the original vehicle class.
    /*
    public class Vehicle
    {
        public void MaxSpeedAllowed()
        {
            Console.WriteLine("Maximum speed allowed for any vehicle is 200 mphr");
        }
    }
    */

    //Decorator pattern changes start
    //In order to implement decorator pattern, we need to make Vehicle inherit from an Interface called IVehicle
    public class Vehicle : IVehicle
    {
        public void MaxSpeedAllowed()
        {
            Console.WriteLine("Maximum speed allowed for any vehicle is 200 mphr");
        }
    }

    //Declare an interface IVehicle and define a contract method MaxSpeedAllowed()
    public interface IVehicle
    {
        void MaxSpeedAllowed();
    }

    //Create a Decorator class which needs to be an abstract class so that no one can accidently instantiate it.
    public abstract class Decorator : IVehicle
    {
        private IVehicle _vehicle;

        public Decorator(IVehicle veh)
        {
            _vehicle = veh;
        }

        public virtual void MaxSpeedAllowed()
        {
            _vehicle.MaxSpeedAllowed();
        }
    }

    //Our Decorated Class
    //This will be our decorated class which will implement additional functionality
    public class Bmw : Decorator
    {
        public Bmw(IVehicle veh) : base(veh)
        {
        }

        //Overrided Method
        public override void MaxSpeedAllowed()
        {
            base.MaxSpeedAllowed();
            Console.WriteLine("Maximum speed for BMW is 150 mphr");
        }
        //Additional Method
        public void MaxTurningRadius()
        {
            Console.WriteLine("Maximum turning radius for BMW is 10 m");
        }
    }

    //Usage of decorator pattern
    class Program
    {
        static void Main(string[] args)
        {

            //Instantiate original class and pass instance into our decorated class
            Vehicle vehicle = new Vehicle();

            //Decorated class
            Bmw bmw = new Bmw(vehicle);

            //Call desired methods
            bmw.MaxSpeedAllowed();
            bmw.MaxTurningRadius();

            Console.ReadLine();
        }
    }



}
