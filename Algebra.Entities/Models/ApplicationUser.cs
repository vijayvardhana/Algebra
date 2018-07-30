using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Algebra.Entities.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        #region Constructor
        public ApplicationUser() { }
        #endregion

        #region Properties

        public string DisplayName { get; set; }

        public string Notes { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public int Flags { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime LastModifiedDate { get; set; }
        #endregion

        [Required]
        public string Location { get;set; }

        #region Lazy-Load Properties
        /// <summary>
        /// A list of all the refresh tokens issued for this users.
        /// </summary>
        public virtual List<Token> Tokens { get; set; }
        #endregion
    }
}
