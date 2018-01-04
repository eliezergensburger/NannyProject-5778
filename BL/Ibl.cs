using System;
using System.Collections.Generic;
using BE;

namespace BL
{
    public interface Ibl
    {
        int addMother(Mother m);
        int addContract(Contract c);
        List<Mother> getAllMothers(Func<Mother, bool> filter = null);
        List<Contract> getAllContracts(Func<Contract,bool> filter = null);
        int getWalkingDistance(string source, string target,bool withdirections = true);
        int getDrivingDistance(string source, string target, bool withdirections = true);
        bool removeMother(Mother m);
    }
}