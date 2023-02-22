using CRUD_Cars_EFCore.Data.Context;
using CRUD_Cars_EFCore.Data.Model;
using Microsoft.EntityFrameworkCore;

using (var db = new AutoSalonContext())
{
    var newCar = new Car
    {
        Brand = "Ferrari",
        Model = "F8 Tributo",
        Year = 2020,
        Price = 25000000
    };
    db.Cars.Add(newCar);
    db.SaveChanges();

    // получение всех машин из базы данных с eager loading
    var cars = db.Cars.Include(c => c.Orders).ToList();

    foreach (var car in cars)
    {
        Console.WriteLine($"Марка: {car.Brand}, Модель: {car.Model}, Год выпуска: {car.Year}, Цена: {car.Price}");
        foreach (var order in car.Orders)
        {
            Console.WriteLine($"Заказ #{order.Id}: Дата: {order.OrderDate}, Клиент: {order.CustomerName}, Телефон: {order.CustomerPhone}");
        }
    }

    // редактирование машины
    var carToUpdate = db.Cars.FirstOrDefault(c => c.Id == 1);
    if (carToUpdate != null)
    {
        carToUpdate.Price = 22000000;
        db.SaveChanges();
    }

    // удаление машины
    var carToDelete = db.Cars.FirstOrDefault(c => c.Id == 2);
    if (carToDelete != null)
    {
        db.Cars.Remove(carToDelete);
        db.SaveChanges();
    }
}