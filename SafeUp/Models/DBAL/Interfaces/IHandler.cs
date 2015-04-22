using System.Data;

namespace SafeUp.Models.DBAL.Interfaces
{
    public interface IHandler
    {
        DataSet GetData(ITable table);
        int Insert(ITable table);
        int Update(ITable table);
        int Delete(ITable table);
    }
}