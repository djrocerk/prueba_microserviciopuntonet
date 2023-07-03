using Microsoft.AspNetCore.Mvc;

namespace prueba_microservicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepController : ControllerBase
    {
        private readonly StepService _stepService;

        public StepController(StepService stepService)
        {
            _stepService = stepService;
        }

        [HttpGet]
        public IActionResult GetAllSteps()
        {
            var steps = _stepService.GetAllSteps();
            return Ok(steps);
        }

        [HttpGet("{id}")]
        public IActionResult GetStepById(int id)
        {
            var step = _stepService.GetStepById(id);
            if (step == null)
            {
                return NotFound();
            }
            return Ok(step);
        }

        [HttpPost]
        public IActionResult CreateStep(Step step)
        {
            _stepService.CreateStep(step);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStep(int id, Step step)
        {
            var existingStep = _stepService.GetStepById(id);
            if (existingStep == null)
            {
                return NotFound();
            }
            existingStep.Name = step.Name;
            // Actualiza otras propiedades del paso según sea necesario
            _stepService.UpdateStep(existingStep);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStep(int id)
        {
            var existingStep = _stepService.GetStepById(id);
            if (existingStep == null)
            {
                return NotFound();
            }
            _stepService.DeleteStep(id);
            return Ok();
        }
    }
}
