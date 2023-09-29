using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.ViewModels
{
    public class EditRoleViewModel 
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }

        [Required(ErrorMessage = "El nombre del Role es requerido")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
