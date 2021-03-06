﻿using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Customers
{
    public class EditCustomerCommandHandler : ICommandHandler<EditCustomerCommand, EditCustomerCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EditCustomerCommandHandler(ICustomerRepository customerRepository, 
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EditCustomerCommandResponse> HandleAsync(EditCustomerCommand command)
        {
            var customerId = new CustomerIdentity(command.Id);

            var customer = await _customerRepository.FindAsync(customerId);

            if(customer == null)
            {
                throw new ValidationException($"Customer {customerId} does not exist");
            }

            UpdateCustomer(customer, command);

            await _customerRepository.UpdateAsync(customer);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Customer, EditCustomerCommandResponse>(customer);
        }

        private void UpdateCustomer(Customer customer, EditCustomerCommand request)
        {
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
        }
    }
}