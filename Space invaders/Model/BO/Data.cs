using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Space_invaders.Model.BO
{
    public class Data
    {
        public static byte[] Serialize(object data)
        {
            BinaryFormatter bin = new BinaryFormatter();
            MemoryStream mem = new MemoryStream();
            bin.Serialize(mem, data);
            return mem.GetBuffer();
        }

        public static object Deserialize(byte[] dataBuffer)
        {
            BinaryFormatter bin = new BinaryFormatter();
            MemoryStream mem = new MemoryStream();
            object temp = null;
            try
            {
                mem.Write(dataBuffer, 0, dataBuffer.Length);
                mem.Seek(0, 0);
                temp = bin.Deserialize(mem);
            }
            catch { }
            return temp;

        }
    }
}
