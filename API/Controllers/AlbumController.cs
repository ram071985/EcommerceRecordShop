using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller")]

    public sealed class AlbumController : ControllerBase
    {
        public AlbumController()
        {
            
        }
        // Get current in stock albums from database
        [HttpGet("albums")]
        public void GetAlbums()
        {
            // TODO should return List<Albums>()
            
        }
    }
}
