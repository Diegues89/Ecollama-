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
    public class ClientesController : ControllerBase
    {
       // private readonly DBContextEcollama _dBContextEcollama;
        private readonly IMapper _mapper;
        private readonly IClientesRepository _clientesRepository;

        public ClientesController( IMapper mapper, IClientesRepository clientesRepository)
        {
            //_dBContextEcollama = dBContextEcollama;
            _mapper = mapper;
            _clientesRepository = clientesRepository;
        }
        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<IEnumerable<ClientesDTO>> Get()
        {
            
            var data = await _clientesRepository.GetAll();

            return _mapper.Map<List<ClientesDTO>>(data);//Aquí se hace el mapeo
            //return data.ToList();
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClientesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
