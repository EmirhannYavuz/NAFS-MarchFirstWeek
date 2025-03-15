using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IProgrammingLanguageRepository
{
    void Add(ProgrammingLanguage language);
    void Update(ProgrammingLanguage language);
    void Delete(ProgrammingLanguage language);
    ProgrammingLanguage GetById(int id);
    List<ProgrammingLanguage> GetAll();
}