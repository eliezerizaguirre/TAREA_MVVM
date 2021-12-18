using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TareaMVVM.Models;

namespace TareaMVVM.Controller
{
    public class DataBaseSQLite
    {
        readonly SQLiteAsyncConnection db;

        //constructor de la clase DataBaseSQLite
        public DataBaseSQLite(string pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<Empleados>().Wait();
        }

        //Operaciones crud de sqlite
        //Read List way
        public Task<List<Empleados>> ObtenerListaEmpleados()
        {
            return db.Table<Empleados>().ToListAsync();
        }

        //read one by one 
        public Task<Empleados> ObtenerEmpleado(int pcodigo)
        {
            return db.Table<Empleados>()
                .Where(i => i.id == pcodigo)
                .FirstOrDefaultAsync();
        }

        //Create o update personas
        public Task<int> GrabarEmpleado(Empleados empl)
        {
            if (empl.id != 0)
            {
                return db.UpdateAsync(empl);
            }
            else
            {
                return db.InsertAsync(empl);
            }

        }



        //delete
        public Task<int> EliminarEmpleado(Empleados emp)
        {
            return db.DeleteAsync(emp);
        }
    }
}
