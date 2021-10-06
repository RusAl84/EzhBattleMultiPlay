﻿using EhzClassLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EhzBattleServer.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RegController : ControllerBase
  {
    // POST api/<RegController>
    [HttpPost]
    public string Post(LoginClass reciveData)
    {
      string token = Program.storedLogins.RegUser(reciveData.login, reciveData.password);
      Console.WriteLine(Program.storedLogins);
      return token;
    }
  }
}
