using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiwebpim.Models;
using Microsoft.AspNetCore.Cors;

namespace apiwebpim.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly ApiPimcontext _context;

        public AutenticacaoController(ApiPimcontext context)
        {
            _context = context;
        }

        // GET: api/Autenticacao
        [HttpGet]
        public async Task<ActionResult> GetAutenticacao()
        {
            var teste = await _context.Usuarios.ToListAsync();

            return Ok(teste);
            
        }

        // GET: api/Autenticacao/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAutenticacao(int id)
        {
            var Autenticacao = await _context.Usuarios.FindAsync(id);

            if (Autenticacao == null)
            {
                return NotFound();
            }

            return Ok(Autenticacao);
        }
        //api/Autenticacao
        [HttpPost]
        public async Task<ActionResult> PostUAuth([FromBody]Autenticacao user){
            
        // var UsuaruioAutenticado = await(from Usuarios in _context.Usuarios 
        // select new{ Usuarios.CodPerfil,Usuarios.CodStatus,Usuarios.CodUsuario,Usuarios.Login,Usuarios.Senha})
        // .Where((UsuaruioAutenticado) => UsuaruioAutenticado.Login ==  user.Login 
        //     && UsuaruioAutenticado.Senha == user.Senha).FirstOrDefaultAsync();
            var AutenticaUsuario = await(from Usuarios in _context.Usuarios select new { Usuarios.Login,Usuarios.Senha}).Where((AutenticaUsuario) => AutenticaUsuario.Login == user.Login && AutenticaUsuario.Senha == user.Senha).FirstOrDefaultAsync();
            if(AutenticaUsuario.Login == user.Login && AutenticaUsuario.Senha == user.Senha){
                return Ok(AutenticaUsuario);
            }else{
                 return NotFound();
            }
           
        }

        // PUT: api/Autenticacao/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        
        // POST: api/Autenticacao
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        

       
    }
}
