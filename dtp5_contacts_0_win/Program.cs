using System;
using System.IO;

namespace dtp5_contacts_0
{
    class MainClass
    {
        static Person[] contactList = new Person[100];
        class Person
        {
            public string persname, surname, phone, address, city, birthdate;

            //Constructor
            public Person(string persname, string surname, string phone, string address, string city, string birthdate)
            {
                this.persname = persname;
                this.surname = surname;
                this.phone = phone;
                this.address = address;
                this.city = city;
                this.birthdate = birthdate;
            }
        }
        
        //Added helpText method for printing help commands

        private static void helpText()
        {
            Console.WriteLine("\n  delete       - empty the contact list!");
            Console.WriteLine("  delete /persname/ /surname/ - delete a person");
            Console.WriteLine("  load        - load contact list data from the file address.lis");
            Console.WriteLine("  load /file/ - load contact list data from the file");
            Console.WriteLine("  new        - create new person");
            Console.WriteLine("  new /persname/ /surname/ - create new person with personal name and surname");
            Console.WriteLine("  quit        - quit the program");
            Console.WriteLine("  save         - save contact list data to the file previously loaded");
            Console.WriteLine("  save /file/ - save contact list data to the file");
            Console.WriteLine();
        }

        //Added loadFile static method for loading data from file

        private static void loadFile(string lastFileName)
        {
            using (StreamReader infile = new StreamReader(lastFileName))
            {
                string line;
                while ((line = infile.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    string[] attrs = line.Split('|');
                    Person p = new Person(attrs[0], attrs[1], attrs[2], attrs[3], attrs[4], attrs[5]);
                    for (int ix = 0; ix < contactList.Length; ix++)
                    {
                        if (contactList[ix] == null)
                        {
                            contactList[ix] = p;
                            break;
                        }
                    }
                }
            }
        }

        //Added input method for shortening the code

        private static string input(string input)
        {
            Console.WriteLine(input);
            return Console.ReadLine();
        }

        //Added savePrint to print the contact list to the file

        private static void savePrint(StreamWriter outfile)
        {
            foreach (Person p in contactList)
            {
                if (p != null)
                    outfile.WriteLine($"{p.persname}|{p.surname}|{p.phone}|{p.address}|{p.city}|{p.birthdate}");
            }
        }


        public static void Main(string[] args)
        {
            string lastFileName = "address.lis";
            string[] commandLine;
            Console.WriteLine("Hello and welcome to the contact list");
            helpText();
            do
            {
                Console.Write($"> ");
                commandLine = Console.ReadLine().Split(' ');
                if (commandLine[0] == "quit")
                {                    
                    Console.WriteLine("Not yet implemented: safe quit");
                }
                else if (commandLine[0] == "load")
                {
                    if (commandLine.Length < 2)
                    {
                        lastFileName = "address.lis";
                        loadFile(lastFileName);
                    }
                    else
                    {
                        lastFileName = commandLine[1];
                        loadFile(lastFileName);
                    }
                }
                else if (commandLine[0] == "save")
                {
                    if (commandLine.Length < 2)
                    {                       
                        using (StreamWriter outfile = new StreamWriter(lastFileName))
                        {
                            savePrint(outfile);
                        }
                    }
                    else
                    {
                        string fileName = @"C:\Users\Gusta\source\repos\Telefonlista\dtp5_contacts_0_win\bin\Debug\" + lastFileName;
                        using (StreamWriter outfile = new StreamWriter(fileName))
                        {
                            savePrint(outfile);
                        }
                    }
                }
                else if (commandLine[0] == "new")
                {
                    if (commandLine.Length < 2)
                    {
                        string persname = input("Enter personal name: ");
                        string surname = input("Enter surname: ");
                        string phone = input("Enter phone number: ");
                        string adress = input("Enter adress: ");
                        string city = input("Enter city: ");
                        string birthdate = input("Enter birthdate: ");

                        Person p = new Person(persname, surname, phone, adress, city, birthdate);

                        for (int ix = 0; ix < contactList.Length; ix++)
                        {
                            if (contactList[ix] == null)
                            {
                                contactList[ix] = p;
                                break;
                            }
                        }
                    }
                    else
                    {
                        // NYI!
                        Console.WriteLine("Not yet implemented: new /person/");
                    }
                }
                else if (commandLine[0] == "help")
                {
                    helpText();
                }
                else
                {
                    Console.WriteLine($"Unknown command: '{commandLine[0]}'");
                }
            } while (commandLine[0] != "quit");
        }       
    }
}
