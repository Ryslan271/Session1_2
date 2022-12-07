using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session12
{
    public partial class User
    {
        public string Fullname 
        { 
            get => $"{LastName[0]}. {FirstName[0]}. {Patronymic}"; 
        }
    }
}
