using TSF.DVDCentral.BL.Models;
using TSF.DVDCentral.UI.Extensions;

namespace TSF.DVDCentral.UI.Models
{
    public static class Authenticate
    {
        public static bool IsAuthenticated(HttpContext context)
        {
            if (context.Session.GetObject<User>("user") != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
