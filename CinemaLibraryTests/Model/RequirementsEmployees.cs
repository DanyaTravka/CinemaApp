//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaLibraryTests.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class RequirementsEmployees
    {
        public int IdRequirementsEmployees { get; set; }
        public int RequirementId { get; set; }
        public int EmployeeId { get; set; }
    
        public virtual Employees Employees { get; set; }
        public virtual Requirements Requirements { get; set; }
    }
}
