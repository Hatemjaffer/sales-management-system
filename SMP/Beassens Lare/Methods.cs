using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.Beassens_Lare
{
    class Methods
    {
       public MemoryStream ma = new MemoryStream();
       public byte[] by;

        //Convaret to byte
        public byte[] convert_byte()
        {
            return ma.ToArray();
        }
        //Convert byte image
        public MemoryStream convert_image()
        {
            ma = new MemoryStream(by);
            return ma;
        }
    }
}
