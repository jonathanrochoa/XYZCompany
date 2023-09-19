using XYZCompany.Entities;
using XYZCompany.Repositories;
using XYZCompany.Requests;
using XYZCompany.Responses;

namespace XYZCompany.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponse> Get(Guid id)
        {
            var employee = await _employeeRepository.Get(id);

            var response = new EmployeeResponse
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                TitleId = employee.TitleId,
                TitleDescription = employee.Title.Description
            };
            return response;
        }

        public async Task<List<EmployeeResponse>> GetAll()
        {
            var employees = await _employeeRepository.GetAll();
            var response = employees.Select(employee=>new EmployeeResponse 
            { 
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                TitleId = employee.TitleId,
                TitleDescription = employee.Title.Description
            }).ToList();

            return response;
        }

        public async Task<List<EmployeeResponse>> Search(string keyword)
        {
            var employees = await _employeeRepository.Search(keyword);

            var response = employees.Select(employee => new EmployeeResponse
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                TitleId = employee.TitleId,
                TitleDescription = employee.Title.Description
            }).ToList();

            return response;
        }

        public async Task<EmployeeResponse> Create(EmployeeRequest request)
        {
            if (string.IsNullOrEmpty(request.FirstName))
            {
                throw new Exception("FirstName cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.LastName))
            {
                throw new Exception("LastName cannot be empty.");
            }

            if (request.BirthDate == default)
            {
                throw new Exception("BirthDate cannot be empty.");
            }

            if (request.TitleId == default)
            {
                throw new Exception("TitleId cannot be empty.");
            }

            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                Gender = request.Gender,
                TitleId = request.TitleId
            };

            await _employeeRepository.Create(employee);

            var response = await Get(employee.Id);
            return response;
        }

        public async  Task<EmployeeResponse> Update(Guid id, EmployeeRequest request)
        {
            var employee = await _employeeRepository.Get(id);

            if(string.IsNullOrEmpty(request.FirstName))
            {
                throw new Exception("FirstName cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.LastName))
            {
                throw new Exception("LastName cannot be empty.");
            }

            if(request.BirthDate == default)
            {
                throw new Exception("BirthDate cannot be empty.");
            }

            if (request.TitleId == default)
            {
                throw new Exception("TitleId cannot be empty.");
            }


            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.BirthDate = request.BirthDate;
            employee.Gender = request.Gender;
            employee.TitleId = request.TitleId;

            await _employeeRepository.Update(employee);

            var response = await Get(employee.Id);
            return response;
        }

        public async Task Delete(Guid id)
        {
            var employeeToDelete = await _employeeRepository.Get(id);

            if(employeeToDelete == null) 
            {
                throw new Exception($"Record with Id {id} not found.");
            }

            await _employeeRepository.Delete(id);
        }
    }
}
