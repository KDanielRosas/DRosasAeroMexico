using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Vuelo
    {
        public static List<object> GetVuelo(string fechaInicio, string fechaFin) 
        {
            var vuelos = new List<object>();
            using (DRosasBackEndAeroMexicoEntities context = new DRosasBackEndAeroMexicoEntities())
            {
                var query = context.GetVuelos(fechaInicio,fechaFin).ToList();

                if (query != null)
                {                     
                    foreach (var item in query)
                    {
                        ML.Vuelo v = new ML.Vuelo();
                        v.NumeroVuelo = item.NumeroVuelo;
                        v.Origen = item.Origen;
                        v.Destino = item.Destino;
                        v.FechaSalida = item.FechaSalida.Value.ToString("yyyy/MM/dd hh:mm:ss");

                        vuelos.Add(v);
                    }
                }
            }
            return vuelos; 
        }//GetVuelo

        public static bool AddVueloReservado(int idUsuario,int idVuelo)
        {
            bool result = false;
            using (DRosasBackEndAeroMexicoEntities context = new DRosasBackEndAeroMexicoEntities())
            {
                int query = context.VuelosReservadosAdd(idUsuario, idVuelo);

                if (query > 0)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
