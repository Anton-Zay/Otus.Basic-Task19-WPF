using WpfHomeWork.Implementations;

namespace WpfHomeWork
{
    internal class Employee : ViewModel
    {
        public string Name { get; set; }
        public string Salary { get; set; }
        public Employee left { get; set; }
        public Employee right { get; set; }
        public string EmployeeString => $"{Name} имеет зарплату {Salary} руб.";
    }
}