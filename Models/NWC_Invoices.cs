using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GhyomAssignment.Models
{
    public class NWC_Invoices
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string NWC_Invoices_No { get; set; }


        [Required]
        public char NWC_Invoices_Year { get; set; }

        [Required]
        public DateTime NWC_Invoices_Date { get; set; }

        [Required]
        public DateTime NWC_Invoices_From { get; set; }

        [Required]
        public DateTime NWC_Invoices_To { get; set; }

        [Required]
        public int NWC_Invoices_Previous_Consumption_Amount { get; set; }

        [Required]
        public int NWC_Invoices_Current_Consumption_Amount { get; set; }

        [Required]
        public int NWC_Invoices_Amount_Consumption { get; set; }

        [Required]
        public decimal NWC_Invoices_Service_Fee { get; set; }

        [Required]
        public decimal NWC_Invoices_Tax_Rate { get; set; }

        [Required]
        public bool NWC_Invoices_Is_There_Sanitation {get; set;}


        [Required]
        public decimal NWC_Invoices_Wastewater_Consumption_Value { get; set; }

        [Required]
        public decimal NWC_Invoices_Total_Invoice { get; set; }

        [Required]
        public decimal NWC_Invoices_Tax_Value { get; set; }

        [Required]
        public decimal NWC_Invoices_Total_Bill { get; set; }


        [Required]
        public string NWC_Invoices_Total_Reasons { get; set; }


        [NotNull]
        [ForeignKey("NWC_Rreal_Estate_Types")]
        public int NWC_Invoices_Rreal_Estate_Types_No { get; set; }
        public NWC_Rreal_Estate_Types NWC_Rreal_Estate_Types { get; set; }



        [NotNull]
        [ForeignKey("NWC_Subscription_File_No")]
        public int NWC_Invoices_Subscription_No { get; set; }
        public NWC_Subscription_File NWC_Subscription_File { get; set; }



        [NotNull]
        [ForeignKey("NWC_Subscriber_File")]
        public int NWC_Invoices_Subscriber_No { get; set; }
        public NWC_Subscriber_File NWC_Subscriber_File { get; set; }



    }
}
