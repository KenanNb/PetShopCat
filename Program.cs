using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat1
{
    class PetShop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalIncome { get; set; } = 0;
        public CatHouse[] CatHouses { get; set; }
        public int CatHouseCount { get; set; } = 0;
        public static int PetShopId { get; set; } = 1;
        public PetShop()
        {
            Id = PetShopId++;
        }

        public PetShop(string name)
        {
            Name = name;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("=============Pet Shop===========");
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Total income : {TotalIncome} usd");
            Console.ResetColor();
        }
        public double CalculateTotalPrice()
        {
            if (CatHouses != null)
            {
                foreach (var c in CatHouses)
                {
                    TotalIncome += c.GetTotalPrice();
                }
            }
            return TotalIncome;
        }
        public void AddCatHouse(ref CatHouse catHouse)
        {
            var temp = new CatHouse[++CatHouseCount];
            if (CatHouses != null)
            {
                CatHouses.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = catHouse;
            CatHouses = temp;

        }
        public void ShowCatHouse()
        {
            if (CatHouses != null)
            {
                foreach (var c in CatHouses)
                {
                    c.showCatHouse();
                }
            }
            else
            {
                Console.WriteLine("There is no resource in Company");
            }
        }
    }



    class Cat
    {
        public string nickname { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public double Energy { get; set; } = 100;
        public double Price { get; set; }
        public double MealQuality { get; set; }
        public Cat()
        {

        }

        public Cat(string nickname, int age, string gender, double energy, double price, double mealQuality)
        {
            this.nickname = nickname;
            this.age = age;
            this.gender = gender;
            Energy = energy;
            Price = price;
            MealQuality = mealQuality;
        }
        public void Eat()
        {
            if (Energy <= 100)
            {
                Energy += MealQuality;
                Price += 1;
            }
            else
            {
                Console.WriteLine("I'am full can't eat enymore");
            }
        }
        public void Sleep()
        {
            if (Energy <= 100)
            {
                Console.WriteLine("I'm sleeping!!!");
                Energy += 5;
            }
            else
            {
                Console.WriteLine("I'm full of energy i can't sleep enymore");
            }
        }
        public void Play()
        {
            if (Energy > 0)
            {
                Energy -= 5;
            }
            else
            {
                Energy = 0;
            }
        }
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("=========COMPANY==========");
            Console.WriteLine($"Nickname : {nickname}");
            Console.WriteLine($"Age : {age}");
            Console.WriteLine($"Gender : {gender}");
            Console.WriteLine($"Energy : {Energy}");
            Console.WriteLine($"Price : {Price}");
            Console.WriteLine($"MealQuality : {Price} usd");
            Console.ResetColor();
        }

    }
    class CatHouse
    {
        public int Id { get; set; }
        public static int CatId { get; set; } = 1;
        public bool IsValuable { get; set; }
        public Cat[] Cats { get; set; }
        public int CatCount { get; set; } = 0;
        public CatHouse()
        {
            Id = CatId++;
        }
        public void AddCat(ref Cat cat)
        {
            Cat[] temp = new Cat[++CatCount];
            if (Cats != null)
            {
                Cats.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = cat;
            Cats = temp;
        }
        public int GetByNickname(string nickname)//Bu hissede problem var nece duzeldilmelidi?
        {
            /*Cat[] temp = new Cat[--CatCount];
            if (Cats != null)
            {
                if (cat.nickname != nickname)
                    Cats.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = cat;
            Cats = temp;*/
            for (int i = 0; i < Cats.Length; i++)
            {
                if (Cats[i].nickname == nickname)
                {                    
                    return i;
                }
            }
            return -1;
        }
        public void RemuveById(int id)
        {

        }
        public void ShowCats()
        {
            if (Cats != null)
            {
                foreach (var cat in Cats)
                {
                    cat.Show();
                }
            }
        }
        public void showCatHouse()
        {
            Console.WriteLine();
            Console.WriteLine("============CAT HOUSE===========");
            Console.WriteLine($"Id : {Id}");
            var isValuable = (IsValuable) ? "Yes" : "No";
            Console.WriteLine($"Is valuable : {isValuable}");
            Console.WriteLine($"Total income : {GetTotalPrice()} usd");

        }
        public double GetTotalPrice()
        {
            double total = 0;
            if (Cats != null)
            {
                foreach (var c in Cats)
                {
                    total += c.Price;
                }
            }
            return total;
        }
    }

    class Controller
    {
        public static void Run()
        {
            PetShop petShop = new PetShop
            {
                Name = "Happy Cats"

            };
            CatHouse catHouse = new CatHouse
            {
                IsValuable = true,
            };
            petShop.AddCatHouse(ref catHouse);

            Cat c1 = new Cat
            {
                nickname = "Mestan",
                age = 2,
                gender = "Male",
                Energy = 100,
                Price = 400,
                MealQuality = 5
            };

            Cat c2 = new Cat
            {
                nickname = "Rehim",
                age = 3,
                gender = "Male",
                Energy = 100,
                Price = 320,
                MealQuality = 10
            };

            Cat c3 = new Cat
            {
                nickname = "Nergiz",
                age = 1,
                gender = "Fimale",
                Energy = 100,
                Price = 450,
                MealQuality = 15
            };
            catHouse.AddCat(ref c1);
            catHouse.AddCat(ref c2);
            catHouse.AddCat(ref c3);
            for (int i = 0; i < 30; i++)
            {
                petShop.Show();
                petShop.ShowCatHouse();
                catHouse.ShowCats();
                if (c1.Energy == 0)
                {
                    c1.Sleep();
                }
                else
                {
                    c1.Play();
                }
                if (c2.Energy == 0)
                {
                    c2.Sleep();
                }
                else
                {
                    c2.Play();
                }
                if (c3.Energy == 0)
                {
                    c3.Sleep();
                }
                else
                {
                    c3.Play();
                }
                if (i == 15)
                {
                    c1.Eat();
                    c2.Eat();
                }
                Thread.Sleep(800);
                Console.Clear();
            }
            petShop.CalculateTotalPrice();
            petShop.Show();
            petShop.ShowCatHouse();
            catHouse.ShowCats();
            Console.WriteLine();
            Console.WriteLine("I deleted Mestan");
            catHouse.RemoveByNickname("Mestan");
            catHouse.ShowCats();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Controller.Run();

        }
    }
}

