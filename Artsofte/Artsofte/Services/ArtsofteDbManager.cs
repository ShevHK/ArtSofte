using ArtsofteDbModel.Context;
using ArtsofteDbModel.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Artsofte.Services
{
    public class ArtsofteDbManager : IDisposable
    {
        private readonly ArtsofteDbContext _context;

        public ArtsofteDbManager(ArtsofteDbContext context)
        {
            _context = context;
        }

        #region ProgrammingLanguages
        public IQueryable<ProgrammingLanguage> AllProgrammingLanguage()
        {
            return _context.ProgrammingLanguages.AsQueryable();
        }
        public async Task<bool> AddProgrammingLanguages(List<ProgrammingLanguage> programmingLanguages)
        {
            var res = false;
            try
            {
                foreach (var item in programmingLanguages)
                {
                    _context.ProgrammingLanguages.Add(item);
                }
                await _context.SaveChangesAsync();
                res = true;
            }
            catch (Exception ex) { }
            return res;
        }
        public async Task<bool> DeleteProgrammingLanguage(int id)
        {
            var res = false;
            var item = _context.ProgrammingLanguages.Find(id);
            if (item != null)
            {
                try
                {
                    _context.ProgrammingLanguages.Remove(item);
                    await _context.SaveChangesAsync();
                    res = true;
                }
                catch (Exception ex) { }
            }
            return res;
        }
        public async Task<ProgrammingLanguage> GetProgrammingLanguage(int id)
        {
            return _context.ProgrammingLanguages.Find(id);
        }
        public async Task<(bool, string)> AddOrUpdateProgrammingLanguages(ProgrammingLanguage employee)
        {
            var res = (false, "");
            try
            {
                string text;
                if (employee.Id == default(int))
                {
                    // New entity
                    _context.ProgrammingLanguages.Add(employee);
                    text = "Programming Language added";
                }
                else
                {
                    // Existing entity
                    _context.Entry(employee).State = EntityState.Modified;
                    text = "Programming Language updated";

                }
                await _context.SaveChangesAsync();
                res = (true, text);
            }
            catch (Exception ex)
            {
                res = (false, "Connection wrong");
            }
            return res;
        }


        #endregion

        #region Department
        public IQueryable<Department> AllDepartments()
        {
            return _context.Departments.AsQueryable();
        }
        public async Task<bool> AddDepartment(Department department)
        {
            var res = false;
            try
            {
                _context.Departments.Add(department);
                await _context.SaveChangesAsync();
                res = true;
            }
            catch (Exception ex) { }
            return res;
        }
        public async Task<bool> AddDepartments(List<Department> departments)
        {
            var res = false;
            try
            {
                foreach (var item in departments)
                {
                    _context.Departments.Add(item);
                }
                await _context.SaveChangesAsync();
                res = true;
            }
            catch (Exception ex) { }
            return res;
        }
        public async Task<bool> DeleteDepartment(int id)
        {
            var res = false;
            var item = _context.Departments.Find(id);
            if (item != null)
            {
                try
                {
                    _context.Departments.Remove(item);
                    await _context.SaveChangesAsync();
                    res = true;
                }
                catch (Exception ex) { }
            }
            return res;
        }
        public async Task<Department> GetDepartment(int id)
        {
            return _context.Departments.Find(id);
        }
        public async Task<(bool, string)> AddOrUpdateDepartment(Department employee)
        {
            var res = (false, "");
            try
            {
                string text;
                if (employee.Id == default(int))
                {
                    // New entity
                    _context.Departments.Add(employee);
                    text = "Department added";
                }
                else
                {
                    // Existing entity
                    _context.Entry(employee).State = EntityState.Modified;
                    text = "Department updated";

                }
                await _context.SaveChangesAsync();
                res = (true, text);
            }
            catch (Exception ex)
            {
                res = (false, "Connection wrong");
            }
            return res;
        }


        #endregion

        #region Employee
        public IQueryable<Employee> AllEmployee()
        {
            return _context.Employees.AsQueryable();
        }
        public async Task<Employee> GetEmployee(int id)
        {
            return _context.Employees.Find(id);
        }
        public IQueryable<Employee> AllIncludingEmployee(params Expression<Func<Employee, object>>[] includeProperties)
        {
            IQueryable<Employee> query = _context.Employees;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public async Task<(bool, string)> AddOrUpdateEmployee(Employee employee)
        {
            var res = (false, "");
            try
            {
                string text;
                if (employee.Id == default(int))
                {
                    // New entity
                    _context.Employees.Add(employee);
                    text = "Employee added";
                }
                else
                {
                    // Existing entity
                    _context.Entry(employee).State = EntityState.Modified;
                    text = "Employee updated";

                }
                await _context.SaveChangesAsync();
                res = (true, text);
            }
            catch (Exception ex)
            {
                res = (false, "Connection wrong");
            }
            return res;
        }
        public async Task<bool> AddEmployees(List<Employee> employees)
        {
            var res = false;
            try
            {
                foreach (var item in employees)
                {
                    _context.Employees.Add(item);
                }
                await _context.SaveChangesAsync();
                res = true;
            }
            catch (Exception ex) { }
            return res;
        }
        public async Task<bool> DeleteEmployee(int id)
        {
            var res = false;
            var item = _context.Employees.Find(id);
            if (item != null)
            {
                try
                {
                    _context.Employees.Remove(item);
                    await _context.SaveChangesAsync();
                    res = true;
                }
                catch (Exception ex) { }
            }
            return res;
        }
        #endregion

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
