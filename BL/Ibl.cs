using System;
using System.Collections.Generic;
using BE;

namespace BL
{
    public interface Ibl
    {
        int addMother(Mother m);
        bool removeMother(Mother m);
        List<Mother> getAllMothers(Func<Mother,bool> filter = null);
        int getWalkingDistance(string source, string target,bool withdirections = true);
        int getDrivingDistance(string source, string target, bool withdirections = true);
    }
}