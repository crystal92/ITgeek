
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ITgeek
{

using System;
    using System.Collections.Generic;
    
public partial class pozycja_kategorii
{

    public int id_pozycja_kategorii { get; set; }

    public int id_projekt { get; set; }

    public int id_kategoria { get; set; }



    public virtual kategoria kategoria { get; set; }

    public virtual projekt projekt { get; set; }

}

}
