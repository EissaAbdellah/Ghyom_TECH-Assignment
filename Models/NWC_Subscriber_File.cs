using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GhyomAssignment.Models
{
    public class NWC_Subscriber_File
    {

        [Key]
        [NotNull]
        public int Id { get; set; }

        
        [Required]
        public string NWC_Subscriber_File_Id { get; set; }

        [Required]
        public string NWC_Subscriber_File_Name { get; set; }

        [Required]
        public string NWC_Subscriber_File_City { get; set; }

        [Required]
        public string NWC_Subscriber_File_Area { get; set; }

        [Required]
        public string NWC_Subscriber_File_Mobile { get; set; }

        public string NWC_Subscriber_File_Reasons { get; set; }

        [NotMapped]
        public ICollection<NWC_Subscription_File> NWC_Subscription_Files { get; set; }


        [NotMapped]
        public ICollection<NWC_Invoices> NWC_Invoices { get; set; }



    }
}
