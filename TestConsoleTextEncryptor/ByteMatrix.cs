using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleTextEncryptor
{
    internal class ByteMatrix
    {
        //[ 0][ 4][ 8][12] X
        //[ 1][ 5][ 9][13]
        //[ 2][ 6][10][14]
        //[ 3][ 7][11][15]
        //Y
        //[x,y]
        byte[] bytes;

        public ByteMatrix(byte[] data)
        {
            bytes = data.ToArray();
        }

        public byte GetByte(int i)
        {
            return bytes[i];
        }

        public byte GetByte(int x, int y)
        {
            return bytes[x+y*4];
        }

        public ByteMatrix XORinit(ByteMatrix key)
        {
            byte[] newBytes = new byte[16];
            for (int i = 0; i < newBytes.Length; i++)
            {
                newBytes[i] = (byte)(this.bytes[i] ^ key.bytes[i]);
            }
            return new ByteMatrix(newBytes);
        }

        public void SubBytes()
        {
            for (int i = 0; i < 16; ++i)
            {
                bytes[i] = EncryptorHelper.GetFromSBox(bytes[i]);
            }
        }  // SubBytes

        public void InvSubBytes()
        {
            for (int i = 0; i < 16; ++i)
            {
                bytes[i] = EncryptorHelper.GetFromInvSBox(bytes[i]);
            }
        }  // SubBytes
    }
}
