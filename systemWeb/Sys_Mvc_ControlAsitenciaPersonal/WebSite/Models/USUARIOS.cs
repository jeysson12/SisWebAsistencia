//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class USUARIOS
    {
        [Required(ErrorMessage = "Ingrese usuario")]
        [Display(Name = "Usuuario")]
        public string ID_USUARIO { get; set; }
        [Required(ErrorMessage = "Ingrese contraseña")]
        [Display(Name = "Contraseña")]
        public string CONTRASEÑA { get; set; }
        [Required(ErrorMessage = "Ingrese Tipo")]
        [Display(Name = "Tipo")]
        public string TIPO { get; set; }
        
        [Display(Name = "ID Empleado")]
        public Nullable<int> ID_EMPLEADO { get; set; }
        
        [Display(Name = "Activo")]
        public Nullable<bool> ACTIVO { get; set; }
    
        public virtual EMPLEADOS EMPLEADOS { get; set; }
    }
}