using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HPEL_Assessment.Models
{
    public class Vehicles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public String Brand { get; set; }
        public String Vin { get; set; }
        public String Color { get; set; }
        public int Year { get; set; }
        [ForeignKey("Owner_Id")]
        public int OwnerId { get; set; }
        public virtual Owners Owner { get; set; }
    }
}
