using Microsoft.AspNetCore.Mvc;
using SharkWallet_2._0.entidades;
using SharkWallet_2._0.UOWork;
using System.Net;

namespace SharkWallet_2._0.Controladores
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class BalanceController : ControllerBase
    {
        
        private readonly IUOWork _context;

        public BalanceController(IUOWork context)
        {
            _context = context;
        }
       


        //GET
        //-----------------------------------------------------------
        /// <summary>
        /// Api para seleccionar todos los clientes de la base de datos.
        /// </summary>
        /// <param name="Balance">Estructura</param>
        /// <response code="200">Se creo correctamente</response>
        /// <response code="404">Usuario no encontrado</response>
        /// <response code="500">Oops! No se pudo buscar el User</response>
        [HttpGet]
        public ActionResult<IEnumerable<Balance>> Get()
        {
            var entidad = _context.BalanceRepo.GetAll();//llama a todos los registros activos
            return Ok(entidad);
        }

        //POST
        //-----------------------------------------------------------
        /// <summary>
        /// cargo un regitro en a tabla clientes
        /// </summary>
        /// <param name="User">Estructura</param>
        /// <response code="200">Se creo correctamente</response>
        /// <response code="404">Usuario no encontrado</response>
        /// <response code="500">Oops! No se pudo buscar el User</response>
        [HttpPost]
        public ActionResult Post([FromBody] Balance balance)
        {
            _context.BalanceRepo.Insert(balance);//agrega un registro
            _context.Save();
            return Ok();
        }

        //DELETE
        //-----------------------------------------------------------
        /// <summary>
        ///  borra registro de la base de datos.
        /// </summary>
        /// <param name="id" example="123">UserID</param>
        /// 
        /// <response code="200">Se creo correctamente</response>
        /// <response code="404">Usuario no encontrado</response>
        /// <response code="500">Oops! No se pudo buscar el User</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var entity = _context.BalanceRepo.GetById(id);

            if (entity == null)
            {
                return NotFound("No Se Encontro El Registro Solicitado");
            }
            else
            {
                _context.BalanceRepo.Delete(id);//borra el registro
                _context.Save();
            }
            return Ok();
        }
    }
}



