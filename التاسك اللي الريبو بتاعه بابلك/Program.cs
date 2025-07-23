namespace التاسك_اللي_الريبو_بتاعه_بابلك
{
    class Book
    {
        public string Title;
        public string Author;
        public string ISBN;
        public bool IsAvailable;

        public Book(string title, string author, string isbn, bool isAvailable = true)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsAvailable = isAvailable;
        }
    }

    class Library
    {
        public List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("The book " + book.Title + "  Added ");
        }

        public void SearchBook(string search)
        {
            bool found = false;
            Console.WriteLine("Search Results:");

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.ToLower().Contains(search.ToLower()) || books[i].Author.ToLower().Contains(search.ToLower()))
                {
                    Console.WriteLine("Title: " + books[i].Title);
                    Console.WriteLine("Author: " + books[i].Author);
                    Console.WriteLine("Available: " + (books[i].IsAvailable ? "Yes" : "No"));
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Not  found");
            }
        }

        public void BorrowBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.ToLower() == title.ToLower())
                {
                    if (books[i].IsAvailable)
                    {
                        books[i].IsAvailable = false;
                        Console.WriteLine("You borrowed the book " + books[i].Title);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("This book is  not available.");
                    }
                    return;
                }
            }

            Console.WriteLine("Book not found.");
        }

        public void ReturnBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.ToLower() == title.ToLower())
                {
                    if (!books[i].IsAvailable)
                    {
                        books[i].IsAvailable = true;
                        Console.WriteLine("You returned the book " + books[i].Title);
                    }
                    else
                    {

                        Console.WriteLine("This book not borrowed.");
                    }
                    return;
                }
            }


            Console.WriteLine("Book not found.");
        }
    }

    class Program
    {
        static void Main()
        {
            Library library = new Library();

            while (true)
            {

                Console.WriteLine(" Library Main Menu");
                Console.WriteLine("1 - Add a new book");
                Console.WriteLine("2 - Search for a book");
                Console.WriteLine("3 - Borrow a book");
                Console.WriteLine("4 - Return a book");
                Console.WriteLine("5 - Exit");
                Console.Write("Enter your choice");

                string choice = Console.ReadLine();

                if (choice == "1")
                {

                    Console.Write("Enter book title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter author name: ");
                    string author = Console.ReadLine();

                    Console.Write("Enter ISBN: ");
                    string isbn = Console.ReadLine();

                    library.AddBook(new Book(title, author, isbn));
                }
                else if (choice == "2")
                {

                    Console.Write("Enter title ");
                    string keyword = Console.ReadLine();
                    library.SearchBook(keyword);
                }
                else if (choice == "3")
                {

                    Console.Write("Enter the title  ");
                    string title = Console.ReadLine();
                    library.BorrowBook(title);
                }
                else if (choice == "4")
                {
                    Console.Write("Enter the title ");
                    string title = Console.ReadLine();
                    library.ReturnBook(title);
                }
                else if (choice == "5")
                {

                    Console.WriteLine(" Goodbye.");
                    break;
                }
                else
                {

                    Console.WriteLine("Invalid choice");
                }
            }
        }
    }
}


