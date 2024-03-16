// See https://aka.ms/new-console-template for more information


using Business.Concrete;
using DataAccess.Concrete.EntitiyFramework;


CarManager carManager = new CarManager(new EfCarDal());

foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.CarName);
}


Console.ReadLine();
