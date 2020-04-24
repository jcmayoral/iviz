namespace Iviz.Msgs.std_msgs
{
    public sealed class Time : IMessage
    {
        public time data;
    
        public unsafe void Deserialize(ref byte* ptr, byte* end)
        {
            BuiltIns.Deserialize(out data, ref ptr, end);
        }
    
        public unsafe void Serialize(ref byte* ptr, byte* end)
        {
            BuiltIns.Serialize(data, ref ptr, end);
        }
    
        public int GetLength() => 8;
    
        public IMessage Create() => new Time();
    
        /// <summary> Full ROS name of this message. </summary>
        public const string _MessageType = "std_msgs/Time";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        public const string _Md5Sum = "cd7166c74c552c311fbcc2fe5a7bc289";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        public const string _DependenciesBase64 =
                "H4sIAAAAAAAAEyvJzE1VSEksSeTiAgBuylFyCwAAAA==";
                
    }
}
