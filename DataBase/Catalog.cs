//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Catalog
    {
        public Catalog()
        {
            this.Korzina = new HashSet<Korzina>();
            this.User_zayavka = new HashSet<User_zayavka>();
        }
    
        public int ID_Catolog { get; set; }
        public string Name { get; set; }
        public string Opisanie { get; set; }
        public string Image { get; set; }
    
        public virtual ICollection<Korzina> Korzina { get; set; }
        public virtual ICollection<User_zayavka> User_zayavka { get; set; }
    }
}