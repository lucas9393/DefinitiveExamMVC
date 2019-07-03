using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewExamMVC.Models
{
    [Display(Name = "Cliente")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "È necessario inserire il nome del cliente")]
        [StringLength(15, ErrorMessage = "Il nome è troppo lungo")]
        [Display(Name = "Nome")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage ="Nome non valido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "È necessario inserire il cognome del cliente")]
        [StringLength(20, ErrorMessage = "Il cognome è troppo lungo")]
        [Display(Name = "Cognome")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Cognome non valido")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "È necessario inserire la mail del cliente")]
        [StringLength(30, ErrorMessage = "La mail è troppo lunga")]
        [Display(Name = "Email")]
        [RegularExpression(@"[^@]+@[^\.]+\..+", ErrorMessage = "Mail non valida")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "È necessario inserire l'indirizzo")]
        [StringLength(35, ErrorMessage = "Indirizzo troppo lungo")]
        [Display(Name = "Indirizzo")]
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
