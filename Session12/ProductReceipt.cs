//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Session12
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductReceipt
    {
        public int id { get; set; }
        public int OrderId { get; set; }
    
        public virtual Order Order { get; set; }
    }
}