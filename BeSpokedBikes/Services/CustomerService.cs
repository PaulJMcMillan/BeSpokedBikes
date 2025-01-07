using BeSpokedBikes.Interfaces;
using BeSpokedBikes.Models;

namespace BeSpokedBikes.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<List<Customer>> GetAllAsync()
        {
            return _customerRepository.GetAllAsync();
        }
    }
}
