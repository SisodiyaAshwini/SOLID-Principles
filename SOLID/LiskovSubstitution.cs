using System.Collections.Generic;

namespace SOLID
{
    //Definition : Substitutability is a principle in object-oriented programming and it states that, in a computer program, if S is a Subtype of T, then objects of type T may be replaced with objects of type S
    //1. Which means, Derived types must be completely substitutable for their base types
    //2. More formally, the Liskov substitution principle(LSP) is a particular definition of a subtyping relation, called(strong) behavioral subtyping
    //4. This principle is just an extension of the Open Close Principle

    //The examples used in this session are related to the open closed principle. Hence we request you to watch the Open Closed Principle tutorial before proceeding.
    //Implementation guidelines : In the process of development we should ensure that
    //1. No new exceptions can be thrown by the subtype unless they are part of the existing exception hierarchy.
    //2. We should also ensure that Clients should not know which specific subtype they are calling, nor should they need to know that.
    //The client should behave the same regardless of the subtype instance that it is given.
    //3. And last but not the least, New derived classes just extend without replacing the functionality of old classes
    //In the previous session as part of the Open closed Principle implementation we have created different employee classes to calculate bonus of the employee.
    //From the employee perspective we have implemented the Open closed principle.
    //Now if you take a look at the main program, we have created Employee objects which consists of both permanent and contract employee.
    //If you take a closer look at this program the Derived types which are Permanent and TemporaryEmployee have completely substituted the base type employee class.
    //So, based on the Liskov substitution principle we have achieved LSP by ensuring that Derived types are completely substitutable for their base types.
    //Also, notice the main program, without using the subtypes we are calculating the bonus of the employee from the base class type itself.Hence, we are satisfying the Liskov substitution principle.
    //That means along with the Open Closed Principle we have partially implemented the LSP.
    //Also, I can state that this implementation is not adhering to guide lines of Liskov principle

    //To understand why it’s not adhering to the Liskov Principle, Let’s assume that we need to have a Contract Employee as one of the employee category.
    //A point to note here is a contract employee is not eligible for any bonus calculation and post implementing the Employee class we end up throwing exception at the runtime in the caclculatebonus() method.This violates the Liskov Substitution Principle.

    //and this is partial implementation of Liskov principles as we can access all derived class from parent class
    //If I can contract employee class and those are not eligible for any bonus, so calculateBonus will throw error here
    //and  liskovs says no derived call should throw extra exception

    public class ContractEmployee1 : EmployeeAbstarct
    {
        public ContractEmployee1(int id, string name):base(id, name)
        {
        }

        public override decimal CalculateBonus(decimal salary)
        {
            throw new System.NotImplementedException(); // This will throw the error at runtime because contract employy are not eligible for bonus
        }
    }

    //How can we solve this problem
    
    public interface IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal getMinimumSalary();       
    }

    public interface IEmployeeBonus
    {
        decimal CalculateBonus(decimal salary);
    }

    public class ContractEmployee : IEmployee
    {
        public int Id { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public ContractEmployee(int id, string name)
        {
            this.Id = id;
            this.Name= name;
        }

        public decimal getMinimumSalary()
        {
            throw new System.NotImplementedException();
        }
    }

    //During implementation

    public class Practice
    {
        public static void Main()
        {
            List<EmployeeAbstarct> emplist = new List<EmployeeAbstarct>();
            emplist.Add(new PermanentEmployee(1,"Ashwini"));
            emplist.Add(new TemporaryEmployee(2, "Dirgh"));
            //emplist.Add(new ContractEmployee(1, "data")); // this is not possible. here the interface creation is helping

            List<IEmployee> emps = new List<IEmployee>(); //this is object of list in which Iemplyee is passed, yet Iemployee object is not created, 
            emps.Add(new PermanentEmployee(1, "Ashwini")); //Here we are creating object and passing to Iemployee
            emps.Add(new TemporaryEmployee(2, "Dirgh"));
            emps.Add(new ContractEmployee(1, "data")); // This is possible because of interface
        }
    }

}
