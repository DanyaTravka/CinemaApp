//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ResponsibilitiesEmployees
    {
        public int IdResponsibilitiesEmployees { get; set; }
        public int ResponsibilityId { get; set; }
        public int EmployeeId { get; set; }
    
        public virtual Employees Employees { get; set; }
        public virtual Responsibilities Responsibilities { get; set; }
    }
}
