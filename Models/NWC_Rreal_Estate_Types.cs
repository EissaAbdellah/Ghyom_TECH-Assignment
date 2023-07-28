using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GhyomAssignment.Models
{
    public class NWC_Rreal_Estate_Types
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string NWC_Rreal_Estate_Types_Code { get; set; }

        [Required]
        public string NWC_Rreal_Estate_Types_Name { get; set; }

        public string NWC_Rreal_Estate_Types_Reasons { get; set; }

        [NotMapped]
        public ICollection<NWC_Subscription_File> NWC_Subscription_Files { get; set; }

        [NotMapped]
        public ICollection<NWC_Invoices> NWC_Invoices { get; set; }

    }
}
