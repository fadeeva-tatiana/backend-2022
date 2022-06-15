using BisnessLogicStratum.DTO;
using BisnessLogicStratum.Interfaces;
using DataAccessStratum.Repositories;
using ScrumBoardLibrary;

namespace BisnessLogicStratum.Services;

public class ColumnService : IColumnService
{
    private readonly IColumnRepository _repository;

    public ColumnService(IColumnRepository repository)
    {
        this._repository = repository;
    }

    public List<ColumnDTO> GetAllColumns()
    {
        var columns = _repository.GetAllColumns();
        var columnsDTO = columns.Select(c => new ColumnDTO(c)).ToList();
        return columnsDTO;
    }

    public void CreateColumn(int ID, string title)
    {
        this._repository.Create(ID, title);
    }

    public void EditColumn(int ID, string newTitle)
    {
        _repository.Edit(ID, newTitle);
    }

    public ColumnDTO GetColumn(int ID)
    {
        return new ColumnDTO(_repository.GetAllColumns().Find(c => c.ID == ID));
    }

    public void RemoveColumn(int ID)
    {
        this._repository.Remove(ID);
    }
}