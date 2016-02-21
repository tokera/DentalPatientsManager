using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(DentalPatientsManager.Web.Startup))]

namespace DentalPatientsManager.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
