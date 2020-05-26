using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebNhomKinh.Startup))]
namespace WebNhomKinh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
