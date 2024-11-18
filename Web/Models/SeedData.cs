using System;
using Microsoft.EntityFrameworkCore;
using Web.Data;

namespace Web.Models;

public class SeedData
{
public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BookContext>>()))
        {
           
            if (context.Books.Any())
            {
                return;  
            }
            context.Books.AddRange(
                new Book
                {
                    Title = "Гроза",
                    Description = "Пьеса «Гроза» (1859) – наиболее значимая в творчестве Александра Николаевича Островского.",
                    Author = "Александр Островский",
                    Year = 1859
                },
                new Book
                {
                    Title = "Преступление и наказание",
                    Description = "«Преступление и наказание» – гениальный роман, главные темы которого: преступление и наказание, жертвенность и любовь, свобода и гордость человека – обрамлены почти детективным сюжетом.",
                    Author = "Федор Достоевский",
                    Year = 1866
                },
                new Book
                {
                    Title = "Обломов",
                    Description = "«Обломов» Гончарова. «Золотая классика» русской литературы. Оригинальная, неоднозначная книга, которую считают и эталоном критического реализма, и романом откровенно сатирическим…",
                    Author = "Иван Гончаров",
                    Year = 1859
                },
                new Book
                {
                    Title = "Идиот",
                    Description = "Роман, в котором творческие принципы Достоевского воплощаются в полной мере, а удивительное владение сюжетом достигает подлинного расцвета.",
                    Author = "Федор Достоевский",
                    Year = 1868
                },
                new Book
                {
                    Title = "@@@@",
                    Description = "@@@@",
                    Author = "@@@@",
                    Year = 1111
                }
            );
            context.SaveChanges();
        }
    }
}
