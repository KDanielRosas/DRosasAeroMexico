using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pasajero
    {
        public static bool Add(ML.Pasajero pasajero)
        {
            bool result = false;
            if (pasajero.Nombre != "" && pasajero.ApellidoPaterno != "" && pasajero.ApellidoMaterno != "")
            {
                using (DRosasBackEndAeroMexicoEntities context = new DRosasBackEndAeroMexicoEntities())
                {
                    int query = context.PasajeroAdd(pasajero.Nombre, pasajero.ApellidoPaterno, pasajero.ApellidoMaterno);

                    if (query > 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}
