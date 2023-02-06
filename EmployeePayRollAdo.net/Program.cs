namespace EmployeePayRollAdo.net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to employee payroll");
            EmployeeModel employee = new EmployeeModel();
            EmployeeRepo repo = new EmployeeRepo();
            employee.EmployeeName = "pankaj";
            employee.Phoneno = "7558570105";
            employee.Address = "banglore";
            employee.Department = "Hr";
            employee.Gender = 'M';
            employee.BasicPay = 10000;
            employee.Deduction = 1000;
            employee.TaxablePay = 2000;
            employee.Tax = 111;
            employee.NetPay = 1111;
            employee.StartDate = DateTime.Now;
            employee.City = "Pune";
            employee.Country = "India";

            //repo.AddEmployee(employee);
            repo.GetAllEmployee();

        }
    }
}