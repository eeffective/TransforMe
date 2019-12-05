using System;
using System.Collections.Generic;
using System.Text;

namespace TransforMe.Interface.Contexts
{
    public interface IActivityContext
    {
        IActivity Get(int id);
        IEnumerable<IActivity> GetAll();
        IEnumerable<IActivity> GetAll(int userId);
        IEnumerable<IActivity> GetAll(string username);
        bool Create(IActivity activity, int userId);
    }
}
