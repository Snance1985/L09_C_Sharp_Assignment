public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public Contact(string firstName, string lastName, string phoneNumber, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public void PrintDetails()
    {
        Console.WriteLine($"First Name: {FirstName}");
        Console.WriteLine($"Last Name: {LastName}");
        Console.WriteLine($"Phone Number: {PhoneNumber}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine();
    }
}