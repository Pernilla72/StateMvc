using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection.Metadata.Ecma335;

namespace StateMvc.Services;

public class StateService(
    IMemoryCache memoryCache,
    IHttpContextAccessor accessor,
    ITempDataDictionaryFactory tempFactory)
{
    const string Email = "Email";
    const string CompanyName = "CompanyName";
    const string OKString = "OKStringMessage";


    public string CacheEmail
    {
        get { return memoryCache.Get<string?>(Email); }
        set
        {
            if (value != null)
                memoryCache.Set(Email, value);
            else
                memoryCache.Remove(Email);
        }
    }

    public string? SessionCompanyName
    {
        get
        {
            var sessionvalue = accessor.HttpContext?.Session.GetString(CompanyName);
            return sessionvalue == null ? null : sessionvalue;

        }
        set
        {
            if (value != null)
                accessor.HttpContext!.Session.SetString(CompanyName, value.ToString());
            else
                accessor.HttpContext.Session.Remove(CompanyName);
        }
    }
    public string? TempDataOKString
    {
        get
        {
            var tempDatavalue = tempFactory.GetTempData(accessor.HttpContext)["TempDataOKString"];
            return tempDatavalue == null ? null : tempDatavalue.ToString();
        }
        set
        {
            tempFactory.GetTempData(accessor.HttpContext)["TempDataOKString"] = value;
        }



    }
}
