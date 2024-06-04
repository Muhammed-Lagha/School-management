namespace School_management.Methods
{
    public class ParseDate
    {
        public static DateOnly ParseDateOnly(string dateString)
        {
            if (DateOnly.TryParse(dateString, out DateOnly date))
            {
                return date;
            }
            else
            {
                throw new ArgumentException($"The input string '{dateString}' could not be parsed as a valid date.");
            }
        }
    }
}
