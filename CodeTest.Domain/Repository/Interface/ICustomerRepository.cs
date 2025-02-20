﻿using System.Threading.Tasks;
using CodeTest.Domain.Commands;
using CodeTest.Domain.Entities;

namespace CodeTest.Domain.Repository.Interface
{
    public interface ICustomerRepository
	{
		Task<CustomerDetails> GetCustomerDetails(string id);
		Task<CustomerDetails> AddCustomerDetails(AddCustomerInfoCommand user);
	}
}

