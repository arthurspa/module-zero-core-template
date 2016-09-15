using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Security.AntiForgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AbpCompanyName.AbpProjectName.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AntiForgeryController : AbpProjectNameControllerBase
    {
        private readonly IAbpAntiForgeryManager _antiForgeryManager;

        public AntiForgeryController(IAbpAntiForgeryManager antiForgeryManager)
        {
            _antiForgeryManager = antiForgeryManager;
        }

        public string GetToken()
        {
            return _antiForgeryManager.GenerateToken();
        }
    }
}
