using chakito.Models;

namespace chakito.repository.implementation
{
    public class CompanyRepository : IRepository<Company>
    {
        private DatabaseContext db;

        public CompanyRepository(DatabaseContext db)
        {
            this.db = db;
        }
        public bool Add(Company model)
        {
            db.companies.Add(model);
            var saved = db.SaveChanges();
            if(saved == 1)
            {
                return true;
            }
            return false;
        }

        public bool DeleteById(int id)
        {
            var company = db.companies.SingleOrDefault(x=>x.Id == id);
            if(company == null)
            {
                return false;
            }
            db.companies.Remove(company);
            var saved = db.SaveChanges();
            if (saved == 1)
            {
                return true;
            }
            return false;
        }

        public List<Company> GetAll()
        {
            return db.companies.ToList();   
        }

        public Company GetById(int id)
        {
            var company = db.companies.SingleOrDefault(x => x.Id == id);
            if (company == null)
            {
                return new Company();
            }
            return company;
        }

        public bool Update(Company model)
        {
            var company = db.companies.SingleOrDefault(x => x.Id == model.Id);
            if(company != null)
            {
                company.name = model.name;
                company.location = model.location;
                db.companies.Update(company);
                var saved = db.SaveChanges();
                if (saved == 1)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
