using StockManagementSystemApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.BLL
{
    public class UserManger
    {
        UserLoginGateWay userlogingateway = new UserLoginGateWay();
        public bool UserIsExicted(string username, string password)
        {
            return userlogingateway.userExitedCheaked(username, password);
        }
    }
}