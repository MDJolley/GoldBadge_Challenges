using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class Claim : IClaim
    {
        public string Description { get; set; }
        public int ClaimID { get; set; }
        public bool IsValid { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public ClaimType ClaimType { get; set; }

        public Claim() { }
        public Claim(int id, double amount, DateTime incident, DateTime claimDate, string description, ClaimType claimType)
        {
            IsValid = ((claimDate - incident).Days <= 30 ? true : false);
            ClaimID = id;
            DateOfClaim = claimDate;
            DateOfIncident = incident;
            Description = description;
            ClaimAmount = amount;
            ClaimType = claimType;
        }
    }
}
