using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FirstChoiceBooksUI.Startup))]
namespace FirstChoiceBooksUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
