using System.Collections.Generic;
using BE;

namespace DAL
{
    public interface IDal
    {
        int addMother(Mother m);
        bool removeMother(Mother m);
        IEnumerable<Mother> getAllMothers();
    }
}