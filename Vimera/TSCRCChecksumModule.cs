using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Vimera{
    public class TSCrcChecksumModule{
        private static readonly uint[] crc32Table;
        private static readonly ulong[] crc64Table;
        static TSCrcChecksumModule(){
            // CRC32 (ISO 3309 / Ethernet)
            uint poly32 = 0xEDB88320;
            crc32Table = new uint[256];
            for (uint i = 0; i < 256; i++){
                uint temp = i;
                for (int j = 8; j > 0; j--){
                    if ((temp & 1) == 1){
                        temp = (temp >> 1) ^ poly32;
                    }else{
                        temp >>= 1;
                    }
                }
                crc32Table[i] = temp;
            }
            // CRC64 (ECMA-182)
            ulong poly64 = 0x42F0E1EBA9EA3693;
            crc64Table = new ulong[256];
            for (ulong i = 0; i < 256; i++){
                ulong temp = i;
                for (int j = 0; j < 8; j++){
                    if ((temp & 1) == 1){
                        temp = (temp >> 1) ^ poly64;
                    }else{
                        temp >>= 1;
                    }
                }
                crc64Table[i] = temp;
            }
        }
        public static uint CalculateCrc32(string input){
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            using (var stream = new MemoryStream(bytes)){
                return ComputeCrc32(stream);
            }
        }
        public static ulong CalculateCrc64(string input){
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            using (var stream = new MemoryStream(bytes)){
                return ComputeCrc64(stream);
            }
        }
        private static uint ComputeCrc32(Stream stream){
            uint crc = 0xFFFFFFFF;
            const int bufferSize = 4096;
            byte[] buffer = new byte[bufferSize];
            int bytesRead;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0){
                for (int i = 0; i < bytesRead; i++){
                    byte b = buffer[i];
                    crc = (crc >> 8) ^ crc32Table[(crc & 0xFF) ^ b];
                }
            }
            return ~crc;
        }
        private static ulong ComputeCrc64(Stream stream){
            ulong crc = 0;
            const int bufferSize = 4096;
            byte[] buffer = new byte[bufferSize];
            int bytesRead;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0){
                for (int i = 0; i < bytesRead; i++){
                    byte b = buffer[i];
                    crc = (crc >> 8) ^ crc64Table[(crc & 0xFF) ^ b];
                }
            }
            return crc;
        }
    }
    // CRC32
    public class TSCrc32 : HashAlgorithm{
        private static readonly uint[] crc32Table;
        private uint crc;
        static TSCrc32(){
            uint poly32 = 0xEDB88320;
            crc32Table = new uint[256];
            for (uint i = 0; i < 256; i++){
                uint temp = i;
                for (int j = 8; j > 0; j--){
                    if ((temp & 1) == 1){
                        temp = (temp >> 1) ^ poly32;
                    }else{
                        temp >>= 1;
                    }
                }
                crc32Table[i] = temp;
            }
        }
        public TSCrc32(){
            HashSizeValue = 32;
            Initialize();
        }
        public override void Initialize(){
            crc = 0xFFFFFFFF;
        }
        protected override void HashCore(byte[] array, int ibStart, int cbSize){
            for (int i = 0; i < cbSize; i++){
                byte b = array[ibStart + i];
                crc = (crc >> 8) ^ crc32Table[(crc & 0xFF) ^ b];
            }
        }
        protected override byte[] HashFinal(){
            uint finalCrc = ~crc;
            byte[] bytes = new byte[4];
            bytes[0] = (byte)(finalCrc);
            bytes[1] = (byte)(finalCrc >> 8);
            bytes[2] = (byte)(finalCrc >> 16);
            bytes[3] = (byte)(finalCrc >> 24);
            return bytes;
        }
    }
    // CRC64
    public class TSCrc64 : HashAlgorithm{
        private static readonly ulong[] crc64Table;
        private ulong crc;
        static TSCrc64(){
            ulong poly64 = 0x42F0E1EBA9EA3693;
            crc64Table = new ulong[256];
            for (ulong i = 0; i < 256; i++){
                ulong temp = i;
                for (int j = 0; j < 8; j++){
                    if ((temp & 1) == 1){
                        temp = (temp >> 1) ^ poly64;
                    }else{
                        temp >>= 1;
                    }
                }
                crc64Table[i] = temp;
            }
        }
        public TSCrc64(){
            HashSizeValue = 64;
            Initialize();
        }
        public override void Initialize(){
            crc = 0;
        }
        protected override void HashCore(byte[] array, int ibStart, int cbSize){
            for (int i = 0; i < cbSize; i++){
                byte b = array[ibStart + i];
                crc = (crc >> 8) ^ crc64Table[(crc & 0xFF) ^ b];
            }
        }
        protected override byte[] HashFinal(){
            byte[] bytes = new byte[8];
            bytes[0] = (byte)(crc);
            bytes[1] = (byte)(crc >> 8);
            bytes[2] = (byte)(crc >> 16);
            bytes[3] = (byte)(crc >> 24);
            bytes[4] = (byte)(crc >> 32);
            bytes[5] = (byte)(crc >> 40);
            bytes[6] = (byte)(crc >> 48);
            bytes[7] = (byte)(crc >> 56);
            return bytes;
        }
    }
}