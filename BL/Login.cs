using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Login
    {
        public static bool CheckUser(string userName, string password)
        {
            bool autorice = false;

            using (DL.DRosasBackEndAeroMexicoEntities context = new DL.DRosasBackEndAeroMexicoEntities())
            {
                var query = context.UsuarioGetByUserName(userName, password).FirstOrDefault();

                if (query != null)
                {
                    autorice = true;
                }
            }
            return autorice;
        }
    }
}
