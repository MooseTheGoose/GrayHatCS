using System;

namespace Society
{

    class GettingStarted
    {
        static void Main(string[] args)
        {
            Firefighter firefighter = new Firefighter("Joe Carrington", 35);
            firefighter.PensionAmount = 5000;

            PrintNameAndAge(firefighter);
            PrintPensionAmont(firefighter);

            firefighter.DriveToPlaceOfInterest();

            PoliceOfficer officer = new PoliceOfficer("Jane Hope", 32, false);
            officer.PensionAmount = 5500;

            PrintNameAndAge(officer);
            PrintPensionAmont(officer);

            officer.DriveToPlaceOfInterest();

            officer = new PoliceOfficer("John Valor", 32, true);
            PrintNameAndAge(officer);
            officer.DriveToPlaceOfInterest();

        }

        static void PrintNameAndAge(IPerson person)
        {
            Console.WriteLine("Name: " + person.Name);
            Console.WriteLine("Age: " + person.Age);
        }

        static void PrintPensionAmont(PublicServant servant)
        {
          if (servant is Firefighter)
            { Console.WriteLine("Pension of firefighter: " + servant.PensionAmount); }
          else if (servant is PoliceOfficer)
            { Console.WriteLine("Pension of officer: " + servant.PensionAmount); }
        }
    }

    public abstract class PublicServant
    {
        public int PensionAmount { get; set; }
        public delegate void DriveToPlaceOfInterestDelegate();
        public DriveToPlaceOfInterestDelegate DriveToPlaceOfInterest { get; set; } 
    }

    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
    }

    public class Firefighter : PublicServant, IPerson
    {
        public Firefighter(string name, int age)
        {
            this.Name = name;
            this.Age = age;

            this.DriveToPlaceOfInterest += delegate
            {
                Console.WriteLine("Driving the firetruck");
                TurnOnSiren();
                FollowDirections();
            };

        }

       public string Name { get; set; }
       public int Age { get; set; }

        private void GetInFiretruck(){}
        private void TurnOnSiren(){}
        private void FollowDirections(){}

    }

    public class PoliceOfficer : PublicServant, IPerson
    {

        public PoliceOfficer(string name, int age, bool hasEmergency)
        {
            this.Name = name;
            this.Age = age;
            this.HasEmergency = hasEmergency;

            if(this.HasEmergency)
            {
                this.DriveToPlaceOfInterest += delegate
                {
                    Console.WriteLine("Driving the police car With siren");
                    GetInPoliceCar();
                    TurnOnSiren();
                    FollowDirections();
                };
            }
            else
            {
                this.DriveToPlaceOfInterest += delegate
                {
                    Console.WriteLine("Driving the police car");
                    GetInPoliceCar();
                    FollowDirections();
                };
            }
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public bool HasEmergency{ get; set; }

        private void GetInPoliceCar(){}
        private void TurnOnSiren(){}
        private void FollowDirections(){}
    }

}