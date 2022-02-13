using CustomersDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using CustomersDAL.Results;

namespace CustomersDAL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IConfiguration _configuration;

        public CustomerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string ConnectionString 
        { 
            get 
            { 
                return _configuration["ConnectionStrings:Default"];
            } 
        }

        public async Task<IReadOnlyList<Customer>> GetAll()
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                var queryResult = await conn.QueryAsync<Customer>("SELECT * FROM Customers");
                return queryResult.ToList();
            }
        }

        public async Task<CreateCustomerResult> CreateCustomer(Customer customer)
        { 
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                var guid = await conn.QueryFirstAsync<Guid>(@"INSERT INTO Customers 
                    (Company, FirstName, LastName, Email, Mobile) OUTPUT INSERTED.Id
                    VALUES (@Company, @FirstName, @LastName, @Email, @Mobile)", customer);
                return new CreateCustomerResult
                {
                    Id = guid
                };
            }
        }

        public async Task UpdateCustomer(Customer customer)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                var guid = await conn.QueryFirstAsync<Guid>(@"UPDATE Customers 
                    SET Company=@Company, 
                    FirstName=@FirstName, 
                    LastName=@LastName, 
                    Email=@Email, 
                    Mobile=@Mobile
                    WHERE Id=@Id", customer);
            }
        }

        public async Task DeleteCustomer(Guid Id)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.ExecuteAsync(@"DELETE FROM Customers WHERE Id=@Id", new {Id = Id});
            }
        }
    }
}
