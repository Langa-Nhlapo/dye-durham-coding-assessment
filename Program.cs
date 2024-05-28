using System;
using System.IO;

namespace Application
{
  class Program
  {
    class Person
    {
      public string FirstName;
      public string LastName;
      public Person(string firstName, string lastName)
      {
        FirstName = firstName;
        LastName = lastName;
      }
    }

    class PersonComparer : IComparer<Person>
    {
      public int Compare(Person x, Person y)
      {
        return x.LastName.CompareTo(y.LastName);
      }
    }

    static void Main(string[] args)
    {
      String line, _firstName = "", _lastName = "";
      List<Person> people = new List<Person>();
      Person person;

      try
      {
          // Pass the file path and file name to the StreamReader constructor
          StreamReader sr = new StreamReader("unsorted-names-list.txt");

          // Pass the filepath and filename to the StreamWriter Constructor
          StreamWriter sw = new StreamWriter("sorted-names-list.txt");

          // Read the first line of text
          line = sr.ReadLine();

          // Continue to read until you reach end of file while adding to the list of people
          while (line != null)
          {
            int index = line.IndexOf(" ");
            _firstName = line.Substring(0, index);
            _lastName = line.Substring(index + 1);

            people.Add(new Person(_firstName, _lastName));

            // Read the next line
            line = sr.ReadLine();
          }

          // Sort the list according to the lastname
          people.Sort(new PersonComparer());

          // Write the sorted list to a new sorted list textfile
          foreach (Person _person in people)
          {
            Console.WriteLine(_person.FirstName + " " + _person.LastName);
            sw.WriteLine(_person.FirstName + " " + _person.LastName);
          }

          //close the file
          sr.Close();

          //Close the file
          sw.Close();

          Console.ReadLine();
      }
      catch(Exception e)
      {
          Console.WriteLine("Exception: " + e.Message);
      }
      finally
      {
          Console.WriteLine("Executing finally block.");
      }
    }
  }
}
