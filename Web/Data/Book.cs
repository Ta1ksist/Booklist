using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Data;

public class Book
{
    public int Id { get; set; }
    
    [Display(Name = "Название")]
    public string? Title { get; set; }

    [Display(Name = "Описание")]
    public string? Description { get; set; }

    [Display(Name = "Автор")]
    public string? Author { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Год")]
    public int Year { get; set; }
}
