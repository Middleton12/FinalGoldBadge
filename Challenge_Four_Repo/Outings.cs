using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Four_Repo
{


    public enum EventType
    {
        Golf = 1,
        Bowling,
        Amusement_Park,
        Concert,
        Other
    }
    public class Outings
    {
        public int NumPeopleAttend { get; set; }
        public DateTime DateOfEvent { get; set; }
        public double CostPerPerson { get; set; }
        public EventType TypeOfEvent { get; set; }
        public double TotalCostEvent { get; set; }
        public Outings() { }
        public Outings(EventType type, DateTime dateOfEvent, int numPeopleAttend, double costPerPerson, double totalCostEvent)
        {
            NumPeopleAttend = numPeopleAttend;
            DateOfEvent = dateOfEvent;
            NumPeopleAttend = numPeopleAttend;
            CostPerPerson = costPerPerson;
            TotalCostEvent = totalCostEvent;
            TypeOfEvent = type;
        }
    }

}
