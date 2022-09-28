using Microsoft.EntityFrameworkCore;

namespace VehicleInspectionDB.Models
{
    public class VehicleInspectionContext:DbContext
    {
        public VehicleInspectionContext(DbContextOptions<VehicleInspectionContext> options) : base(options)
        {

        }

        public DbSet<DataModel> DataModels { get; set; }

    }
}
