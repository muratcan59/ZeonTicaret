using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZeonTicaret.Ui.Startup))]
namespace ZeonTicaret.Ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
