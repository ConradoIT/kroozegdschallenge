using Krooze.EntranceTest.WriteHere.Structure.Model;
using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public class XMLTest
    {
        public CruiseDTO TranslateXML()
        {
            //TODO: Take the Cruises.xml file, on the Resources folder, and translate it to the CruisesDTO object,           
            XmlSerializer XmlSerializer = new XmlSerializer(typeof(CruiseDTO));
            using (Stream Stream = new FileStream($"{AppDomain.CurrentDomain.BaseDirectory}/Resources/Cruises.xml", FileMode.Open))
                return (CruiseDTO)XmlSerializer.Deserialize(Stream);
        }
    }
}
