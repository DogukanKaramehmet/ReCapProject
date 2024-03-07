// See https://aka.ms/new-console-template for more information


using Business.Concrete;
using DataAccess.Concrete.InMemory;


CarManager carManager = new CarManager(new CarDal());

foreach (var Car in carManager.GetAll())
{
    Console.WriteLine(Car.Id+" "+Car.ModelYear+" "+Car.DailyPrice+" TL");
}


Console.ReadLine();
