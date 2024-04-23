// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntitiyFramework;







//Brand();
//Color();


CarManager carManager = new CarManager(new EfCarDal());

var result = carManager.GetCarDetailDtos();

if (result.Success==true)
{
   foreach (var car in result.Data)
{
    //Trim Başında ki ve sonunda ki boşlukarı siler
    //Kullanımı car.BrandName.Trim()
    Console.WriteLine(car.BrandName + " / " + car.CarName + " / " + car.ColorName + " / " + car.DailyPrice);
} 

}
else
{
    Console.WriteLine(result.Message);
}








Console.ReadLine();


static void Brand()
{
    CarManager carManager = new CarManager(new EfCarDal());

    foreach (var car in carManager.GetAll().Data)
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