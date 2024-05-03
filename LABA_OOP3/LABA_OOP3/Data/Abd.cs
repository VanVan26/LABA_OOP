using Microsoft.EntityFrameworkCore;
using LABA_OOP3.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;

namespace LABA_OOP3.Data
{
    public class Abd : DbContext
    {


        public Abd(DbContextOptions<Abd> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Descktop> Descktops { get; set; }
        public DbSet<Human> Humans { get; set; }
        public DbSet<HumanToClassroom> HumanToClassrooms { get; set; }
    }
}