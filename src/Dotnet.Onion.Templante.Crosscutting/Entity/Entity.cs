namespace Dotnet.Onion.Template.Crosscutting.Entity
{
    public abstract class Entity<T>
    {
        public virtual T Id { get; set; }
    }
}
