namespace Dotnet.Onion.Template.Repository.Repository
{
    public class StoreQuery
    {
        public static string FindById() =>
            @"SELECT StoreId
                     ,StoreName
                     ,GroupName
              FROM Stores
              WHERE StoreId = @id";

        public static string FindAll() =>
            @"SELECT StoreId
                     ,StoreName
                     ,GroupName
              FROM Stores";
    }
}
