using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        // add person details into phonebook
        public void addPerson(Person newPerson)
        {
            using (SQLiteConnection dbconnection = DatabaseUtil.GetConnection())
            {
                // realtime we can create a storeprocedure instead of the T-SQL
                SQLiteCommand command = new SQLiteCommand(string.Format("INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('{0}','{1}', '{2}')",newPerson.name,newPerson.phoneNumber,newPerson.address), dbconnection);
                int result = command.ExecuteNonQuery();
            }
        }
        // Search the phone book based on the name passed and return the details
        public Person findPerson(string firstName, string lastName)
        { 
            List<Person> getPhoneBooks = (List<Person>)GetPhoneBook;
            return getPhoneBooks.Find(per => per.name == (firstName + " " + lastName));
        }
        // Get all the phonebook details from DB
        public IEnumerable<Person> GetPhoneBook {
            get {
                List<Person> phonebooks = new List<Person>();
                using (SQLiteConnection dbconnection = DatabaseUtil.GetConnection())
                {
                    // realtime we can create a storeprocedure instead of the T-SQL
                    SQLiteCommand command = new SQLiteCommand("SELECT NAME,PHONENUMBER,ADDRESS FROM PHONEBOOK", dbconnection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Person objPer = new Person();
                        objPer.name = reader["NAME"].ToString();
                        objPer.phoneNumber = reader["PHONENUMBER"].ToString();
                        objPer.address = reader["ADDRESS"].ToString();

                        phonebooks.Add(objPer);
                    }
                }
                return phonebooks;
            }
        }
       
    }
}