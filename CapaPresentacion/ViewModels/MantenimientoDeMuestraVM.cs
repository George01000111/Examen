using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;
using InterfacesMuestra.Muestra;
using InterfacesMuestra.Muestra.Peticiones;
using System.Collections.ObjectModel;
using InterfacesMuestra.Muestra.Repuestas;
using System.ComponentModel;

namespace WpfMuestra.ViewModels
{
   public class MantenimientoDeMuestraVM : INotifyPropertyChanged
    {

        private NuevoMuestra _nuevoMuestra = new NuevoMuestra();
        private IGestorMuestra _gestorDeMuestra = new GestorDeMuestra();


        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<MuestraRegistrado> muestraResgistrados
        { get; set; }

        public NuevoMuestra nuevoMuestra
        {
            get { return _nuevoMuestra; }
            set
            {
                this._nuevoMuestra = value;
                this.OnPropertyChanged("nuevoMuestra");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public void GrabarMuestra()
        {
            MuestraRegistrado nuevoTipoNegocioRegistrado = this._gestorDeMuestra.CrearMuestra(this._nuevoMuestra);
            this.muestraResgistrados.Add(nuevoTipoNegocioRegistrado);
            this.nuevoMuestra = new NuevoMuestra();
        }

        public void CargarMuestra()
        {
            this.muestraResgistrados = new ObservableCollection<MuestraRegistrado>();
            _gestorDeMuestra.ListarTodosLosMuestra().ForEach(x => this.muestraResgistrados.Add(x));
        }


    }
}
