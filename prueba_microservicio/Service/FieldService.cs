namespace prueba_microservicio.Service
{
    public class FieldService
    {
        private readonly DbContext _dbContext;

        public FieldService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Field> GetFieldsByStepId(int stepId)
        {
            return _dbContext.Fields.Where(f => f.StepId == stepId).ToList();
        }

        public Field GetFieldById(int fieldId)
        {
            return _dbContext.Fields.FirstOrDefault(f => f.Id == fieldId);
        }

        public void CreateField(Field field)
        {
            _dbContext.Fields.Add(field);
            _dbContext.SaveChanges();
        }

        public void UpdateField(Field field)
        {
            _dbContext.Fields.Update(field);
            _dbContext.SaveChanges();
        }

        public void DeleteField(int fieldId)
        {
            var field = _dbContext.Fields.FirstOrDefault(f => f.Id == fieldId);
            if (field != null)
            {
                _dbContext.Fields.Remove(field);
                _dbContext.SaveChanges();
            }
        }
    }
}
