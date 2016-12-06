namespace Xrm.ReportUtility.Interfaces
{
    public interface IConfig
    {
        /*
            На самом деле, этот метод можно вынести
            в отдельный интерфейс, так же как и в IDataRow
            Нужен для того, чтобы получить значение свойства объекта,
            факт существования которого [свойства] не известен
        */
        object GetValue(string prop);
    }
}
