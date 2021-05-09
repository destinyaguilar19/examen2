using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DymaDieckBackend.Util
{
    public class reg_expressions
    {
        public const string regEx_texto = @"^[a-zA-Z0-9\- .ñáéíóú:#()]+$";
        public const string regEx_numeric = @"^[0-9]+(\.[0-9]{1,2})?$";
        public const string regEx_email = @"^.+@.+\..+$";
        public const string regEx_textarea = @"^[a-zA-Z0-9\- ,ñáéíóú:#()!$%*+= \/\.\n\r]+$";
    }
}

