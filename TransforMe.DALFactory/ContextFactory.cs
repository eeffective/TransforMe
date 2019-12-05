using System;
using TransforMe.DataAccess;
using TransforMe.Interface.Contexts;

namespace TransforMe.DALFactory
{
    public static class ContextFactory
    {
        public static IUserContext CreateUserContext() => new MySqlUserContext();

        public static IMessageContext CreateMessageContext() => new MySqlMessageContext();

        public static IProgressionContext CreateProgressionContext() => new MySqlProgressionContext();

        public static IActivityContext CreateActivityContext() => new MySqlActivityContext();

    }
}
