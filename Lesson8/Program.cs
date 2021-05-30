// Павлов Дмитрий.
//1. С помощью рефлексии выведите все свойства структуры DateTime
//2. Создайте простую форму на котором свяжите свойство Text элемента TextBox со свойством
//Value элемента NumericUpDown
//3. а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок (не
//создана база данных, обращение к несуществующему вопросу, открытие слишком большого
//файла и т.д.).
//б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив
//другие «косметические» улучшения на свое усмотрение.
//в) Добавить в приложение меню «О программе» с информацией о программе (автор, версия,
//авторские права и др.).
using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static PropertyInfo GetPropertyInfo(object obj, string str)
        {
            return obj.GetType().GetProperty(str);
        }

        static void Main(string[] args)
        {
            
            DateTime dateTime = new DateTime();
            
            Console.WriteLine($"CanRead: {GetPropertyInfo(dateTime, "DayOfWeek").CanRead}");
            Console.WriteLine($"CanWrite: {GetPropertyInfo(dateTime, "DayOfWeek").CanWrite}");
            Console.WriteLine($"Attributes: {GetPropertyInfo(dateTime, "DayOfWeek").Attributes}");
            Console.WriteLine($"CustomAttributes: {GetPropertyInfo(dateTime, "DayOfWeek").CustomAttributes}");
            Console.WriteLine($"DeclaringType: {GetPropertyInfo(dateTime, "DayOfWeek").DeclaringType}");
            Console.WriteLine($"GetMethod: {GetPropertyInfo(dateTime, "DayOfWeek").GetMethod}");
            Console.WriteLine($"IsSpecialName: {GetPropertyInfo(dateTime, "DayOfWeek").IsSpecialName}");
            Console.WriteLine($"MemberType: {GetPropertyInfo(dateTime, "DayOfWeek").MemberType}");
            Console.WriteLine($"MetadataToken: {GetPropertyInfo(dateTime, "DayOfWeek").MetadataToken}");
            Console.WriteLine($"Module: {GetPropertyInfo(dateTime, "DayOfWeek").Module}");
            Console.WriteLine($"Name: {GetPropertyInfo(dateTime, "DayOfWeek").Name}");
            Console.WriteLine($"PropertyType: {GetPropertyInfo(dateTime, "DayOfWeek").PropertyType}");
            Console.WriteLine($"ReflectedType: {GetPropertyInfo(dateTime, "DayOfWeek").ReflectedType}");
            Console.WriteLine($"SetMethod: {GetPropertyInfo(dateTime, "DayOfWeek").SetMethod}");

            Console.WriteLine($"GetValue: {GetPropertyInfo(dateTime, "DayOfWeek").GetValue(dateTime, null)}");

            // Альтернативный способ вывода свойств:        
            Console.WriteLine($"Нажмите enter");
            Console.ReadKey();

            Type t = typeof(DateTime);
            foreach (var prop in t.GetProperties())
                Console.WriteLine(prop.Name);

            Console.WriteLine($"возвращает все поля данного типа в виде массива объектов FieldInfo");
            
            Type t1 = typeof(DateTime);
            foreach (var prop in t1.GetFields())
                Console.WriteLine(prop.Name);

            Console.WriteLine($"получает все методы типа в виде массива объектов MethodInfo");
            
            Type t2 = typeof(DateTime);
            foreach (var prop in t2.GetMethods())
                Console.WriteLine(prop.Name); // и так далее...

            Console.ReadKey();

        }
    }
}