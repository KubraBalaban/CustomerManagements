namespace CustomerManagementAPI.Application.Constant
{
    public class TokenStatus
    {
        public static readonly int ActiveToken = 1;
        public static readonly int NotActiveToken = 2;
        public static readonly int RefreshToken = 3;
        public static readonly int TokenNotFound = 4;
    }
}
