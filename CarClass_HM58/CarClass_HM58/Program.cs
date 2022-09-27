/*Create class Car with 5 fields (properties) Make, Model, Price, Color, Year, 
 * choose appropriate datatypes for fields. 
 * Create public method, which returns full info about the car, seperated by comma. 
 * Create list with several cars. 
 * Find most expensive car. 
 * Find cars in specific price range. 
 * Find only cars with specific Year or Model.*/

using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace CarClass_HM58
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            var car_1 = new Cars() { Color = "White", Make = "Audi", Model = "A3", Price = 4500, Year = 2004 };
            var car_2 = new Cars() { Color = "Black", Make = "Audi", Model = "A4", Price = 8000, Year = 2012 };
            var car_3 = new Cars() { Color = "White", Make = "Audi", Model = "A3", Price = 6800, Year = 2013 };
            var car_4 = new Cars() { Color = "Black", Make = "Bentley", Model = "Continental GT", Price = 76000, Year = 2012 };
            var car_5 = new Cars() { Color = "Yellow", Make = "Porsche", Model = "718", Price = 123000, Year = 2020 };

            var carsList = new Cars[] { car_1, car_2, car_3, car_4, car_5 }; //list created

            Console.WriteLine("List of available cars: "); 

            IEnumerable<string> anyCar = RetrieveAllCarsData(carsList); //printing full info about cars

            Console.WriteLine(string.Join(". \n", anyCar.ToList()));
            Console.WriteLine();


            var mostExpensive = carsList.Max(c => c.Price);

            foreach (var car in carsList)
            {
                if (car.Price == mostExpensive)
                {
                    Console.WriteLine($"The most expensive car is {car.Make} for {car.Price} Euros."); //most expensive found
                }
            }
            Console.WriteLine();
            Console.WriteLine("Cars in range of 8000-12300: ");


            foreach (var car in carsList)
            {
                if (car.Price >= 8000 && car.Price < 123000)
                {
                    Console.WriteLine($"{car.Make}, {car.Model}"); //cars of range price found
                }
            }
            Console.WriteLine();
            Console.WriteLine("Audi A3-A4 between 2000-2012 years:  ");


            foreach (var car in carsList)
            {
                if (car.Model == "A3" || car.Model == "A4" && car.Year > 2000 && car.Year < 2012)
                {
                    Console.WriteLine($"{car.Make} {car.Model} of {car.Year} year."); //makes and years found
                }
            }
        }

        public static IEnumerable<string> RetrieveAllCarsData(Cars[] carsList) //public method, which returns full info about the car, seperated by comma
        {
            return carsList.Select(carX => carX.Make + ", " + carX.Model + ", " + carX.Color + ", " + carX.Year + ", " + carX.Price);
        }
    }
} 