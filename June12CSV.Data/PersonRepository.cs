using Microsoft.EntityFrameworkCore;

namespace June12CSV.Data
{
    public class PersonRepository
    {
        private readonly string _connectionString;

        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddPeople(List<Person> people)
        {
            using var context = new PersonDataContext(_connectionString);
            context.People.AddRange(people);
            context.SaveChanges();  
        }
        public void DeletePeople()
        {
            using var context = new PersonDataContext(_connectionString);
            context.Database.ExecuteSqlInterpolated(@$"DELETE FROM People");
        }
        public List<Person> GetPeople()
        {
            using var context = new PersonDataContext(_connectionString);
            return context.People.ToList();
        }
        public List<Person> GeneratePeople(int amount)
        {
            return Enumerable.Range(1, amount).Select(_ => new Person
            {
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                Age = Faker.RandomNumber.Next(20, 100),
                Address = Faker.Address.StreetAddress(),
                Email = Faker.Internet.Email()
        }).ToList();
        }
    }
}