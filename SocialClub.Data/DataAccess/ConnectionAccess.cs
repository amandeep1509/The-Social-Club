using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SocialClub.Data.DataAccess
{
    public class ConnectionAccess
    {
        protected string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["SocialClubDBConnection"].ToString();
            }
        }
    }
}
