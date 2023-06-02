using AutoMapper;
using BackEnd_Ecollama.DataBase;
using BackEnd_Ecollama.Models.DTOs;
using BackEnd_Ecollama.Repositories;
using BackEnd_Ecollama.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_Ecollama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DBContextEcollama _dBContextEcollama;
        private readonly IMapper _mapper;
        private readonly IProductoRepository _productoRepository;

        public ProductosController(DBContextEcollama dBContextEcollama, IMapper mapper, IProductoRepository productoRepository)
        {
            _dBContextEcollama = dBContextEcollama;
            _mapper = mapper;
            _productoRepository = productoRepository;
        }
        // GET: api/<ProductosController>
        [HttpGet]
        public  async Task<IEnumerable<ProductosDTO>> Get()
        {

            var data = await _productoRepository.GetAll();

            return _mapper.Map<List<ProductosDTO>>(data);//Aquí se hace el mapeo
            //return data.ToList();
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // comentario prueba git
        }
    }
}
