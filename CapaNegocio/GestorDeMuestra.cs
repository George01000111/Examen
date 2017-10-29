using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using InterfacesMuestra.Muestra.Peticiones;
using InterfacesMuestra.Muestra.Repuestas;
using InterfacesMuestra.Muestra;



namespace CapaNegocio
{
   public class GestorDeMuestra : IGestorMuestra
    {
        public MuestraRegistrado CrearMuestra(NuevoMuestra nuevoMuestra)
        {
            using (BDEXAMENEntities Bd = new BDEXAMENEntities())
            {
                TbMuestra tbmuestra = new TbMuestra();
                tbmuestra.Id = nuevoMuestra.Id;
                tbmuestra.Nombre= nuevoMuestra.Nombre;
                tbmuestra.fecha =Convert.ToDateTime("29/10/2017");
                tbmuestra.NombrePersona = nuevoMuestra.NombrePersona;
                Bd.TbMuestras.Add(tbmuestra);
                Bd.SaveChanges();
                return ConvertirMuestraA_DTO(tbmuestra);
            }
        }

        public List<MuestraRegistrado> ListarTodosLosMuestra()
        {
            using (BDEXAMENEntities Bd = new BDEXAMENEntities())
            {
                return Bd.TbMuestras.ToList().Select(x => ConvertirMuestraA_DTO(x)).ToList();
            }
        }


        private MuestraRegistrado ConvertirMuestraA_DTO(TbMuestra tmuestra)
        {
            MuestraRegistrado tmuestraregistrado = new MuestraRegistrado();
            tmuestraregistrado.Id = tmuestra.Id;
            tmuestraregistrado.Nombre = tmuestra.Nombre;
            tmuestraregistrado.fecha = tmuestra.fecha;
            tmuestraregistrado.NombrePersona = tmuestra.NombrePersona;

            return tmuestraregistrado;
        }

    }
}
