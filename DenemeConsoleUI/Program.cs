// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntitiyFramework;







//Brand();
//Color();


CarManager carManager = new CarManager(new EfCarDal());

foreach (var car in carManager.GetCarDetailDtos())
{
    Console.WriteLine(car.BrandName + car.CarName + car.ColorName + car.DailyPrice);
}






Console.ReadLine();


static void Brand()
{
    CarManager carManager = new CarManager(new EfCarDal());

    foreach (var car in carManager.GetAll())
    {
        Console.WriteLine(car.CarId);
    }
}

static void Color()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());

    foreach (var color in colorManager.GetAll())
    {
        Console.WriteLine(color.ColorId + " = " + color.ColorName);
    }
}