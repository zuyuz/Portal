using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Server.Entities;
using AspNetCoreSpa_master.Server.Entities;

namespace AspNetCoreSpa.Server.ViewModels
{
    public class ContactsViewModel
    {
        public int Id { get; set; }
        public UserDemand UserDemand { get; set; }
        public string UserEmail { get; set; }
        public bool IsAllowed { get; set; }
    }
}
