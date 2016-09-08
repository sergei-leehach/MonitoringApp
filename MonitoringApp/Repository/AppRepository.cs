using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using AngularJSApp.Models;

namespace AngularJSApp.Repository
{
    public class AppRepository
    {
        public Node GetHardDrives()
        {
            var drives = Environment.GetLogicalDrives();
            Node node = new Node();

            foreach (var drive in drives)
            {
                node.Directories.Add(drive);
                node.Counter += GetFileCounter(drive);
            }
            return node;
        }

        public Node GetCount(string path)
        {
            Node node = new Node();
            if (Directory.GetParent(path) != null)
            {
                node.Path = path + "\\";
                node.ParentNode = Directory.GetParent(path).FullName;
            }
            else
            {
                node.Path = path;
            }
            node.Directories = GetDirectories(node.Path).ToList();
            node.Files = GetFiles(node.Path).ToList();
            node.Counter = GetFileCounter(node.Path);
            return node;
        }

        private static Counter GetFileCounter(string path)
        {
            Counter counter = new Counter();
            foreach (var file in GetFiles(path))
            {
                var fileLength = new FileInfo(path + file).Length;

                if (fileLength <= 10000000)
                {
                    counter.Less10Mb++;
                }
                if (fileLength > 10000000 && fileLength < 50000000)
                {
                    counter.From10MbTo50Mb++;
                }
                if (fileLength > 100000000)
                {
                    counter.More100Mb++;
                }
            }

            foreach (var directory in GetDirectories(path))
            {
                counter += GetFileCounter(path + directory);
            }
            return counter;
        }

        private static List<string> GetDirectories(string path)
        {
            List<string> directories = new List<string>();
            string[] dirArray = new string[] { };
            try
            {
                dirArray = Directory.GetDirectories(path);
            }
            catch (Exception)
            {

            }
            directories = Cut(path, dirArray);
            return directories.ToList();
        }

        private static List<string> GetFiles(string path)
        {
            List<string> files = new List<string>();
            string[] filesArray = new string[] { };
            try
            {
                filesArray = Directory.GetFiles(path);
            }
            catch
            {

            }
            files = Cut(path, filesArray);
            return files.ToList();
        }

        private static List<string> Cut(string path, string[] array)
        {
            var collection = array.Select(item => item.Replace(path, "")).ToList();
            return collection;
        }
    }
}