using System.Data;

namespace SafeUp.Models.DBAL.Interfaces
{
    public interface IClient
    {
        int SaveData(string query);
        DataSet GetData();
    }
}  