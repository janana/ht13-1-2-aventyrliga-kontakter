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
            [EmailAddress]
            public string EmailAddress { get; set; }

            [Required(ErrorMessage = "Du måste ange ett förnamn.")]
            [DisplayName("Förnamn")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Du måste ange ett efternamn.")]
            [DisplayName("Efternamn")]
            public string LastName { get; set; }
        }
    }
}