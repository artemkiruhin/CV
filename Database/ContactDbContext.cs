using Microsoft.EntityFrameworkCore;

namespace Database {
    public class ContactDbContext : DbContext {

        public ContactDbContext () => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(
                DatabaseInformation.CONNECTION_STRING,
                MySqlServerVersion.AutoDetect(DatabaseInformation.CONNECTION_STRING)
                );
        }

        public DbSet<CV.DatabaseModels.Contact> Contacts { get; set; }

        public IEnumerable<CV.Models.Contact> GetAll() {
            var dbContacts = Contacts.ToList();
            var modelContacts = new List<CV.Models.Contact>();

            foreach (var contact in dbContacts)
            {
                var tmpModelContact = new CV.Models.Contact()
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    URL = contact.URL
                };

                modelContacts.Add(tmpModelContact);
            }

            return (IEnumerable<CV.Models.Contact>) modelContacts;

        }

        public CV.Models.Contact? GetContactById(int id) {
            var dbContact = _GetContactById(id);

            if (dbContact == null) return null;

            var modelContact = new CV.Models.Contact()
            {
                Id = dbContact.Id,
                Name = dbContact.Name,
                URL = dbContact.URL
            };

            return modelContact;

        }

        public void DeleteContactById(int id) {
            var dbContact = _GetContactById(id);

            if (dbContact != null)
            {
                Contacts.Remove(dbContact);
                SaveChanges();
            }
        }

        public void AddContact(CV.Models.Contact contact) {
            var contactToDb = new CV.DatabaseModels.Contact()
            {
                Id = contact.Id,
                Name = contact.Name,
                URL = contact.URL
            };

            
            Contacts.Add(contactToDb); // Assuming Feedbacks is your DbSet<Feedback> property in the context
            SaveChanges();
            
        }


        private CV.DatabaseModels.Contact? _GetContactById(int id) {
            var dbContact = Contacts.FirstOrDefault(x => x.Id == id);

            if (dbContact == null) return null;
            return dbContact;
        }

    }
}
