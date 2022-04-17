using System.ComponentModel.DataAnnotations;

namespace post_office.Helpers
{
    public class Enums
    {
        public enum GeneralStatus
        {
            [Display(Name="Deactivated")]
            Deactivated,
            [Display(Name="Activated")]
            Activated
        }

        public enum OrderStatus
        {
            [Display(Name="Pending")]
            Pending
        }
    }
}