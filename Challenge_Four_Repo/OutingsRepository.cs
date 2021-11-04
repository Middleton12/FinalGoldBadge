using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Four_Repo
{

    public class OutingsRepository
    {
        private List<Outings> _listOfOutings = new List<Outings>();

        public void AddEventToList(Outings typeOfEvent)
        {
            _listOfOutings.Add(typeOfEvent);
        }
        public List<Outings> GetEventList()
        {
            return _listOfOutings;
        }
        public Outings GetEventList(EventType type)
        {
            foreach (Outings content in _listOfOutings)
            {
                while (content.TypeOfEvent == type)
                {
                    return content;
                }
            }
            return null;
        }
        public Outings GetEventGolf(EventType Golf)
        {
            foreach (Outings content in _listOfOutings)
            {
                while (content.TypeOfEvent == EventType.Golf)
                {
                    return content;
                }
            }
            return null;
        }
        public Outings GetEventConcert(EventType Concert)
        {
            foreach (Outings content in _listOfOutings)
            {
                while (content.TypeOfEvent == EventType.Concert)
                {
                    return content;
                }
            }
            return null;
        }
        public Outings GetEventBowling(EventType Bowling)
        {
            foreach (Outings content in _listOfOutings)
            {
                while (content.TypeOfEvent == EventType.Bowling)
                {
                    return content;
                }
            }
            return null;
        }
        public Outings GetEventAmusementPark(EventType Amusement_Park)
        {
            foreach (Outings content in _listOfOutings)
            {
                while (content.TypeOfEvent == EventType.Amusement_Park)
                {
                    return content;
                }
            }
            return null;
        }
        public double CalculateTotalCost(int numPeopleAttend, double costPerPerson)
        {
            double totalCostEvent = numPeopleAttend * costPerPerson;
            if (totalCostEvent == 0)
            {
                return 0.00;
            }
            else
            {
                return totalCostEvent;
            }
        }
        public double TotalCostByEventType()
        {
            var totalGolf = 0.00;
            var totalBowling = 0.00;
            var totalAmusementPark = 0.00;
            var totalConcert = 0.00;
            var totalOther = 0.00;

            foreach (Outings content in _listOfOutings)
            {
                if (content.TypeOfEvent == EventType.Golf)
                {
                    totalGolf = totalGolf + content.TotalCostEvent;
                }
                else if (content.TypeOfEvent == EventType.Amusement_Park)
                {
                    totalAmusementPark += content.TotalCostEvent;
                }
                else if (content.TypeOfEvent == EventType.Concert)
                {
                    totalConcert += content.TotalCostEvent;
                }
                else if (content.TypeOfEvent == EventType.Other)
                {
                    totalOther += content.TotalCostEvent;
                }
                else
                {
                    totalBowling += content.TotalCostEvent;
                }
            }
            return 0.00;
        }
    }

}
