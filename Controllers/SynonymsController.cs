namespace TurkishSynonyms.Controllers
{
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Mvc;
  using Newtonsoft.Json.Linq;
  using TurkishSynonyms.Models;
  using System.IO;
  using Newtonsoft.Json;

  [Route("api/[controller]")]
  [ApiController]
  public class SynonymsController : ControllerBase
  {

    List<Word> words = new List<Word>();

    public SynonymsController()
    {
      var data = System.IO.File.ReadAllText("data.json");

      words = JsonConvert.DeserializeObject<List<Word>>(data)!;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
      return Ok(words);
    }

    [HttpGet("getsynonym")]
    public IActionResult GetSynonym(string word)
    {
      foreach (var eachWord in words)
      {
        if(eachWord.kelime == word)
        {
          return Ok(eachWord);
        }
      }

      return NotFound();
    }


  }
}
