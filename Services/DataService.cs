using StateMvc.Models;

namespace StateMvc.Services;

public class DataService(StateService stateService)
{
    public UpdateVM Get()
    {
        var model = new UpdateVM()
        {
            Email = stateService.CacheEmail,
            CompanyName = stateService.SessionCompanyName,
            OKString = stateService.TempDataOKString,
        };
        return model;
    }

    public void Update(UpdateVM model) 
    {
        stateService.CacheEmail = model.Email;
        stateService.SessionCompanyName = model.CompanyName;
        stateService.TempDataOKString = "Your settings has been saved";
    }
}