using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Caching.Memory;

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
        get => memoryCache.Get<string?>(Email) ?? string.Empty; 
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                memoryCache.Set(Email, value);
            else
                memoryCache.Remove(Email);
        }
    }

    public string? SessionCompanyName
    {
        get => accessor.HttpContext?.Session.GetString(CompanyName) ?? string.Empty;

        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                accessor.HttpContext?.Session.SetString(CompanyName, value);
            else
                accessor.HttpContext?.Session.Remove(CompanyName);
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
