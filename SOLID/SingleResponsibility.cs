namespace SOLID
{
//    As per the single responsibility principle
//1. A class should have only one reason to change
//2. Which means, every module or class should have responsibility over a single part of the functionality provided by the software, and that responsibility should be entirely encapsulated by the class.
//Encapsulation is one of the fundamentals of OOP.At this moment, understanding more about encapsulation is out of scope of this session.However, we strongly recommend you to refer to the C# tutorial playlist for more details on Object oriented principles. Now you might be wondering what do we achieve with the Single Responsibility Principle or rather with the SOLID Design Principles.

//SOLID Principles and Design Patterns plays a key role in achieving all of the above points.

//In Single Responsibility Principle 
//1. Each class and module should focus on a single task at a time
//2. Everything in the class should be related to that single purpose
//3. There can be many members in the class as long as they related to the single responsibility
//4. With SRP, classes become smaller and cleaner
//5. Code is less fragile

    //Here i take example of creating a user reistration and login page
    //for that we will need following method
    interface IUser
    {
        bool Register(string userName, string passowrd, string email); //This is to register the user
        bool Login(string userName, string password); //This to login ueser in the system

        void LogError(string errorMsg); //If any error comes up

        //and finally
        //
        bool SendEmail(string emailContent); //This is to send email on successfully registration
    }

    //Now if we look to above interface it is just not taking care of the user but also of error and email, which cannot be kust related to user
    //so better design way to segregate that as

    interface ILogger
    {
        //this will have logging related methods, obove one can be moved here
        void LogError(string errorMsg);
    }

    interface IEmail
    {
        //This will have all email related functionality
        bool SendEmail(string emailContent);
    }
}
