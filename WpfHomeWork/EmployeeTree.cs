using System.Collections.Generic;

namespace WpfHomeWork
{
    class EmployeeTree
    {
        public Employee root { get; private set; }
        public Employee cellHolder { get; private set; }
        public List<Employee> searchList { get; private set; } = new List<Employee>();

    public void Add(Employee node)
        {


            if (root == null)
            {
                root = node;
            }
            else
            {
                cellHolder = root;
                Add(node, cellHolder);
            }
        }
        public void Add(Employee node, Employee cellHolder)
        {
            if (cellHolder.left == null && int.Parse(node.Salary) <= int.Parse(cellHolder.Salary))
            {
                cellHolder.left = node;
            }
            else if (cellHolder.left != null && int.Parse(node.Salary) <= int.Parse(cellHolder.Salary))
            {
                Add(node, cellHolder.left);
            }
            else if (cellHolder.right == null && int.Parse(node.Salary) > int.Parse(cellHolder.Salary))
            {
                cellHolder.right = node;
            }
            else
            {
                Add(node, cellHolder.right);
            }
        }

        public void SearchBySalary(Employee current, int valueSearchSalary)
        {
            if (current.left != null)
            {
                SearchBySalary(current.left, valueSearchSalary);
            }

            if (int.Parse(current.Salary) == valueSearchSalary)
            {
                searchList.Add(current);
            }

            if (current.right != null)
            {
                SearchBySalary(current.right, valueSearchSalary);
            }
        }
    }
}

