using System.Collections.Generic;

namespace Utbildning.App.Core.DB
{
    public interface IDatabase<T>
    {
        IEnumerable<T> ReadAll(string collectionName);
        void DeleteAll(string collectionName);
        void Create(IEnumerable<T> documents, string collectionName);
    }
}