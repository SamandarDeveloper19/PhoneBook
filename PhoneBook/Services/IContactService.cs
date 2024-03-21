using PhoneBook.Models.Contacts;

namespace PhoneBook.Services
{
    public interface IContactService
    {
        Contact AddCantact(Contact contact);
        List<Contact> RetrieveAllContact();
        Contact RetrieveContactById(int id);
        Contact ModifyContact(Contact contact);
        Contact RemoveContact(Contact contact);
    }
}
