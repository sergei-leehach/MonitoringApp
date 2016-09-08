using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MonitoringApp.Models;

namespace MonitoringApp.Repository
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
            }
            return node;
        }

        public Counter GetCounter()
        {
            var drives = Environment.GetLogicalDrives();
            Counter counter = new Counter();

            foreach (var drive in drives)
            {
                counter += GetFileCounter(drive);
            }
            return counter;
        }

        public Node GetNode(string path)
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
            return node;
        }

        public Counter GetFileCounter(string path)
        {
            Counter counter = new Counter();
            foreach (var file in GetFiles(path))
            {
                var fileLength = new FileInfo(path + file).Length;

                if (fileLength <= 10485760)
                {
                    counter.Less10Mb++;
                }
                if (fileLength > 10485760 && fileLength < 52428800)
                {
                    counter.From10MbTo50Mb++;
                }
                if (fileLength > 104857600)
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