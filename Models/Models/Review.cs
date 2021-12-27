using CarCollection.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CarCollection.Models
{
    public class Review
    {
        #region REVIEW-Id (PK)
        // Review-Id: The Primary Key of the Review Table
        [Key]
        public int Id { get; set; }
        #endregion
        #region REVIEW-Rating
        //Review-Rating: The number of Stars (1-5) Given in the Review
        [Display(Name = "Rating")]
        public float Rating { get; set; }
        #endregion
        #region REVIEW-Description
        //Review-Description: The written description left by the User detailing their experience
        [Display(Name = "Description")]
        public string Description { get; set; }
        #endregion
        #region REVIEW-Image
        public string Image { get; set; }
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
        public virtual ApplicationUser  ApplicationUser { get; set; }
        [NotMapped]
        public string CarName { get; set; }

    }
}
