namespace SOLID
{
//    Definition: In object-oriented programming, the open/closed principle states that "software entities such as classes, modules, functions, etc. should be open for extension, but closed for modification"
//1. Which means, any new functionality should be implemented by adding new classes, attributes and methods, instead of changing the current ones or existing ones.
//2. Bertrand Meyer is generally credited for having originated the term open/closed principle and This Principle is considered by Bob Martin as “the most important principle of object-oriented design”.
//
//Implementation guidelines
//1. The simplest way to apply OCP is to implement the new functionality on new derived(sub) classes that inherit the original class implementation.
//2. Another way is to allow client to access the original class with an abstract interface, -- This is what is demonstrated below
//3. So, at any given point of time when there is a requirement change instead of touching the existing functionality it’s always suggested to create new classes and leave the original implementation untouched.
//Pit falls of Not following OCP

//What if I do not follow Open closed principle during a requirement enhancement in the development process.
//In that case, we end up with the following disadvantages
 
//1. If a class or a function always allows the addition of new logic, as a developer we end up testing the entire functionality along with the requirement. 
//2. Also, as a developer we need to ensure to communicate the scope of the changes to the Quality Assurance team in advance so that they can gear up for enhanced regression testing along with the feature testing. 
//3. Step 2 above is a costly process to adapt for any organization  
//4. Not following the Open Closed Principle breaks the SRP since the class or function might end up doing multiple tasks. 
//5. Also, if the changes are implemented on the same class, Maintenance of the class becomes difficult since the code of the class increases by thousands of unorganized lines.


    //Employee class , which has basic delatils of employee and calculate Bonus
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public decimal CalculateBonus(decimal salary)
        {
            return salary * .1M;
        }
    }
    //Now the requirement is to Calculate different bonus for temp and permanent employee
    // If we change the existing class, it will be something like
    public class EmployeeModified
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public EmployeeModified(int id, string name, string type)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
        }

        public decimal CalculateBonus(decimal salary)
        {
            if (Type == "Permanant")
            {
                return salary * .1M; // 10% to permanent
            }
            else return salary * .05M; //5% to contractors
        }
    }

    //Now drawback of this modification is you noe have to complete testing, so maintanece is big issue
    //In future if you add more functionality it will become really difficult

    //So one way is to create abstract base class with CalculateBounus as abstract method
    public abstract class EmployeeAbstarct : IEmployeeBonus, IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public EmployeeAbstarct(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public abstract decimal CalculateBonus(decimal salary);

        public decimal getMinimumSalary()
        {
            return 15000;
        }
    }

    public class PermanentEmployee: EmployeeAbstarct
    {
        public PermanentEmployee(int id, string name) : base(id, name)
        {
        }

        public override decimal CalculateBonus(decimal salary)
        {
            return salary * .1M;
        }
    }

    public class TemporaryEmployee : EmployeeAbstarct
    {
        public TemporaryEmployee(int id, string name) : base(id, name)
        {
        }

        public override decimal CalculateBonus(decimal salary)
        {
            return salary * .05M;
        }
    }

    //This way we can add abstract base class and modified/add new requiremnt in derived class
    //Another way of doing this is extension methods
}
