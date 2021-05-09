using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DymaDieckAPI.Models
{
    public class LoginForm
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Invalid length")]
        [RegularExpression(DymaDieckBackend.Util.reg_expressions.regEx_texto, ErrorMessage = "Invalid input format on Username")]
        public string username { get; set; }

        [Required(AllowEmptyStrings = false)]
        [RegularExpression(DymaDieckBackend.Util.reg_expressions.regEx_texto, ErrorMessage = "Invalid input format On Password")]
        public string password { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 30, ErrorMessage = "Invalid length")]
        public string imei { get; set; }
    }

    public class LoginFormWeb
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Invalid length")]
        [RegularExpression(DymaDieckBackend.Util.reg_expressions.regEx_texto, ErrorMessage = "Invalid input format on Username")]
        public string username { get; set; }

        [Required(AllowEmptyStrings = false)]
        [RegularExpression(DymaDieckBackend.Util.reg_expressions.regEx_texto, ErrorMessage = "Invalid input format On Password")]
        public string password { get; set; }
    }
}