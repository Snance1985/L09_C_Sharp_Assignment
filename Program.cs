public class Program
{
    private static List<Contact> contactList;

    public static void Main()
    {
        contactList = LoadContactsFromFile(); // Load contacts from file

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Contact");
            Console.WriteLine("2. View All Contacts");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateNewContact();
                    break;
                case "2":
                    ViewAllContacts();
                    break;
                case "3":
                    SaveContactsToFile(contactList); // Save contacts to file
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void CreateNewContact()
    {
        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter Phone Number: ");
        string phoneNumber = Console.ReadLine();

        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        Contact newContact = new Contact(firstName, lastName, phoneNumber, email);
        contactList.Add(newContact);

        Console.WriteLine("New contact created successfully!");
        Console.WriteLine();
    }

    private static void ViewAllContacts()
    {
        if (contactList.Count == 0)
        {
            Console.WriteLine("No contacts found.");
        }
        else
        {
            Console.WriteLine("All Contacts:");
            foreach (Contact contact in contactList)
            {
                contact.PrintDetails();
            }
        }
        Console.WriteLine();
    }

    private static List<Contact> LoadContactsFromFile()
    {
        List<Contact> contacts = new List<Contact>();

        if (File.Exists("contacts.txt"))
        {
            try
            {
                string[] lines = File.ReadAllLines("contacts.txt");
                foreach (string line in lines)
                {
                    Contact contact = ConvertStringToContact(line);
                    contacts.Add(contact);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading contacts from file: " + ex.Message);
            }
        }

        return contacts;
    }

    private static void SaveContactsToFile(List<Contact> contacts)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("contacts.txt"))
            {
                foreach (Contact contact in contacts)
                {
                    string contactString = ConvertContactToString(contact);
                    writer.WriteLine(contactString);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving contacts to file: " + ex.Message);
        }
    }

    private static string ConvertContactToString(Contact contact)
    {
        return $"{contact.FirstName},{contact.LastName},{contact.PhoneNumber},{contact.Email}";
    }

    private static Contact ConvertStringToContact(string contactString)
    {
        string[] values = contactString.Split(',');
        if (values.Length == 4)
        {
            string firstName = values[0];
            string lastName = values[1];
            string phoneNumber = values[2];
            string email = values[3];

            return new Contact(firstName, lastName, phoneNumber, email);
        }

        throw new ArgumentException("Invalid contact string format.");
    }
}