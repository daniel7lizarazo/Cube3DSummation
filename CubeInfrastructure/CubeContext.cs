using CubeDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeInfrastructure
{
    public class CubeContext<TId> : DbContext
        where TId : IComparable, IComparable<TId>
    {
        public DbSet<CubeCoordinates<TId>> TheCubeCoordinates { get; set; }
        public DbSet<TheCube<CubeCoordinates<TId>, TId>> TheCubes { get; set; }

        //public CubeContext(DbContextOptions<CubeContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(databaseName: "ShapesAndCoordinates");
            }

        }
    }

}
