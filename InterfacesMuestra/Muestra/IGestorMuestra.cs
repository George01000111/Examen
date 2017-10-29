using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesMuestra.Muestra.Repuestas;
using InterfacesMuestra.Muestra.Peticiones;



namespace InterfacesMuestra.Muestra
{
   public interface IGestorMuestra
    {

        MuestraRegistrado CrearMuestra(NuevoMuestra nuevoMuestra);
        List<MuestraRegistrado> ListarTodosLosMuestra();

    }
}
