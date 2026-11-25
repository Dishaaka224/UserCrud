using System;
using ConsoleUserCrud.Services;
namespace ConsoleUserCrud.Models;

public class Programm
{
    public static void Main()
    {
        var userService = new UserServices();
        bool isRunning = true;

        while (isRunning)
        {
            ShowMenu();

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Wrong choice. Choose number.");
                WaitAndClear();
                continue;
            }
            if (choice == 0 )
            {
                isRunning = false;
                continue;
            }
            switch (choice)
            {
                case 1:
                User? newUser = ReadUser();
                    if (newUser != null)
                        userService.CreateUser(newUser);
                    break;

                case 2:
                    Console.Write("ID: ");
                    if (int.TryParse(Console.ReadLine(), out int findId))
                    {
                        User foundUser = userService.GetUserById(findId);
                        userService.PrintUser(foundUser); // null bo'lsa "User not found."
                    }
                    else
                    {
                        Console.WriteLine("ID musbat son bo'lishi kerak.");
                    }
                    break;

                case 3:
                    User[] allUsers = userService.GetAllUsers();
                    if (allUsers.Length == 0)
                    {
                        Console.WriteLine("Ro'yxat bo'sh.");
                    }
                    foreach (User u in allUsers)
                    {
                        userService.PrintUser(u);
                        Console.WriteLine();
                    }
                    break;

                case 4:
                Console.WriteLine("YAngi malumotlarni kiriting (ID o'zgarmaydi):");
                User? updatedUser = ReadUser();
                if (updatedUser != null)
                        userService.UpdateUser(updatedUser);
                    break;

                case 5:
                    Console.Write("O'chiriladigan ID: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                        userService.DeleteUser(deleteId);
                    else
                        Console.WriteLine("ID butun son bo'lishi kerak.");
                    break;

                default:
                    Console.WriteLine("Bunday menyu yo'q.");
                    break;
            }
            WaitAndClear();
    }
}


private static void ShowMenu()
    {
        Console.WriteLine("=========================");
        Console.WriteLine("   USER SERVICE MENU");
        Console.WriteLine("=========================");
        Console.WriteLine("1. Foydalanuvchi yaratish");
        Console.WriteLine("2. ID orqali ko'rish");
        Console.WriteLine("3. Barcha foydalanuvchilarni ko'rish");
        Console.WriteLine("4. Foydalanuvchini yangilash");
        Console.WriteLine("5. Foydalanuvchini o'chirish");
        Console.WriteLine("0. Chiqish");
        Console.WriteLine("=========================");
        Console.Write("Tanlang: ");
    }
    private static void WaitAndClear()
    {
        Thread.Sleep(5000);
        Console.Clear();
    }

    private static User? ReadUser()
    {
        Console.Write("ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID butun son bo'lishi kerak.");
            return null;
        }
        Console.Write("Name: ");
        string name = Console.ReadLine() ?? string.Empty;
        Console.Write("Email: ");
        string email = Console.ReadLine() ?? string.Empty;
        Console.Write("Age: ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Age butun son bo'lishi kerak.");
            return null;
        }
        Console.Write("Phone number: ");
        string phone = Console.ReadLine() ?? string.Empty;


User user = new User();
        user.Id = id;
        user.Name = name;
        user.Email = email;
        user.Age = age;
        user.PhoneNumber = phone;

        return user;
    }
}