using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Service;


namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsuarioController:ControllerBase
    {
        private readonly IUsuarioService usuarioService;
        public UsuarioController (IUsuarioService usuarioService){
            this.usuarioService=usuarioService;
        }


        [HttpGet]
        public IEnumerable<Usuario> GetUsuarios() {
            return usuarioService.ListAll();
        }

       [HttpGet ("{id}")]
        public async Task<IActionResult> GetUsuario([FromRoute] int id)
        {
            Usuario usuario = new Usuario();
            usuario.IdUsuario = id;
            var usuarioGet = usuarioService.FindById(usuario);

            return Ok(usuarioGet);

        }

        /*[HttpGet ("{apodo}")]
        public async Task<IActionResult> GetUsuario([FromRoute] string apodo)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentUsuario = await usuarioservice.Usuarios.SingleOrDefaultAsync(p =>p.Apodo == apodo);

            if(currentUsuario == null)
            {
                return NotFound();
            }

            return Ok(currentUsuario);

        }

          [HttpGet ("{email}")]
        public async Task<IActionResult> GetUsuario([FromRoute] string email)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentUsuario = await usuarioservice.Usuarios.SingleOrDefaultAsync(p =>p.email == email);

            if(currentUsuario == null)
            {
                return NotFound();
            }

            return Ok(currentUsuario);

        }*/



        [HttpPost]
         public async Task<IActionResult> PostUsuario([FromBody] Usuario Usuario){

            usuarioService.Save(Usuario);

            return CreatedAtAction ("GetUsuario", new {id = Usuario.IdUsuario},Usuario);
         }

         /* 
         [HttpPut("{id}")]
         public async Task<IActionResult> PutUsuario ([FromBody] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentUsuario = await usuarioservice.Usuarios.SingleOrDefaultAsync(p => p.IdUsuario == id);

             if(currentUsuario == null){
                 return NotFound();
             }

             usuarioservice.Usuarios.Update(currentUsuario);
             await usuarioservice.SaveChangesAsync();

             return Ok(currentUsuario);
         }*/

    }
}