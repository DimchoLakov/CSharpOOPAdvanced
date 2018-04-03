using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class MyCustomAttribute : Attribute
{
    public MyCustomAttribute()
    {
        
    }

    public MyCustomAttribute(string author, int revision, string description, string[] reviewers)
    {
        this.Author = author;
        this.Revision = revision;
        this.Description = description;
        this.Reviewers = reviewers;
    }

    public string Author { get; set; }

    public int Revision { get; set; }

    public string Description { get; set; }

    public string[] Reviewers { get; set; }
}