using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HPEL_Assessment.Models
{
    public class Claims
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public String Description { get; set; }
        public String Status { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Vehicle_Id")]
        public int VehicleId { get; set; }
        public virtual Vehicles Vehicle { get; set; }

    }
}
