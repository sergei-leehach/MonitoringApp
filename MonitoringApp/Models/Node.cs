using System.Collections.Generic;
using System.Diagnostics;

namespace AngularJSApp.Models
{
    public class Node
    {   
        public string Path { get; set; }        
        public string ParentNode { get; set; }
        public Counter Counter { get; set; }
        public List<string> Directories { get; set; }
        public List<string> Files { get; set; } 

        public Node()
        {
            Path = string.Empty;
            ParentNode = string.Empty;
            Counter = new Counter();
            Directories = new List<string>();
            Files = new List<string>();
        }
    }
}