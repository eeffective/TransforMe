using System;
using System.Collections.Generic;
using System.Text;

namespace TransforMe.Interface.Contexts
{
    public interface IMessageContext
    {
        IMessage Get(int id);
        IEnumerable<IMessage> GetAll();
        IEnumerable<IMessage> GetAllByUserId(int userId);
        IEnumerable<IMessage> GetAllFromFollowings(int userId);
        IEnumerable<IMessage> GetAllFromFollowings(string username);
        IEnumerable<IMessage> GetAllByUsername(string username);
        bool Create(IMessage message, int userId);
        bool Delete(int id);
    }
}
