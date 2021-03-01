using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dotnet.Onion.Template.Crosscutting.Common.Helpers
{
    public abstract class ResponseHelper
    {

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }

    }
}
