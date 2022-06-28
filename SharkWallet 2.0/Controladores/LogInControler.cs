using Microsoft.AspNetCore.Mvc;
using SharkWallet_2._0.Autenticacion.request;
using SharkWallet_2._0.Autenticacion.response;
using SharkWallet_2._0.Servicios;
using SharkWallet_2._0.UOWork;

namespace SharkWallet_2._0.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly IUserServices _usuarioService;
        private readonly IUOWork _uow;
        public LogInController(IUserServices usuarioService, IUOWork uow)
        {
            _usuarioService = usuarioService;
            _uow = uow;
        }
        [HttpPost]
        public ActionResult Login([FromBody] UserRequest req)
        {
            var response = _usuarioService.Login(req.Email, req.Contraseña);

            if (response == null)
            {

                return Unauthorized();
            }
            var token = _usuarioService.GetToken(response);
            return Ok(new
            {
                token = token,
                usuario = response
            });
        }

        [HttpPost("Registro")]
        public ActionResult RegistrarUsuario([FromBody] UserRequest user)
        {
            if (_uow.LogInRepo.ExisteUsuario(user.Email.ToLower()))
            {
                return BadRequest("Ya existe un cuenta asociada a ese Email");
            }
            UserResponse res = _usuarioService.Registrar(user, user.Contraseña);
            return Ok(res);
        }
        
    }
}
