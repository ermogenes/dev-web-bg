using Microsoft.AspNetCore.Mvc;
using dev_web_bg.db;
using System.Linq;
using System.Collections.Generic;

namespace dev_web_bg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardgamesController : ControllerBase
    {
        private boardgamesContext _db { get; set; }
        public BoardgamesController(boardgamesContext contexto)
        {
            _db = contexto;
        }

        [HttpGet]
        public List<Boardgame> Get()
        {
            var listaBGs = _db.Boardgame
                .OrderByDescending(bg => bg.Nota)
                .ThenBy(bg => bg.Ano)
                .ThenBy(bg => bg.Nome)
                .ToList();

            return listaBGs;
        }
    }
}