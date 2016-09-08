using System.Collections.Generic;

namespace MonitoringApp.Models
{
    public class Node
    {   
        public string Path { get; set; }        
        public string ParentNode { get; set; }
        public List<string> Directories { get; set; }
        public List<string> Files { get; set; } 

        public Node()
        {
            Path = string.Empty;
            ParentNode = string.Empty;
            Directories = new List<string>();
            Files = new List<string>();
        }
    }
}