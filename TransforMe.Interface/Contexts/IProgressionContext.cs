using System;
using System.Collections.Generic;
using System.Text;

namespace TransforMe.Interface.Contexts
{
    public interface IProgressionContext
    {
        IProgression Get(int id);
        IEnumerable<IProgression> GetAll();
        IEnumerable<IProgression> GetAll(int userId);
        IEnumerable<IProgression> GetAllFromFollowings(int userId);
        bool Create(IProgression progression, int userId);
        bool Delete(int id);
    }
}
