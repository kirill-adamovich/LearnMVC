﻿using System.ComponentModel.DataAnnotations;

namespace LearnProject.Models.ViewModels
{
    public class LoginView
    {
        [Required(ErrorMessage = "Введите email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        public bool IsPersistent { get; set; }
    }
}