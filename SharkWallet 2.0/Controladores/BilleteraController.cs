using Microsoft.AspNetCore.Mvc;
using SharkWallet_2._0.entidades;
using SharkWallet_2._0.UOWork;

namespace SharkWallet_2._0.Controladores
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BilleteraController : ControllerBase
    {
        private readonly IUOWork _context;

        public BilleteraController(IUOWork context)
        {
            _context = context;
        }

        //GET
        //-----------------------------------------------------------
        /// <summary>
        /// Api para seleccionar todos los clientes de la base de datos.
        /// </summary>
        /// <param name="Wallet">Estructura</param>
        /// <response code="200">Se creo correctamente</response>
        /// <response code="404">Usuario no encontrado</response>
        /// <response code="500">Oops! No se pudo buscar el User</response>
        [HttpGet]
        public ActionResult<IEnumerable<Billetera>> Get()
        {
            var entidad = _context.BilleteraRepo.GetAll();//llama a todos los registros activos
            return Ok(entidad);
        }

        //POST
        //-----------------------------------------------------------
        /// <summary>
        /// cargo un regitro en a tabla clientes
        /// </summary>
        /// <param name="Billetera">Estructura</param>
        /// <response code="200">Se creo correctamente</response>
        /// <response code="404">Usuario no encontrado</response>
        /// <response code="500">Oops! No se pudo buscar el User</response>
        /// 
        [HttpPost]
        public ActionResult Post([FromBody] Billetera billetera)
        {
            _context.BilleteraRepo.Insert(billetera);//agrega un registro
            _context.Save();
            return Ok();
        }

        //PUT
        //-----------------------------------------------------------
        /// <summary>
        /// modifica el registro que necesitamos
        /// </summary>
        /// <response code="200">Se creo correctamente</response>
        /// <response code="404">Usuario no encontrado</response>
        /// <response code="500">Oops! No se pudo buscar el User</response>

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Billetera billetera, int id)
        {
            if (id != billetera.BilleteraID)
            {
                return BadRequest();//NO se encontro id del registro
            }
            else
            {
                _context.BilleteraRepo.Update(billetera);//modifica registro
                _context.Save();
                return Ok();
            }

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
            var entity = _context.BilleteraRepo.GetById(id);

            if (entity == null)
            {
                return NotFound("No Se Encontro El Regisro Solicitado");
            }
            else
            {
                _context.BilleteraRepo.Delete(id);//borra el registro
                _context.Save();
            }
            return Ok();
        }
    }
}

