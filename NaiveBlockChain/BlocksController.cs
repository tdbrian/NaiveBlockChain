﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NaiveBlockChain.Blocks
{
    [Route("api/[controller]")]
    public class BlocksController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
