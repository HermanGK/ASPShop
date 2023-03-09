using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace ASPShop.Models
{
    public class Orders
    {
        [BindNever]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Введите имя")]
        [Required(ErrorMessage ="Имя обязательно для заполнения")]
        [StringLength(30, ErrorMessage ="Имя слишком длинное" )]
        public string? Name { get; set; }

        [Display(Name = "Введите фамилию")]
        [Required(ErrorMessage = "Фамилия обязательна для заполнения")]
        [StringLength(30, ErrorMessage = "Фамилия слишком длинная")]
        public string? LastName { get; set; }

        [Display(Name = "Введите город доставки")]
        [Required(ErrorMessage = "Город не может быть пустым")]
        [StringLength(30, ErrorMessage = "Максимум 30 символов")]
        public string? City { get; set; }

        [Display(Name = "Введите улицу")]
        [Required(ErrorMessage = "Улица не может быть пустым")]
        
        public string? Street { get; set; }

        [Display(Name = "Введите Eircode")]
        [Required(ErrorMessage = "Имя обязательно для заполнения")]
        
        public string? AirCode { get; set; }
        [Required(ErrorMessage ="Ваша корзина пуста!")]
        public string? Cart { get; set; }
         


    }
}
