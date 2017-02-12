using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Despesa.Lite.Xamarin.Portable.Aplicacao.WebService.Token
{
    public class Token
    {
        public string access_token { get; set; }

        public string expires_in { get; set; }

        public string issued { get; set; }

        public string expires { get; set; }
    }
}
