using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Onion.Template.API.ViewModel.Store.Request
{
    public class StoreRequest
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string GroupName { get; set; }
    }
}
