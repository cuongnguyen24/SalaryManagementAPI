namespace SalaryManagementAPI.Helpers
{
    public class CustomDateInPastAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
                return true; // cho phép null, nếu không thì dùng thêm [Required]

            if (value is DateTime date)
            {
                return date.Date <= DateTime.Now.Date;
            }

            return false;
        }
    }
}
