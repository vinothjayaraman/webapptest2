using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                //DatabaseUtil.CleanUp();
                DatabaseUtil.initializeDatabase();
                PhoneBook phonebook = new PhoneBook();
                /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */

                // TODO: insert the new person objects into the database
                Person objPerson1 = new Person { name = "John Smith", phoneNumber = "(248) 123-4567", address = "1234 Sand Hill Dr, Royal Oak, MI" };
                Person objPerson2 = new Person { name = "Cynthia Smith", phoneNumber = "(824) 128-8758", address = "875 Main St, Ann Arbor, MI" };
                phonebook.addPerson(objPerson1);
                phonebook.addPerson(objPerson2);


                // TODO: print the phone book out to System.out
                Console.WriteLine("###########PHONE BOOK##############");
                foreach (Person person in phonebook.GetPhoneBook)
                {
                    Console.WriteLine("Name: {0}, Phone Number: {1}, Address: {2}", person.name, person.phoneNumber, person.address);
                }
                Console.WriteLine("###################################");
                // TODO: find Cynthia Smith and print out just her entry
                string strFN = "Cynthia";
                string strLN = "Smith";
                Person findpersion = phonebook.findPerson(strFN, strLN);
                Console.WriteLine("Name: " + findpersion.name);
                Console.WriteLine("Phone Number: " + findpersion.phoneNumber);
                Console.WriteLine("Address: "+ findpersion.address);

                Console.ReadLine();
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
    }
}
