using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models
{
    [MetadataType(typeof(Contact_Metadata))]
    public partial class Contact
    {
        


        class Contact_Metadata
        {
            [Required(ErrorMessage="Du måste ange en epostadress.")]
            [DisplayName("Epostadress")]
            [EmailAddress(ErrorMessage="Du måste ange en giltig epostadress.")]
            [StringLength(50, ErrorMessage="Epostadressen får inte vara längre än 50 tecken.")]
            public string EmailAddress { get; set; }

            [Required(ErrorMessage = "Du måste ange ett förnamn.")]
            [DisplayName("Förnamn")]
            [StringLength(50, ErrorMessage = "Förnamnet får inte vara längre än 50 tecken.")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Du måste ange ett efternamn.")]
            [DisplayName("Efternamn")]
            [StringLength(50, ErrorMessage = "Efternamnet får inte vara längre än 50 tecken.")]
            public string LastName { get; set; }
        }
    }
}