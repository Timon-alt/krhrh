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
    
    public partial class Buhgalteria
    {
        public Buhgalteria()
        {
            this.Otchet = new HashSet<Otchet>();
        }
    
        public int ID_Buhgalteria { get; set; }
        public int ID_Zayavka { get; set; }
        public string Viplata { get; set; }
        public Nullable<System.DateTime> Date_viplata { get; set; }
        public decimal Perecheslenie { get; set; }
        public decimal Otchislenie { get; set; }
    
        public virtual User_zayavka User_zayavka { get; set; }
        public virtual ICollection<Otchet> Otchet { get; set; }
    }
}