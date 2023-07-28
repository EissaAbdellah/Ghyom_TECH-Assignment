using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GhyomAssignment.Models
{
    public class NWC_Subscription_File
    {

        [Key]
        public int Id { get; set; }

       

        [Required]
        public int NWC_Subscription_File_Unit_No { get; set; }


        [Required]
        public bool NWC_Subscription_File_Is_There_Sanitation { get; set; }


        [Required]
        public int NWC_Subscription_File_Last_Reading_Meter { get; set; }



        public string NWC_Subscription_File_Reasons { get; set; }


        [NotMapped]
        public ICollection<NWC_Invoices> NWC_Invoices { get; set; }




        [NotNull]
        [ForeignKey("NWC_Subscriber_File")]
        public int NWC_Subscription_File_Subscriber_Code { get; set; }
        public NWC_Subscriber_File NWC_Subscriber_File { get; set; }


        [NotNull]
        [ForeignKey("NWC_Rreal_Estate_Types")]
        public int NWC_Subscription_File_Rreal_Estate_Types_Code { get; set; }
        public NWC_Rreal_Estate_Types NWC_Rreal_Estate_Types { get; set; }


    }
}
