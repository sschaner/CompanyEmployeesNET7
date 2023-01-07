﻿namespace CompanyEmployees.Service.Contracts
{
    using CompanyEmployees.Shared.DataTransferObjects;

    public interface ICompanyService
    {
        /// <summary>
        /// Gets all companies.
        /// </summary>
        /// <param name="trackChanges">if set to <c>true</c> [track changes].</param>
        /// <returns></returns>
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
    }
}