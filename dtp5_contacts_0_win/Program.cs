﻿using System;
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
            Console.WriteLine("\n  delete       - emtpy the contact list!");
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
                    string[] attrs = line.Split(';');
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
                    // NYI!
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
                            foreach (Person p in contactList)
                            {
                                if (p != null)
                                    outfile.WriteLine($"{p.persname};{p.surname};{p.phone};{p.address};{p.city};{p.birthdate}");
                            }
                        }
                    }
                    else
                    {
                        // NYI!
                        Console.WriteLine("Not yet implemented: save /file/");
                    }
                }
                else if (commandLine[0] == "new")
                {
                    if (commandLine.Length < 2)
                    {
                        Console.Write("personal name: ");
                        string persname = Console.ReadLine();
                        Console.Write("surname: ");
                        string surname = Console.ReadLine();
                        Console.Write("phone: ");
                        string phone = Console.ReadLine();
                        Console.Write("phone: ");
                        string adress = Console.ReadLine();
                        Console.Write("phone: ");
                        string birthdate = Console.ReadLine();

                        //Person[] contactList = new Person[5];


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
