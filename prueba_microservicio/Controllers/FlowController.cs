using Microsoft.AspNetCore.Mvc;

namespace prueba_microservicio.Controllers
{{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowController : ControllerBase
    {
        private readonly FlowService _flowService;

        public FlowController(FlowService flowService)
        {
            _flowService = flowService;
        }

        [HttpGet]
        public IActionResult GetAllFlows()
        {
            var flows = _flowService.GetAllFlows();
            return Ok(flows);
        }

        [HttpGet("{id}")]
        public IActionResult GetFlowById(int id)
        {
            var flow = _flowService.GetFlowById(id);
            if (flow == null)
            {
                return NotFound();
            }
            return Ok(flow);
        }

        [HttpPost]
        public IActionResult CreateFlow(Flow flow)
        {
            _flowService.CreateFlow(flow);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFlow(int id, Flow flow)
        {
            var existingFlow = _flowService.GetFlowById(id);
            if (existingFlow == null)
            {
                return NotFound();
            }
            existingFlow.Name = flow.Name;
            // Actualiza otras propiedades del flujo según sea necesario
            _flowService.UpdateFlow(existingFlow);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFlow(int id)
        {
            var existingFlow = _flowService.GetFlowById(id);
            if (existingFlow == null)
            {
                return NotFound();
            }
            _flowService.DeleteFlow(id);
            return Ok();
        }
    }
}
