namespace AvalancheDotNet.Common
{
    #warning TODO : Rename this class 
    internal class Buffer
    {
        public byte[] data;
        public string ToHexString()
        {
            return System.BitConverter.ToString(data).Replace("-", string.Empty);
        }
    }
}