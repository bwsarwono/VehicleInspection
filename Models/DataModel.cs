using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleInspectionDB.Models
{
    public class DataModel
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public string VIN { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [DisplayName("Vehicle Maker")]
        [Required]
        public string VehicleMaker { get; set; }

        public int Year { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [DisplayName("Vehicle Model")]
        [Required]
        public string VehicleModel { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime Date { get; set;}
        [Column(TypeName = "nvarchar(20)")]
        [DisplayName("Inspector Name")]
        [Required]
        public string InspectorName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [DisplayName("Inspector Location")]
        [Required]
        public string InspectionLocation { get; set; }
        [DisplayName("Is It Passed?")]
        public bool PassFail { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Notes { get; set; }
    }
}
