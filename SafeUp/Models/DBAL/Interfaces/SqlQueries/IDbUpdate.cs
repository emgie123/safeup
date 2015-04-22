namespace SafeUp.Models.DBAL.Interfaces.SqlQueries
{
    public interface IDbUpdate
    {
       
        string UpdateStatement(ITable table);
    
    }
}