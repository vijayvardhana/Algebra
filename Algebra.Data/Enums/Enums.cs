using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Algebra.Data
{
    public static class Enums
    {

        public enum Role
        {
            Administrator,
            RegisteredUser,
            GurgaonAdmin,
            BangaloreAdmin,
        };

        public enum Location
        {
            [Display(Name = "Bangalore")]
            Bangalore = 1,
            [Display(Name = "Chennai")]
            Chennai = 2,
            [Display(Name = "Delhi")]
            Delhi = 3,
            [Display(Name = "Kolkata")]
            Kolkata = 4,
            [Display(Name = "Gurgaon")]
            Gurgaon = 5,
            [Display(Name = "Mumbai")]
            Mumbai = 6,
        };

        public enum MembershipCategory
        {
            [Display(Name = "Individual")]
            Individual = 1,
            [Display(Name = "Individual With Spouse")]
            IndividualCouple = 2,
            [Display(Name = "Individual With Dependent(s)")]
            IndividualDependent = 3,
            [Display(Name = "Individual, Spouse With Dependent(s)")]
            IndividualCoupleDependent = 4

        };

        public enum Title
        {
            Mr,
            Mrs,
            Miss,
            Ms,
            Sir,
            Dr
        }


    }
}
