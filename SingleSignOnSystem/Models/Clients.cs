using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleSignOnSystem.Models
{
    public class Clients
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string RedirectUris { get; set; }
        public string PostLogoutRedirectUris { get; set; }
    }
}
