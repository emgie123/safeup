namespace SafeUp.Models.DBAL.Interfaces
{
    public interface IQuery
    {
        string GetQuery(ITable table);
    }
}