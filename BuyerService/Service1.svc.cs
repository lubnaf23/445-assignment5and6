using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace BuyerService
{
    public class Service1 : IService1
    {
        private string GetXmlPath()
        {
            return HttpContext.Current.Server.MapPath("~/Member.xml");
        }

        // Format: line of id:name

        // List all buyers from the database and return their email and name
        public List<Buyer> getBuyers()
        {

            List<Buyer> ret = new List<Buyer>();

            try
            {
                string path = GetXmlPath();
                XDocument doc = XDocument.Load(path);
                foreach (var member in doc.Descendants("member"))
                {
                    string email = member.Element("email")?.Value;
                    string name = member.Element("name")?.Value;
                    string hashedPw = member.Element("hashedPw")?.Value;

                    ret.Add(new Buyer { Email = email, Name = name, HashedPw = hashedPw });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ret;
        }

        // Given an email, resolve a name, return null if not found
        public String getBuyerName(string email)
        {
            try
            {
                string path = GetXmlPath();
                XDocument doc = XDocument.Load(path);
                var member = doc.Descendants("member")
                                .FirstOrDefault(m => m.Element("email")?.Value == email);

                if (member != null)
                    return member.Element("name")?.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public bool addBuyer(string email, string hashedPw, string name)
        {
            try
            {
                string path = GetXmlPath();
                XDocument doc;
                if (File.Exists(path))
                {
                    doc = XDocument.Load(path);

                    // Disallow duplicate emails
                    if (doc.Descendants("member").Any(m => m.Element("email")?.Value == email))
                        return false;
                }
                else
                {
                    doc = new XDocument(new XElement("members"));
                }

                // Add new member
                doc.Root.Add(new XElement("member",
                    new XElement("email", email),
                    new XElement("hashedPw", hashedPw),
                    new XElement("name", name)
                ));

                doc.Save(path);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
    }
}
