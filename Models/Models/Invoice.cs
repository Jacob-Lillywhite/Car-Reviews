using CarCollection.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarCollection.Models
{
    public class Invoice
    {
        #region INVOICE-Id (PK)
        //Invoice-Id: The Primary key of the Invoice Table
        [Key]
        public int Id { get; set; }
        #endregion
        #region INVOICE-Quantity
        // Invoice-Quantity: The Amount of products/Services in the Invoice
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        #endregion
        #region INVOICE-Value
        // Invoice-Value: The Total Price of the Invoice
        [Required]
        [Display(Name = "Value")]
        public float Value { get; set; }
        #endregion
        #region INVOICE-Date
        // Invoice-Date: The Date the Invoice was Issued
        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        #endregion
        #region CAR-Id (FK)
        //Car-Id: The Id of the car mentioned in the Review (Foreign Key)
        [Display(Name = "Car Type")]
        public int CarId { get; set; }
        [Display(Name = "User Type")]
        public string ApplicationUserId { get; set; }
        #endregion

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
