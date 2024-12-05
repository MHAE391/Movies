namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassificationController(IClassificationService service) : ControllerBase
    {
        [HttpPost] 
        public async Task<ActionResult<Response<ClassificationDTO>>> CreateClassification([FromBody] CreateClassification classification)
        {
            var response = await service.CreateClassification(classification);
            return response.IsSuccessed ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<ClassificationDTO>>>> GetClassifications()
        {
            Response<IEnumerable<ClassificationDTO>> response = await service.GetClassifications();
            return response.IsSuccessed ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Response<ClassificationDTO>>> GetClassification(int id)
        {
            var response = await service.GetClassification(id);
            return response.IsSuccessed ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Response<ClassificationDTO>>> DeleteClassification(int id)
        {
            var response = await service.DeleteClassification(id);
            return response.IsSuccessed ? Ok(response) : BadRequest(response);
        }
        [HttpPut("id:int")]
        public async Task<ActionResult<Response<ClassificationDTO>>> UpdateClassification(int id, [FromBody] CreateClassification classification )
        {
            var response = await service.UpdateClassification(id , classification.ClassificationName);
            return response.IsSuccessed ? Ok(response) : BadRequest(response);
        } 

    }
}