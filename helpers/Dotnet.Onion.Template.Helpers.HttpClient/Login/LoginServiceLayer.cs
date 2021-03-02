namespace Dotnet.Onion.Template.Helpers.HttpClient.Login
{
    public class LoginServiceLayer
    {
        public LoginServiceLayer(string userName, string password, string companyDb)
        {
            UserName = userName;
            Password = password;
            CompanyDB = companyDb;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CompanyDB { get; set; }
    }
}
