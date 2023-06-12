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
    
    public partial class Films
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Films()
        {
            this.ActorsFilms = new HashSet<ActorsFilms>();
            this.FilmsGeners = new HashSet<FilmsGeners>();
            this.Seances = new HashSet<Seances>();
        }
    
        public int IdFilm { get; set; }
        public string FilmName { get; set; }
        public System.TimeSpan FilmDuration { get; set; }
        public int FirmId { get; set; }
        public int CountryId { get; set; }
        public int AgeLimitId { get; set; }
        public string FilmDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActorsFilms> ActorsFilms { get; set; }
        public virtual AgeLimits AgeLimits { get; set; }
        public virtual Countries Countries { get; set; }
        public virtual Firms Firms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilmsGeners> FilmsGeners { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seances> Seances { get; set; }
    }
}