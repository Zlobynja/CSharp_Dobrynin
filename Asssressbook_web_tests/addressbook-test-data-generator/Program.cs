using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Addressbook_web_tests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test_data_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]); //передаем кол-во тестовых данных, которое хотим сгенерировать
            StreamWriter writer = new StreamWriter(args[2]);//запись в файл
            string format = args[3];

            if (dataType == "group" || dataType == "groups")
            {
                List<GroupData> groups = new List<GroupData>();

                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100)
                    });
                };
                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else if (format == "excel")
                {
                    writeGroupsToExcelFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }
            }
            else if (dataType == "contact" || dataType == "contacts")
            {
                List<ContactData> contact = new List<ContactData>();
                {
                    for (int i = 0; i < count; i++)
                    {
                        contact.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10)));
                    }

                    if (format == "csv")
                    {
                        writeContactsToCsvFile(contact, writer);
                    }
                    else if (format == "xml")
                    {
                        writeContactsToXmlFile(contact, writer);
                    }
                    else if (format == "json")
                    {
                        writeContactsToJsonFile(contact, writer);
                    }
                    else if (format == "excel")
                    {
                        writeContactsToExcelFile(contact, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format" + format);
                    }
                }
            }
            writer.Close();
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                  group.Name, group.Header, group.Footer));
            }
        }


        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
        static void writeGroupsToExcelFile(List<GroupData> groups, StreamWriter writer)
        { }

        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1}",
                 contact.Firstname, contact.Lastname));
            }
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
        static void writeContactsToExcelFile(List<ContactData> contact, StreamWriter writer)
        { }
    }
}