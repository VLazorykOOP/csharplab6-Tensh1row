//Exercise 1

using System; 

  

// Інтерфейс користувача 

interface IUserInterface 

{ 

    void DisplayUserInterface(); 

} 

  

// Інтерфейс .NET 

interface IDotNetInterface 

{ 

    void DisplayDotNetInfo(); 

} 

  

// Базовий клас - Друковане видання 

abstract class PrintedPublication : IUserInterface, IDotNetInterface 

{ 

    public string Title { get; set; } 

    public string Author { get; set; } 

  

    public PrintedPublication(string title, string author) 

    { 

        Title = title; 

        Author = author; 

    } 

  

    // Метод для виведення даних про об'єкт класу 

    public void Show() 

    { 

        Console.WriteLine($"Title: {Title}"); 

        Console.WriteLine($"Author: {Author}"); 

    } 

  

    // Реалізація методів інтерфейсів 

    public void DisplayUserInterface() 

    { 

        Console.WriteLine("This is a user interface for printed publications."); 

    } 

  

    public void DisplayDotNetInfo() 

    { 

        Console.WriteLine("This class implements the .NET interface."); 

    } 

} 

  

// Похідний клас - Журнал 

class Journal : PrintedPublication 

{ 

    public int IssueNumber { get; set; } 

  

    public Journal(string title, string author, int issueNumber) : base(title, author) 

    { 

        IssueNumber = issueNumber; 

    } 

} 

  

// Похідний клас - Книга 

class Book : PrintedPublication 

{ 

    public int Pages { get; set; } 

  

    public Book(string title, string author, int pages) : base(title, author) 

    { 

        Pages = pages; 

    } 

} 

  

// Похідний клас - Підручник 

class Textbook : PrintedPublication 

{ 

    public string Subject { get; set; } 

  

    public Textbook(string title, string author, string subject) : base(title, author) 

    { 

        Subject = subject; 

    } 

} 

  

class Program 

{ 

    static void Main(string[] args) 

    { 

        Journal journal = new Journal("National Geographic", "National Geographic Society", 2022); 

        Book book = new Book("C# Programming", "John Smith", 400); 

        Textbook textbook = new Textbook("Mathematics for Engineers", "Alan Johnson", "Mathematics"); 

  

        // Виведення інформації про об'єкти 

        Console.WriteLine("Journal:"); 

        journal.Show(); 

        journal.DisplayUserInterface(); 

        journal.DisplayDotNetInfo(); 

        Console.WriteLine(); 

  

        Console.WriteLine("Book:"); 

        book.Show(); 

        book.DisplayUserInterface(); 

        book.DisplayDotNetInfo(); 

        Console.WriteLine(); 

  

        Console.WriteLine("Textbook:"); 

        textbook.Show(); 

        textbook.DisplayUserInterface(); 

        textbook.DisplayDotNetInfo(); 

        Console.WriteLine(); 

    } 

} 

//Exercise 2

using System; 

using System.Collections.Generic; 

  

// Інтерфейс Товар 

interface IProduct 

{ 

    void DisplayInfo(); 

    bool IsExpired(); 

} 

  

// Базовий клас Товар 

abstract class ProductBase : IProduct, IDisposable 

{ 

    public string Name { get; set; } 

    public double Price { get; set; } 

    public DateTime ProductionDate { get; set; } 

    public DateTime ExpiryDate { get; set; } 

  

    // Конструктор 

    public ProductBase(string name, double price, DateTime productionDate, DateTime expiryDate) 

    { 

        Name = name; 

        Price = price; 

        ProductionDate = productionDate; 

        ExpiryDate = expiryDate; 

    } 

  

    // Реалізація методу виведення інформації про товар 

    public virtual void DisplayInfo() 

    { 

        Console.WriteLine($"Name: {Name}"); 

        Console.WriteLine($"Price: {Price:C}"); 

        Console.WriteLine($"Production Date: {ProductionDate:d}"); 

        Console.WriteLine($"Expiry Date: {ExpiryDate:d}"); 

    } 

  

    // Реалізація методу перевірки відповідності строку придатності на поточну дату 

    public bool IsExpired() 

    { 

        return DateTime.Now > ExpiryDate; 

    } 

  

    // Реалізація інтерфейсу IDisposable 

    public void Dispose() 

    { 

        // Код для звільнення неуправляемих ресурсів (якщо потрібно) 

    } 

} 

  

// Похідний клас Продукт 

class Product : ProductBase 

{ 

    // Конструктор 

    public Product(string name, double price, DateTime productionDate, DateTime expiryDate) 

        : base(name, price, productionDate, expiryDate) 

    { 

    } 

  

    // Перевизначений метод виведення інформації про товар 

    public override void DisplayInfo() 

    { 

        Console.WriteLine("Product:"); 

        base.DisplayInfo(); 

    } 

} 

  

// Похідний клас Партія 

class Batch : ProductBase 

{ 

    public int Quantity { get; set; } 

  

    // Конструктор 

    public Batch(string name, double price, int quantity, DateTime productionDate, DateTime expiryDate) 

        : base(name, price, productionDate, expiryDate) 

    { 

        Quantity = quantity; 

    } 

  

    // Перевизначений метод виведення інформації про товар 

    public override void DisplayInfo() 

    { 

        Console.WriteLine("Batch:"); 

        base.DisplayInfo(); 

        Console.WriteLine($"Quantity: {Quantity}"); 

    } 

} 

  

// Похідний клас Комплект 

class Kit : ProductBase 

{ 

    public List<string> Products { get; set; } 

  

    // Конструктор 

    public Kit(string name, double price, List<string> products, DateTime productionDate, DateTime expiryDate) 

        : base(name, price, productionDate, expiryDate) 

    { 

        Products = products; 

    } 

  

    // Перевизначений метод виведення інформації про товар 

    public override void DisplayInfo() 

    { 

        Console.WriteLine("Kit:"); 

        base.DisplayInfo(); 

        Console.WriteLine("Products:"); 

        foreach (var product in Products) 

        { 

            Console.WriteLine($"- {product}"); 

        } 

    } 

} 

  

class Program 

{ 

    static void Main(string[] args) 

    { 

        // Створення бази товарів 

        List<IProduct> products = new List<IProduct> 

        { 

            new Product("Milk", 2.99, new DateTime(2024, 3, 15), new DateTime(2024, 4, 15)), 

            new Batch("Cookies", 1.49, 10, new DateTime(2024, 3, 10), new DateTime(2024, 4, 10)), 

            new Kit("Gift Basket", 24.99, new List<string>{"Chocolate", "Wine", "Cheese"}, new DateTime(2024, 3, 1), new DateTime(2024, 4, 1)) 

        }; 

  

        // Виведення інформації про товари 

        Console.WriteLine("Products Information:"); 

        foreach (var product in products) 

        { 

            product.DisplayInfo(); 

            Console.WriteLine(); 

        } 

  

        // Пошук прострочених товарів 

        Console.WriteLine("Expired Products:"); 

        foreach (var product in products) 

        { 

            if (product.IsExpired()) 

            { 

                product.DisplayInfo(); 

                Console.WriteLine(); 

            } 

        } 

    } 

} 