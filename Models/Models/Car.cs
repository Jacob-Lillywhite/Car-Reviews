using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarCollection.Models
{
    public class Car
    {
        #region CAR-Id (PK)
        // Car-Id: The Primary key of the Car Table
        [Key]
        public int Id { get; set; }
        #endregion
        #region CAR-Make
        // Car-Make: The Carmaker
        [Required]
        [Display(Name = "Make")]
        public string Make { get; set; }
        #endregion
        #region CAR-Model
        // Car-Model: The Car's Model
        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }
        #endregion
        #region CAR-Year
        // Car-Year: The Car's Year
        [Required]
        [Display(Name = "Year")]
        public int Year { get; set; }
        #endregion
        #region CAR-Condition
        // Car-Condition: The Car's Current Condition
        // [Required] ?
        [Display(Name = "Condition")]
        public string Condition { get; set; }
        #endregion
        #region CAR-Price
        // Car-Price: The Car's Hourly Rate
        [Required]
        [Display(Name = "Price")]
        public float Price { get; set; }
        #endregion
        [NotMapped]
        public string carName { get { return Make + " " + Model + " " + Year; } }
        // Image upload - Admin uploads image of car?
    }
}
