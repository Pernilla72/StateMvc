using StateMvc.Views.Settings;

namespace StateMvc.Services;

public class DataService(StateService stateService)
{
    public UpdateVM Get()
    {
        var model = new UpdateVM()
        {
            Email = stateService.CacheEmail,
            CompanyName = stateService.SessionCompanyName,
            SuccessMessage = stateService.TempDataSuccessMessage,
        };
        return model;
    }

    public void Update(UpdateVM model) 
    {
        stateService.CacheEmail = model.Email;
        stateService.SessionCompanyName = model.CompanyName;
        stateService.TempDataSuccessMessage = "Your settings has been saved";
    }
}