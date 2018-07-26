namespace SOLID._02_OpenClosed
{
    public interface IEmployee
    {
        decimal CalculateBonus(decimal salary);
    }

    public abstract class Employee
    {
        public Employee(int id, string name, string type)
        {
            this.ID = id;
            this.Name = name;
            this.EmployeeType = type;
        }

        public int ID { get; set; }
        public string EmployeeType { get; set; }
        public string Name { get; set; }
    }

    public class PermanentEmployee : Employee, IEmployee
    {
        public PermanentEmployee(int id, string name, string type) : base(id, name, type) {}

        public decimal CalculateBonus(decimal salary)
        {
            return salary * .1M;
        }
    }

    public class TemporaryEmployee : Employee, IEmployee
    {
        public TemporaryEmployee(int id, string name, string type) : base(id, name, type) { }

        public decimal CalculateBonus(decimal salary)
        {
            return salary * .05M;
        }
    }
}