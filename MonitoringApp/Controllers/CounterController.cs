using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MonitoringApp.Models;
using MonitoringApp.Repository;

namespace MonitoringApp.Controllers
{
    public class CounterController : ApiController
    {
        AppRepository _repository = new AppRepository();

        public Counter Get()
        {
            var counter = _repository.GetCounter();
            return counter;
        }

        public Counter Get(string path)
        {
            var counter = _repository.GetFileCounter(path);
            return counter;
        }
    }
}
