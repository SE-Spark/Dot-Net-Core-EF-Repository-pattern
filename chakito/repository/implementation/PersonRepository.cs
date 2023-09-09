using chakito.Models;

namespace chakito.repository.implementation
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly DatabaseContext context;

        public PersonRepository( DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Person model)
        {
            context.persons.Add(model);
            var saved = context.SaveChanges();
            if(saved == 1)
            {
                return true;
            }
            return false;
        }

        public bool DeleteById(int id)
        {
            var person = context.persons.SingleOrDefault(x => x.ID == id);
            if (person != null)
            {
               context.persons.Remove(person);
                var saved = context.SaveChanges();
                if(saved == 1)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public List<Person> GetAll()
        {
            return context.persons.ToList();
        }

        public Person GetById(int id)
        {
            var person = context.persons.SingleOrDefault(x => x.ID == id);
            if(person == null)
            {
                return new Person();
            }
            return person;
        }

        public bool Update(Person model)
        {
            var person = context.persons.SingleOrDefault(x => x.ID == model.ID);
            if (person != null)
            {
                person.email = model.email;
                person.name = model.name;
                context.persons.Update(person);
               var saved =  context.SaveChanges();
                if(saved == 1)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
