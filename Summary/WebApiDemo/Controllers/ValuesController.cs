using Example.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiDemo.Controllers
{
    public class ValuesController : ApiController
    {
        
        private readonly ILogger _logger;
        public ValuesController(ILogger logger)
        {
            _logger = logger;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {

            _logger.Info("asp.net webapi控制器，autofac构造函数注入成功");

            return new string[] { "value1", "value2" };
        }


    }
}