using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Two_Repo
{
    public class ClaimsRepo
    {
        private readonly Queue<Claims> _claimsQueue = new Queue<Claims>();

        //Create Add a new Claim to the Queue                 
        public void AddNewClaimToQueue(Claims newContent)
        {
            _claimsQueue.Enqueue(newContent);
        }
        //Read - Display the Claims Queue
        public Queue<Claims> DisplayClaimsQueue()
        {
            return _claimsQueue;
        }
        // Look at Claim in queue and return to queue
        public Queue<Claims> ViewAnItemInQueue(Claims content)
        {
            _claimsQueue.Peek();
            return null;

        }
    }
}

