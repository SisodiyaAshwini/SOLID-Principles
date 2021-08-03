using System;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeAbstarct empPer = new PermanentEmployee(1, "john");
            EmployeeAbstarct empTemp = new TemporaryEmployee(1, "jason");

            Console.WriteLine("PermanentEmployee : Id {0}, Name {1}, Bonus {3}", empPer.Id, empPer.Name, empPer.CalculateBonus(10000));
            Console.WriteLine("TemperoryEmployee : Id {0}, Name {1}, Bonus {3}", empTemp.Id, empTemp.Name, empTemp.CalculateBonus(10000));

            //This supports open closed principles 
            //and this is partial implementation of Liskov principles as we can access all derived class from parent class
            //If I can contract employee class and those are not eligible for any bonus, so calculateBonus will throw error here
            //and  liskovs says no derived call should throw extra exception

        }
    }
}
