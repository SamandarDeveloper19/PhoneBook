using System.Runtime.CompilerServices;
using PhoneBook.Models.Contacts;
using PhoneBook.Services;

namespace PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IContactService contactService = new ContactService();


            while (true)
            {
                Console.WriteLine(
                "1. Add contact\n" +
                "2. Get all contact\n" +
                "3. Get contact by id\n" +
                "4. Update contact\n" +
                "5. Delete contact");

                Console.Write("Which one do you want: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            Contact contact = new Contact();
                            Console.Write("Enter contact id: ");
                            contact.Id = int.Parse(Console.ReadLine());
                            Console.Write("Enter contact Name: ");
                            contact.Name = Console.ReadLine();
                            Console.Write("Enter contact phone number: ");
                            contact.PhoneNumber = Console.ReadLine();
                            contactService.AddCantact(contact);

                            break;
                        }
                    case 2:
                        {
                            List<Contact> contacts = contactService.RetrieveAllContact();

                            foreach (var contact in contacts)
                            {
                                Console.WriteLine(
                                    $"{contact.Id}-{contact.Name}-{contact.PhoneNumber}");
                            }

                            break;
                        }
                    case 3:
                        {
                            Console.Write("Enter contact id: ");
                            int id = int.Parse(Console.ReadLine());
                            Contact contact = contactService.RetrieveContactById(id);

                            Console.WriteLine(
                                    $"{contact.Id}-{contact.Name}-{contact.PhoneNumber}");

                            break;
                        }
                    case 4:
                        {
                            Contact contact = new Contact();
                            Console.Write("Enter contact id: ");
                            contact.Id = int.Parse(Console.ReadLine());
                            Console.Write("Enter contact Name: ");
                            contact.Name = Console.ReadLine();
                            Console.Write("Enter contact phone number: ");
                            contact.PhoneNumber = Console.ReadLine();
                            contactService.ModifyContact(contact);

                            break;
                        }
                    case 5:
                        {
                            Contact contact = new Contact();
                            Console.Write("Enter contact id: ");
                            contact.Id = int.Parse(Console.ReadLine());
                            Console.Write("Enter contact Name: ");
                            contact.Name = Console.ReadLine();
                            Console.Write("Enter contact phone number: ");
                            contact.PhoneNumber = Console.ReadLine();
                            contactService.RemoveContact(contact);

                            break;
                        }

                }

                Console.WriteLine("1. Back to home");
                Console.WriteLine("2. Exit");

                if (int.Parse(Console.ReadLine()) == 2)
                    break;
            }

            Console.WriteLine("Thank you for using");
        }
    }
}