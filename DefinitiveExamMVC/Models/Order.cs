using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewExamMVC.Models
{
    [Display(Name = "Ordine")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Id del cliente")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "È necessario inserire il codice dell'ordine")]
        [Display(Name = "Codice")]
        [StringLength(30, ErrorMessage = "Il codice è troppo lungo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "È necessario inserire un prezzo")]
        [Display(Name = "Prezzo")]
        [RegularExpression(@"[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Il prezzo deve essere un numero")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Prezzo non valido")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Data di creazione richiesta")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data di creazione")]
        public DateTime Creation { get; set; }

        [Required(ErrorMessage = "Data di spedizione richiesta")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data di spedizione")]
        [ValidSendingDate]
        public DateTime Sending { get; set; }

        [Display(Name = "Id del cliente")]
        public Customer Customer { get; set; }
    }


    public class ValidSendingDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (Order)validationContext.ObjectInstance;
            DateTime sendingDate = Convert.ToDateTime(value);
            DateTime creationDate = Convert.ToDateTime(model.Creation);

            if (creationDate > sendingDate)
            {
                return new ValidationResult ("La data di creazione deve precedere la data di spedizione");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
