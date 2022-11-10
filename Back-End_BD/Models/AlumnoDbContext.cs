using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Back_End_BD.Models
{
    public class AlumnoDbContext:DbContext
    {
        private const string ConnectionString = "DefaultConnection";
        public AlumnoDbContext():base(ConnectionString)
        {

        }
        public DbSet <Alumno> Alumnos { get; set; } 

        public DbSet <Maestro> Maestros { get; set; }

    }
}