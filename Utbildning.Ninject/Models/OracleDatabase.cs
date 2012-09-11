namespace Utbildning.Ninject.Models
{
    public interface IDatabase
    {
        object[] ReadAll(string collectionName);
    }
    public class OracleDatabase : IDatabase
    {
        public OracleDatabase(string connectionString){}

        public object[] ReadAll(string collectionName)
        {
            if (collectionName == "Articles")
                return new []
                           {
                               new Article{Header = "Kungen avgår"},
                               new Article{Header = "Lill-Babs ny stadsminister"}
                           };
            if (collectionName == "Puff")
                return new[]
                           {
                               new Puff{Text = "puff 1"},
                               new Puff{Text = "puff 2"}
                           };
            return null;
        }
    }
}