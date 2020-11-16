using System;
using System.Collections.Generic;
using System.Linq;

namespace DebuggingDemo
{
    class Program
    {
        private static List<Author> _authors = new List<Author>
        {
            new Author { Id = 1, Name = "Stephen King" },
            new Author { Id = 2, Name = "Sylvia Plath" },
            new Author { Id = 3, Name = "Martin Fowler" }
        };

        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "The Shining", AuthorId = 1 },
            new Book { Id = 2, Title = "The Gunslinger", AuthorId = 1 },
            new Book { Id = 3, Title = "The Bell Jar", AuthorId = 2 },
            new Book { Id = 4, Title = "Refactoring", AuthorId = 3 },
            new Book { Id = 5, Title = "Lady Lazarus", AuthorId = 2 },
        };

        static void Main(string[] args)
        {
            var author = GetAuthorByName("Stephen King");

            if (author == null)
            {
                Console.WriteLine("Author was not found");
            }

            var books = GetBooksByAuthor(author.Id);

            if (books == null)
            {
                Console.WriteLine("No books by that author");
            }

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
        }

        private static Author GetAuthorByName(string name)
        {
            var author = _authors.FirstOrDefault(a => a.Name == name);
            return author;
        }

        private static List<Book> GetBooksByAuthor(int authorId)
        {
            var books = _books.Where(b => b.AuthorId == authorId).ToList();
            return books;
        }
    }
}

//For debugging most applications, you'll find the intergratedTerminal option to be the most helpful
//You can also get a quick look at the values of all variables in the Locals window of your sidebar
// Step Over: Execute the current line and move to the next line in the code.
// Step Into: If paused on a line that will invoke a method, you can step into that method and continue debugging.
// Step Out: If you've stepped into a method but want to return to where it was called from, you can step out of the current method.
// Continue: Go to either the next breakpoint, or if there are no more breakpoints, continue executing the program normally.
// Refresh: Start the program over again.
// Stop: Stop the program
//While in a breakpoint, you can also execute any C# code by typing into the Debug Console at the bottom of your editor. 
