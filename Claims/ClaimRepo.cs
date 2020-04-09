using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class ClaimRepo
    {
        protected readonly Queue<Claim> _ClaimQueue = new Queue<Claim>();
        public void Add(Claim claim) => _ClaimQueue.Enqueue(claim);

        public bool NewClaim(double amount, DateTime incident, DateTime claimDate, string description, ClaimType claimType)
        {
            int id = _ClaimQueue.Count + 1;
            Claim newClaim = new Claim(id, amount, incident, claimDate, description, claimType);
            int startingCount = _ClaimQueue.Count;
            _ClaimQueue.Enqueue(newClaim);
            bool success = _ClaimQueue.Count > startingCount ? true : false;
            return success;
        }

        public bool NewClaim(Claim claim)
        {
            int startingCount = _ClaimQueue.Count;
            _ClaimQueue.Enqueue(claim);
            bool success = _ClaimQueue.Count > startingCount ? true : false;
            return success;
        }

        public List<Claim> GetClaims()
        {
            List<Claim> allClaims = new List<Claim>();
            foreach (Claim claim in _ClaimQueue)
            {
                allClaims.Add(claim);
            }
            return allClaims;
        }

        public Claim Next() => _ClaimQueue.Peek();
        public bool Dealt()
        {
            int startingCount = _ClaimQueue.Count;
            _ClaimQueue.Dequeue();
            bool success = _ClaimQueue.Count < startingCount ? true : false;
            return success;
        }
    }

}

