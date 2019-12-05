using System;
using TransforMe.BusinessLogic;
using TransforMe.BusinessLogic.Logics;
using TransforMe.Interface.Logics;

namespace TransforMe.BLLFactory
{
    public static class LogicFactory
    {
        public static IUserLogic CreateUserLogic() => new UserLogic();
        public static IAdminLogic CreateAdminLogic() => new AdminLogic();
    }
}
