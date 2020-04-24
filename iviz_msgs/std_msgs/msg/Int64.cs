namespace Iviz.Msgs.std_msgs
{
    public sealed class Int64 : IMessage
    {
        public long data;
    
        public unsafe void Deserialize(ref byte* ptr, byte* end)
        {
            BuiltIns.Deserialize(out data, ref ptr, end);
        }
    
        public unsafe void Serialize(ref byte* ptr, byte* end)
        {
            BuiltIns.Serialize(data, ref ptr, end);
        }
    
        public int GetLength() => 8;
    
        public IMessage Create() => new Int64();
    
        /// <summary> Full ROS name of this message. </summary>
        public const string _MessageType = "std_msgs/Int64";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        public const string _Md5Sum = "34add168574510e6e17f5d23ecc077ef";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        public const string _DependenciesBase64 =
                "H4sIAAAAAAAAE8vMKzEzUUhJLEnkAgBZU74aCwAAAA==";
                
    }
}
