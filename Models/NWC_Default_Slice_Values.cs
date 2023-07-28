using System.ComponentModel.DataAnnotations;

namespace GhyomAssignment.Models
{
    public class NWC_Default_Slice_Values
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(3)]
        [Required]
        public string NWC_Default_Slice_Values_Code { get; set; }

      
        [Required]
        public string NWC_Default_Slice_Values_Name { get; set; }

        [Required]
        public int NWC_Default_Slice_Values_Condtion { get; set; }

     
        [Required]
        public decimal NWC_Default_Slice_Values_Water_Price { get; set; }

        [Required]
        public decimal NWC_Default_Slice_Values_Sanitation_Price { get; set; }

        [MaxLength(100)] 
        public string NWC_Default_Slice_Values_Reasons { get; set; }





    }
}
