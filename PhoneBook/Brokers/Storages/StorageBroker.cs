using PhoneBook.Models.Contacts;

namespace PhoneBook.Brokers.Storages
{
    public class StorageBroker : IStorageBroker
    {
        string path = "../../../Files/Contacts.txt";

        public StorageBroker() =>
            CreateFile();

        public void CreateFile()
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }

        public Contact InsertContact(Contact contact)
        {
            string info = $"{contact.Id}-{contact.Name}-{contact.PhoneNumber}\n";
            File.AppendAllText(path, info);

            return contact;
        }

        public List<Contact> SelectAllContacts()
        {
            List<Contact> contacts = new List<Contact>();
            string[] allLines = File.ReadAllLines(path);

            foreach (var line in allLines)
            {
                string[] info = line.Split('-');

                var contact = new Contact()
                {
                    Id = int.Parse(info[0]),
                    Name = info[1],
                    PhoneNumber = info[2],
                };

                contacts.Add(contact);
            }

            return contacts;
        }

        public Contact SelectContactById(int id)
        {
            string[] allLines = File.ReadAllLines(path);
            Contact contact = new Contact();

            foreach (var line in allLines)
            {
                string[] info = line.Split('-');

                if (int.Parse(info[0]) == id)
                {
                    contact.Id = int.Parse(info[0]);
                    contact.Name = info[1];
                    contact.PhoneNumber = info[2];
                }
            }

            return contact;
        }

        public Contact UpdateContact(Contact contact)
        {
            string[] allLines = File.ReadAllLines(path);

            for (int i = 0; i < allLines.Length; i++)
            {
                string[] info = allLines[i].Split('-');

                if (int.Parse(info[0]) == contact.Id)
                {
                    info[1] = $"{contact.Name}";
                    info[2] = $"{contact.PhoneNumber}";
                    string newInfo = string.Join("-", info);
                    allLines[i] = newInfo;
                    break;
                }
            }

            File.WriteAllLines(path, allLines);

            return contact;
        }

        public Contact DeleteContact(Contact contact)
        {
            string[] allLines = File.ReadAllLines(path);

            string[] newAllLines = (from line in allLines
                                   where !line.StartsWith($"{contact.Id}")
                                   select line).ToArray();

            File.WriteAllLines(path, newAllLines);

            return contact;
        }
    }
}
