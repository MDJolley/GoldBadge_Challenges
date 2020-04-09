using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public enum ClaimType { Car, Home, Theft}
    public interface IClaim
    {
        String Description { get; set; }
        int ClaimID { get; set; }
        bool IsValid { get; set; }
        double ClaimAmount { get; set; }
        DateTime DateOfIncident { get; set; }
        DateTime DateOfClaim { get; set; }
        ClaimType ClaimType { get; set; }

    }
}