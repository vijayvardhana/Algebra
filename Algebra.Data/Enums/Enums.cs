using System.ComponentModel.DataAnnotations;

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
            Mr = 1,
            Mrs = 2,
            Miss = 3,
            Ms = 4,
            Sir = 5,
            Dr = 6
        };

        public enum CardNumberSuffix
        {
            Member = 1,
            Spouse = 2,
            FirstDependent = 3,
            SecondDependent = 4
        }

        public enum Gender
        {
            Male=1,
            Female=2
        }

        public enum Occupation
        {
            [Display(Name = "Self Employed")]
            SelfEmployed=1,
            [Display(Name = "Salaried")]
            Salaried=2,
            [Display(Name = "Business")]
            Business=3
        }

        public enum MaritalStatus
        {
            Single=1,
            Married=2,
            Divorced=3,
            Widowed=4,
            Separated=5
        }

        public enum ChequeStatus
        {
            [Display(Name = "Bounced")]
            Bounced=1,
            [Display(Name = "Cancelled")]
            Cancelled=2,
            [Display(Name = "Cleared")]
            Cleared=3,
            [Display(Name = "Processing")]
            ClearingProcess=4,
            [Display(Name = "Others")]
            Others=5
        }
    }
}
