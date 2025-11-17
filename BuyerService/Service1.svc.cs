using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BuyerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        // Format: line of id:name

        // List all buyers from the database and return their id and name
        public List<(int, String)> getBuyers()
        {
            String home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            String path = Path.Combine(home, "buyers.txt");

            List<(int, String)> ret = new List<(int, String)> ();

            try
            {
                foreach (String line in File.ReadLines(path))
                {
                    String[] tokens = line.Split(':');
                    int id = int.Parse(tokens[0]);
                    String name = tokens[1];

                    ret.Add((id, name));
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ret;
        }

        // Given an ID, resolve a name, return null if not found
        public String getBuyerName(int id)
        {
            String home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            String path = Path.Combine(home, "buyers.txt");


            try
            {
                foreach (String line in File.ReadLines(path))
                {
                    // If the found ID matches our id, return.
                    String[] tokens = line.Split(':');
                    int num = int.Parse(tokens[0]);
                    if (num == id) return tokens[1];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public int addBuyer(String name) {
            String home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            String path = Path.Combine(home, "buyers.txt");

            // Keep score of the largest discovered ID number
            int largest = 0;

            try
            {
                foreach (String line in File.ReadLines(path))
                {
                    String[] tokens = line.Split(':');
                    int id = int.Parse(tokens[0]);
                    if (id > largest) largest = id;

                    String found_name = tokens[1];

                    // Disallow duplicate names for now
                    if (name == found_name) return -1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            int new_id = largest + 1;
            using (StreamWriter stream = new StreamWriter(path))
            {
                stream.WriteLine($"{new_id}:{name}");
            }
            return new_id;
        }
    }
}
