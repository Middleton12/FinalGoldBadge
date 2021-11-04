using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Three_Repo
{
    public class Badge
    {
        public int BadgeID { get; set; }

        public List<string> ListOfDoorNames { get; set; } = new List<string>();
        public Badge() { }
        public Badge(int badgeID, List<string> listOfDoorNames)
        {
            BadgeID = badgeID;
            ListOfDoorNames = listOfDoorNames;
        }
    }
}
