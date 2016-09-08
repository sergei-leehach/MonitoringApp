using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AngularJSApp.Models;
using AngularJSApp.Repository;

namespace AngularJSApp.Controllers
{   
    public class AppController : ApiController
    {
        AppRepository _repository = new AppRepository();

        public Node Get()
        {
            var node = _repository.GetHardDrives();
            return node;
        }

        public Node Get(string path)
        {
            var node = _repository.GetCount(path);
            return node;
        }     
    }
}
