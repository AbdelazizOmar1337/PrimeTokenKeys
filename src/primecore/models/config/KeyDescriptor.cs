using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeCore.Service.Identity
{
    public class KeyDescriptor
    {

        public SecretKey SecretKey { get; set; }
        public KeySignature KeySignature { get; set; }
    }
}
