using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebPages.OAuth;

namespace MvcAuthGoogle
{
    public class OAuthConfig
    {
        public static void RegisterProviders()
        {
            OAuthWebSecurity.RegisterGoogleClient(); // that's all :)
        } 
    }
}