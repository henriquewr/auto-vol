
namespace System.Text
{
    public static class StringExtensions
    {
        public static int? ToSafeZeroToHundredInt(this string value)
        {
            if (int.TryParse(value, out int result))
            {
                if (result < 0)
                {
                    return 0;
                }
                else if (result > 100)
                {
                    return 100;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
