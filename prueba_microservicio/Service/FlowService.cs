namespace prueba_microservicio.Service
{{
    public class FlowService
    {
        private readonly DbContext _dbContext;

        public FlowService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Flow> GetAllFlows()
        {
            return _dbContext.Flows.ToList();
        }

        public Flow GetFlowById(int flowId)
        {
            return _dbContext.Flows.FirstOrDefault(f => f.Id == flowId);
        }

        public void CreateFlow(Flow flow)
        {
            _dbContext.Flows.Add(flow);
            _dbContext.SaveChanges();
        }

        public void UpdateFlow(Flow flow)
        {
            _dbContext.Flows.Update(flow);
            _dbContext.SaveChanges();
        }

        public void DeleteFlow(int flowId)
        {
            var flow = _dbContext.Flows.FirstOrDefault(f => f.Id == flowId);
            if (flow != null)
            {
                _dbContext.Flows.Remove(flow);
                _dbContext.SaveChanges();
            }
        }
    }
}
