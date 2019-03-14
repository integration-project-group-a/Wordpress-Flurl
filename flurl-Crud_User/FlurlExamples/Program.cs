using System;
using Flurl.Http;
using FlurlExamples.Model;

namespace FlurlExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CRUD Operation for user");
            Console.WriteLine();

            var flurlRequestHandler = new FlurlRequestHandler();

            var users = flurlRequestHandler.GetUsers().Result;

            Console.WriteLine($"Number of Users {users.Count}");
            Console.WriteLine();
            foreach (var user in users)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                WriteInColor("User", ConsoleColor.Green);
                WriteResult(user);
            }
            Console.WriteLine();

           /* try
            {
                var newUser = flurlRequestHandler.CreateUser("testUsername5", "test5@gmail.com", "Password1234").Result;
                WriteInColor("User created", ConsoleColor.Green);
                WriteResult(newUser);
                Console.WriteLine();
            }
            catch (AggregateException ae)
            {
                // in case the user already exists, handle FlurlHttpException
                ae.Handle(ex =>
                {
                    if (ex is FlurlHttpException)
                    {
                        Console.WriteLine(ex);
                    }
                    return ex is FlurlHttpException;
                });
            }*/

           /*var updateUser = flurlRequestHandler.UpdateUser(7,"test2@mail.com").Result;
            WriteInColor("User Updated", ConsoleColor.Green);
            WriteResult(updateUser);
            Console.WriteLine();*/

            var deleteUserRes = flurlRequestHandler.DeleteUser(7,1).Result;
            WriteInColor($"User deleted, status code: {deleteUserRes.ReasonPhrase}", ConsoleColor.Green);
            Console.WriteLine();

            Console.ReadKey();
        }

        private static void WriteInColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void WriteResult(User user)
        {
            Console.WriteLine($"Id: {user.id}");
            Console.WriteLine($"UserName: {user.userName}");
            Console.WriteLine($"Email: {user.email}");
            Console.WriteLine($"Password: {user.password}");
        }
    }
}
