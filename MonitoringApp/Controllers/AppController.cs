using System.Web.Http;
using MonitoringApp.Models;
using MonitoringApp.Repository;

namespace MonitoringApp.Controllers
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
            var node = _repository.GetNode(path);
            return node;
        }     
    }
}
