using System.Collections.Generic;

public class Book
{
    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authos = authors;
    }

    public string Title { get; set; }

    public int Year { get; set; }

    public ICollection<string> Authos { get; set; }
}