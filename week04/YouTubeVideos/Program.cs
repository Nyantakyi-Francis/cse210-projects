using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create list of videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video { Title = "C# Basics", Author = "CodeLab", Length = 600 };
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "This really helped me."));
        video1.AddComment(new Comment("Charlie", "Thanks for the clear walkthrough."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video { Title = "Learn LINQ", Author = "Tech Guru", Length = 750 };
        video2.AddComment(new Comment("Diana", "LINQ is awesome!"));
        video2.AddComment(new Comment("Evan", "So concise and powerful."));
        video2.AddComment(new Comment("Faith", "Nice examples."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video { Title = "ASP.NET Crash Course", Author = "WebDev101", Length = 1200 };
        video3.AddComment(new Comment("George", "This made ASP.NET easier."));
        video3.AddComment(new Comment("Hannah", "I was confused before this."));
        video3.AddComment(new Comment("Ian", "Well explained."));
        videos.Add(video3);

        // Display info
        foreach (Video video in videos)
        {
            Console.WriteLine($"\nTitle: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
            }
        }
    }
}
