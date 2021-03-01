using System.Net;
using System.Threading.Tasks;
using Dotnet.Onion.Template.Crosscutting.Common.Helpers;
using Dotnet.Onion.Template.Crosscutting.Common.Settings;
using Dotnet.Onion.Template.Domain.BusinessPartners;
using Dotnet.Onion.Template.Domain.Integration.Http;
using Dotnet.Onion.Template.Helpers.HttpClient.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace Dotnet.Onion.Template.Integration.Http.Integrations
{
    public class BusinessPartnersIntegration : ResponseHelper, IBusinessPartnersIntegration
    {
        private readonly ApiSettings _apiSettings;
        private readonly IHttpHelper _httpHelper;
        

        private const string BusinessPartners = "/BusinessPartners";

        public BusinessPartnersIntegration(ApiSettings apiSettings, IHttpHelper httpHelper)
        {
            _apiSettings = apiSettings;
            _httpHelper = httpHelper;
        }


        public async Task<BusinessPartner> BusinessPartner(string cardCode)
        {
            var result = await _httpHelper.GetRequest($"{_apiSettings.ServiceLayerUrl}{BusinessPartners}('{cardCode}')?$select=CardCode, Address");
            if (result.StatusCode == HttpStatusCode.OK)
                return await DeserializarObjetoResponse<BusinessPartner>(result);
            return null;
        }

    }
}
