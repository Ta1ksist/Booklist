using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class CreateBookModel
{
    public int Id { get; set; }

    [Display(Name = "Введите Название")]
    [Required(ErrorMessage = "Вам нужно ввести Название")]
    public string? Title {get; set;}
    
    [Display(Name = "Введите Описание")]
    [Required(ErrorMessage = "Вам нужно ввести Описание")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "Описание должно быть от 10 до 100 символов")]
    public string? Description {get; set;}

    [Display(Name = "Введите Автора")]
    [Required(ErrorMessage = "Вам нужно ввести Автора")]
    public string? Author {get; set;}

    [Display(Name = "Введите Год")]
    [Required(ErrorMessage = "Вам нужно ввести Год")]
    [Range(100, 2024, ErrorMessage = "Недопустимый Год")]
    public int Year {get; set;}
}
