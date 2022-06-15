using BisnessLogicStratum.DTO;

namespace BisnessLogicStratum.Interfaces;

public interface IColumnService
{
    List<ColumnDTO> GetAllColumns();
    public void CreateColumn(int ID, string title);
    public void EditColumn(int ID, string newTitle);
    public ColumnDTO GetColumn(int ID);
    public void RemoveColumn(int ID);
}