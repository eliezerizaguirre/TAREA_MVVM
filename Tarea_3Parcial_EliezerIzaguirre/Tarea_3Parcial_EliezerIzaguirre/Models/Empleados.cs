using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TareaMVVM.Models
{
    public class Empleados
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(200)]
        public string nombre { get; set; }

        [MaxLength(200)]
        public string apellido { get; set; }

        [MaxLength(200)]
        public string edad { get; set; }

        [MaxLength(200)]
        public string direccion { get; set; }

        [MaxLength(200)]
        public string puesto { get; set; }
    }
}
