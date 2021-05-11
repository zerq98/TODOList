using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TodoList.Domain.Entity;

namespace TodoList.Domain.Reposiotry
{
    public static class FileRepository
    {
        public static void UpdateFile<T>(string name,List<T> models)
        {
            XmlSerializer serializer;

            var path = $"./{name}.xml";
            try
            {
                if (!File.Exists(path))
                {
                    serializer = new XmlSerializer(typeof(List<T>));
                    FileStream file = File.Create(path);
                    serializer.Serialize(file, models);
                    file.Close();
                }
                else
                {
                    serializer = new XmlSerializer(typeof(List<T>));
                    FileStream file = File.OpenWrite(path);
                    serializer.Serialize(file, models);
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<T> ReadFile<T>(string name)
        {
            XmlSerializer serializer;

            var models = new List<T>();

            var path = $"./{name}.xml";
            try
            {
                if (File.Exists(path))
                {
                    serializer = new XmlSerializer(typeof(List<T>));
                    FileStream file = File.OpenRead(path);
                    models = (List<T>)serializer.Deserialize(file);
                    file.Close();
                }

                return models;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Settings ReadSettings()
        {
            XmlSerializer serializer;

            var settings = new Settings();

            var path = $"./settings.xml";
            try
            {
                if (File.Exists(path))
                {
                    serializer = new XmlSerializer(typeof(Settings));
                    FileStream file = File.OpenWrite(path);
                    serializer.Serialize(file, settings);
                    file.Close();
                }

                return settings;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void UpdateSettings(Settings settings)
        {
            XmlSerializer serializer;

            var path = $"./settings.xml";
            try
            {
                if (!File.Exists(path))
                {
                    serializer = new XmlSerializer(typeof(Settings));
                    FileStream file = File.Create(path);
                    serializer.Serialize(file, settings);
                    file.Close();
                }
                else
                {
                    serializer = new XmlSerializer(typeof(Settings));
                    FileStream file = File.OpenWrite(path);
                    serializer.Serialize(file, settings);
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int GetLastId(string name)
        {
            XmlSerializer serializer;
            var path = $"./last{name}Id.xml";
            try
            {
                if (!File.Exists(path))
                {
                    serializer = new XmlSerializer(typeof(int));
                    FileStream file = File.Create(path);
                    serializer.Serialize(file, 1);
                    file.Close();
                    return 1;
                }
                else
                {
                    serializer = new XmlSerializer(typeof(int));
                    FileStream file = File.OpenRead(path);
                    var lastId = (int)serializer.Deserialize(file);
                    file.Close();
                    file = File.OpenWrite(path);
                    lastId++;
                    serializer.Serialize(file, lastId);
                    file.Close();

                    return lastId;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
