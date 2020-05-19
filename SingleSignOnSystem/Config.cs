using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using SingleSignOnSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleSignOnSystem
{
    public class Config
    {
        private static IConfiguration _configuration;
        public Config(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Phone(),
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            var list = configuration.GetSection("Clients").Get<List<Clients>>();
            List<Client> listClient = new List<Client>();
            foreach (var item in list)
            {
                Client client = new Client
                {
                    ClientId = item.ClientId,
                    ClientName = item.ClientName,
                    AllowedGrantTypes = GrantTypes.Implicit,//隐式方式
                    RequireConsent = false,//如果不需要显示否同意授权 页面 这里就设置为false
                    RedirectUris = { item.RedirectUris },//登录成功后返回的客户端地址
                    PostLogoutRedirectUris = { item.PostLogoutRedirectUris },//注销登录后返回的客户端地址

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Phone,
                        item.ClientId
                    }
                };
                listClient.Add(client);
            }
            return listClient;
        }
    }
}
