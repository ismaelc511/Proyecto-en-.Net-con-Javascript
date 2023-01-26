using Microsoft.EntityFrameworkCore;
using CustomersApi2.Dtos;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CustomersApi2.Repositories
{
    public class CustomerDatabaseContext : DbContext

    {

        public CustomerDatabaseContext(DbContextOptions<CustomerDatabaseContext> options) 
            : base(options)
        { 
            
        }

        public DbSet<CustomerEntity> Customer { get; set; }


        public async Task<CustomerEntity> Get(long id)
        { 
            return await Customer.FirstAsync(x =>x.Id == id);
        }

        public async Task<CustomerEntity> Add(CreateCustomerDto customerDto)
        { 
            CustomerEntity entity= new CustomerEntity()
            {
                Id = null,
                Address = customerDto.Address,
                Email = customerDto.Email,
                FirstName = customerDto.FistName,
                LastName = customerDto.LastName,
            };

            EntityEntry<CustomerEntity> response = await Customer.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(response.Entity.Id ?? throw new Exception("No se ha podido guardar"));


        }
    }

    public class CustomerEntity
    {

        public long? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }


        public CustomerDto ToDto()
        {
            return new CustomerDto()
            {
                Address = Address,
                Email = Email,
                FirsName = FirstName,
                LastName = LastName,
                Phone = Phone,
                Id = Id ?? throw new Exception("El id no puede ser null")

            };
        }
    }
}
