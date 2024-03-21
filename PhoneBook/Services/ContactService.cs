using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Brokers.Loggings;
using PhoneBook.Brokers.Storages;
using PhoneBook.Models.Contacts;

namespace PhoneBook.Services
{
    public class ContactService : IContactService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public ContactService()
        {
            storageBroker = new StorageBroker();
            loggingBroker = new LoggingBroker();
        }

        public Contact AddCantact(Contact contact)
        {
            if (contact.Id is 0
                || contact.Name is null
                || contact.PhoneNumber is null)
            {
                this.loggingBroker.LogError("Contact is null");

                return new Contact();
            }
            else
            {
                this.storageBroker.InsertContact(contact);
                this.loggingBroker.LogInformation("Contact added succesfully");

                return contact;
            }
        }

        public List<Contact> RetrieveAllContact()
        {
            List<Contact> contacts = this.storageBroker.SelectAllContacts();

            if (contacts.Count == 0)
                this.loggingBroker.LogError("There is no any contact");
            else
                this.loggingBroker.LogInformation("All contacts retrieved");

            return contacts;
        }

        public Contact RetrieveContactById(int id)
        {
            List<Contact> contacts = this.storageBroker.SelectAllContacts();

            foreach (var contact in contacts)
            {
                if (contact.Id == id)
                {
                    this.loggingBroker.LogInformation("Contact retrieved");

                    return contact;
                }
                else
                    this.loggingBroker.LogError($"There is no contact with such {id}");
            }

            return new Contact();
        }

        public Contact ModifyContact(Contact contact)
        {
            if (contact.Id is 0
                || contact.Name is null
                || contact.PhoneNumber is null)
            {
                this.loggingBroker.LogError("Contact is null");

                return new Contact();
            }
            else
            {
                this.storageBroker.UpdateContact(contact);
                this.loggingBroker.LogInformation("Contact modified");

                return contact;
            }
        }

        public Contact RemoveContact(Contact contact)
        {
            if (contact.Id is 0
                || contact.Name is null
                || contact.PhoneNumber is null)
            {
                this.loggingBroker.LogError("Contact is null");

                return new Contact();
            }
            else
            {
                this.storageBroker.DeleteContact(contact);
                this.loggingBroker.LogInformation("Contact removed");

                return contact;
            }
        }
    }
}
