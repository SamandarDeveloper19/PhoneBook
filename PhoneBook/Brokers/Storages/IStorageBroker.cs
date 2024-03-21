using PhoneBook.Models.Contacts;

namespace PhoneBook.Brokers.Storages
{
    public interface IStorageBroker
    {
        Contact InsertContact(Contact contact);
        List<Contact> SelectAllContacts();
        Contact SelectContactById(int id);
        Contact UpdateContact(Contact contact);
        Contact DeleteContact(Contact contact);
    }
}
