using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LogMeTool.Utilities
{
    public class Configuration
    {
        private string rootNode;
        public string RootNode
        {
            get
            {
                return rootNode;
            }
            set
            {
                rootNode = value;
            }
        }
        private string nodeForEdit { get; set; }
        public string NodeForEdit
    {
            get
            {
                return nodeForEdit;
            }
            set
            {
                nodeForEdit = value;
            }
        }
        private string configPath { get; set; }
        public string ConfigPath
        {
            get
            {
                return configPath;
            }
            set
            {
                configPath = value;
            }
        }

        public Configuration(string root, string editThisNode, string path)
        {
            RootNode = root;
            NodeForEdit = editThisNode; 
            NodeForEdit = path; 
        }

        private static XmlDocument LoadConfigDocument(string configFilePath)
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(configFilePath);
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }
        public static void ChangeValueByKey (string key, string value, string attributeForChange, Configuration config)
        {
            XmlDocument doc = LoadConfigDocument(config.ConfigPath);
            XmlNode rootNode = doc.SelectSingleNode(config.RootNode);

            if (rootNode == null)
            {
                throw new InvalidOperationException("the root node section not found in config file.");
            }

            try
            {
                XmlElement elem = (XmlElement)rootNode.SelectSingleNode
                                (string.Format(config.NodeForEdit, key));
                elem.SetAttribute(attributeForChange, value);
                doc.Save(config.ConfigPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      

        public static void RefreshAppSettings()
        {
            ConfigurationManager.RefreshSection("appSettings");
        }
    }

}
