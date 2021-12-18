using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TareaMVVM.Views;
using Xamarin.Forms;

namespace TareaMVVM.ViewModels
{
    public class EmpleadosViewModels : BaseViewModel
    {

        private int _id;
        private string _nombre;
        private string _apellido;
        private string _edad;
        private string _direccion;
        private string _puesto;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; OnPropertyChanged(); }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; OnPropertyChanged(); }
        }

        public string Edad
        {
            get { return _edad; }
            set { _edad = value; OnPropertyChanged(); }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; OnPropertyChanged(); }
        }

        public string Puesto
        {
            get { return _puesto; }
            set { _puesto = value; OnPropertyChanged(); }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }

        //lista de comandos a utilizar en pantalla
        public ICommand PantallaListadoCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public ICommand ModificarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }

        //acciones ICommand 
        public async void listado()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ViewListadoEmpleado());
            /*
            Nombre = String.Empty;
            Edad = String.Empty;
            Apellido = String.Empty;
            Edad = String.Empty;
            Direccion = String.Empty;
            Puesto = String.Empty;
            */

        }

        public async void modificar()
        {
            var emp = new Models.Empleados
            {
                id = ID,
                nombre = Nombre,
                apellido = Apellido,
                edad = Edad,
                direccion = Direccion,
                puesto = Puesto
            };

            var resultado = await App.BaseDatos.GrabarEmpleado(emp);

            if (resultado == 1)
            {
                await Application.Current.MainPage.DisplayAlert("Advertencia", "Registro Modificado", "OK");

                await Application.Current.MainPage.Navigation.PushAsync(new ViewListadoEmpleado());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Advertencia", "No se pudo Modificar", "OK");
            }
           
        }

        public async void Eliminar()
        {
            var emp = new Models.Empleados
            {
                id = ID,
                nombre = Nombre,
                apellido = Apellido,
                edad = Edad,
                direccion = Direccion,
                puesto = Puesto
            };

            var resultado = await App.BaseDatos.EliminarEmpleado(emp);

            if (resultado == 1)
            {
                await Application.Current.MainPage.DisplayAlert("Advertencia", "Registro eliminado", "OK");

                await Application.Current.MainPage.Navigation.PushAsync(new ViewListadoEmpleado());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Advertencia", "No se pudo eliminar", "OK");
            }


        }

        public async void save()
        {

            var emp = new Models.Empleados
            {
                nombre = Nombre,
                apellido = Apellido,
                edad = Edad,
                direccion = Direccion,
                puesto = Puesto
            };

            var resultado = await App.BaseDatos.GrabarEmpleado(emp);

            if (resultado == 1)
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Registro exitoso!!!", "ok");
                Nombre = String.Empty;
                Edad = String.Empty;
                Apellido = String.Empty;
                Direccion = String.Empty;
                Puesto = String.Empty;

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se Pudo Guardar", "OK");

            }
            /*
            Codigo = 0;
            Descripcion = String.Empty;
            Cantidad = 0;
            Precio = 0;
            */

            //await Application.Current.MainPage.DisplayAlert("No Internet Connection", "Please connect to Internet", "OK");
            //await Application.Current.MainPage.Navigation.PushAsync(new ViewListadoEmpleado());
        }

        public EmpleadosViewModels()
        {
            PantallaListadoCommand = new Command(() => listado());
            SaveCommand = new Command(() => save());
            ModificarCommand = new Command(() => modificar());
            EliminarCommand = new Command(() => Eliminar());
        }

    }
}
