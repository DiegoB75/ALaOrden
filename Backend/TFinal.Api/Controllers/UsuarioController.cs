using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Service;


namespace TFinal.Api.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetUsuarios()
        {
            return usuarioService.ListAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetUsuario([FromRoute] int id)
        {
            Usuario usuario = new Usuario();
            usuario.IdUsuario = id;
            var usuarioGet = usuarioService.FindById(usuario);

            return Ok(usuarioGet);

        }

        [HttpPost]
        public IActionResult PostUsuario([FromBody] Usuario Usuario)
        {

            usuarioService.Save(Usuario);

            return CreatedAtAction("GetUsuario", new { id = Usuario.IdUsuario }, Usuario);
        }

        [HttpPut("{id}")]
        public IActionResult PutUsuario([FromRoute] int id, [FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if (usuario.IdUsuario != id){
                return BadRequest();
            }
            usuarioService.Update(usuario);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario([FromRoute] int id)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var currentUsuario = usuarioService.FindById(new Usuario{ IdUsuario = id});
            if (currentUsuario == null){
                return BadRequest();
            }
            usuarioService.Delete(currentUsuario);

            return Ok(currentUsuario);
        }

    }
}