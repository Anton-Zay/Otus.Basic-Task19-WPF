using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfHomeWork.Implementations;

namespace WpfHomeWork
{
    internal class MainWindowViewModel : ViewModel
    {
        public ICommand AddEmployeeCommand { get { return new Command(AddEmployee); } }
        public ICommand SearchEmployeeCommand { get { return new Command(SearchEmployee); } }
        public ICommand CreateNewTreeCommand { get { return new Command(CreateNewTree); } }
        public ObservableCollection<Employee> Employees { get; private set; } = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> SearchList { get; private set; } = new ObservableCollection<Employee>();
        public string Name { get; set; }
        public string Salary { get; set; }
        public string SearchSalary { get; set; }
        private EmployeeTree EmployeeTree { get; set; }
        public Employee Employee { get; set; }
        public Visibility TextBlock { get; set; } = Visibility.Collapsed;
        public Visibility ScrollViewer { get; set; } = Visibility.Visible;

        private void AddEmployee()
        {
            Employee = new Employee() { Name = this.Name, Salary = this.Salary };
            bool tryParseSalary = int.TryParse(Salary, out int parseSalary);
            if (tryParseSalary)
            {
                if (EmployeeTree == null)
                {
                    EmployeeTree = new EmployeeTree();
                }
                EmployeeTree.Add(Employee);
                RaisePropertyChanged(() => Employee);

                Employees.Clear();
                Traverse(EmployeeTree.root);

                Name = null;
                RaisePropertyChanged(() => Name);
            }

            Salary = null;
            RaisePropertyChanged(() => Salary);
        }

        private void SearchEmployee()
        {
            ScrollViewer = Visibility.Visible;
            TextBlock = Visibility.Collapsed;
            RaisePropertyChanged(() => ScrollViewer);
            RaisePropertyChanged(() => TextBlock);

            if (EmployeeTree != null)
            {
                EmployeeTree.searchList.Clear();
            }
            SearchList.Clear();

            if (EmployeeTree != null)
            {
                EmployeeTree.SearchBySalary(EmployeeTree.root, int.Parse(SearchSalary));

                if (EmployeeTree.searchList.Count > 0)
                {
                    foreach (Employee item in EmployeeTree.searchList)
                    {
                        SearchList.Add(item);
                    }
                }
                else
                {
                    ScrollViewer = Visibility.Collapsed;
                    TextBlock = Visibility.Visible;
                    RaisePropertyChanged(() => ScrollViewer);
                    RaisePropertyChanged(() => TextBlock);
                }
            }
            else
            {
                ScrollViewer = Visibility.Collapsed;
                TextBlock = Visibility.Visible;
                RaisePropertyChanged(() => ScrollViewer);
                RaisePropertyChanged(() => TextBlock);
            }
        }

        private void CreateNewTree()
        {
            Employees.Clear();
            SearchList.Clear();
            EmployeeTree = null;
            Employee = null;
            RaisePropertyChanged(() => Employee);

            ScrollViewer = Visibility.Visible;
            TextBlock = Visibility.Collapsed;
            RaisePropertyChanged(() => ScrollViewer);
            RaisePropertyChanged(() => TextBlock);

        }
        private void Traverse(Employee node)
        {
            if (node.left != null)
            {
                Traverse(node.left);
            }

            Employees.Add(node);

            if (node.right != null)
            {
                Traverse(node.right);
            }
        }
    }
}