namespace prueba_microservicio.Service
{
    public class StepService
    {
        private readonly DbContext _dbContext;

        public StepService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Step> GetAllSteps()
        {
            return _dbContext.Steps.ToList();
        }

        public Step GetStepById(int stepId)
        {
            return _dbContext.Steps.FirstOrDefault(s => s.Id == stepId);
        }

        public void CreateStep(Step step)
        {
            _dbContext.Steps.Add(step);
            _dbContext.SaveChanges();
        }

        public void UpdateStep(Step step)
        {
            _dbContext.Steps.Update(step);
            _dbContext.SaveChanges();
        }

        public void DeleteStep(int stepId)
        {
            var step = _dbContext.Steps.FirstOrDefault(s => s.Id == stepId);
            if (step != null)
            {
                _dbContext.Steps.Remove(step);
                _dbContext.SaveChanges();
            }
        }
    }
}
