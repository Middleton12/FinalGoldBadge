using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Three_Repo
{
    public class BadgeRepo
    {
        public Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();
        public List<string> _listOfDoorNames = new List<string>();

        //Create new badge
        public void CreateANewBadge(Badge badge)
        {
            _badgeDictionary.Add(badge.BadgeID, badge);
        }
        // Show a list of the Dictionary
        public Dictionary<int, Badge> ShowBadgeDictionary()
        {
            return _badgeDictionary;
        }
        //Update all doors on existing badge
        public Badge AddDoorsOnBadge(string doorName)
        {
            foreach (KeyValuePair<int, Badge> item in _badgeDictionary)
            {
                item.Value.ListOfDoorNames.Add(doorName);
            }

            return null;
        }
        //Delete all doors from existing badge
        public Badge DeleteDoorFromBadge(string doorName)
        {
            foreach (KeyValuePair<int, Badge> item in _badgeDictionary)
            {
                item.Value.ListOfDoorNames.Remove(doorName);
            }

            return null;
        }
        //Helper method
        public Badge GetBadge(int upDate)
        {
            if (_badgeDictionary.ContainsKey(upDate))
            {
                return _badgeDictionary[upDate];
            }
            return null;

        }
        public Badge GetBadgeById(int id)
        {
            Badge badge = new Badge();
            foreach (Badge item in _badgeDictionary.Values)
            {
                if (item.BadgeID == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}

