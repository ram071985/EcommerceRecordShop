using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("api/albums")]

    public class AlbumController : ControllerBase
    {


        public AlbumController()
        {
            
        }

        [HttpGet("albums")]
        public void GetAllAlbums()
        {

        }
    }
}
