using System.Runtime.Serialization;

namespace Iviz.Msgs.std_msgs
{
    public sealed class ByteMultiArray : IMessage
    {
        // Please look at the MultiArrayLayout message definition for
        // documentation on all multiarrays.
        
        public MultiArrayLayout layout { get; set; } // specification of data layout
        public byte[] data { get; set; } // array of data
        
    
        /// <summary> Constructor for empty message. </summary>
        public ByteMultiArray()
        {
            layout = new MultiArrayLayout();
            data = System.Array.Empty<byte>();
        }
        
        /// <summary> Explicit constructor. </summary>
        public ByteMultiArray(MultiArrayLayout layout, byte[] data)
        {
            this.layout = layout ?? throw new System.ArgumentNullException(nameof(layout));
            this.data = data ?? throw new System.ArgumentNullException(nameof(data));
        }
        
        /// <summary> Constructor with buffer. </summary>
        internal ByteMultiArray(Buffer b)
        {
            this.layout = new MultiArrayLayout(b);
            this.data = b.DeserializeStructArray<byte>(0);
        }
        
        public IMessage Deserialize(Buffer b)
        {
            if (b is null) throw new System.ArgumentNullException(nameof(b));
            return new ByteMultiArray(b);
        }
    
        public void Serialize(Buffer b)
        {
            if (b is null) throw new System.ArgumentNullException(nameof(b));
            this.layout.Serialize(b);
            b.SerializeStructArray(this.data, 0);
        }
        
        public void Validate()
        {
            if (layout is null) throw new System.NullReferenceException();
            if (data is null) throw new System.NullReferenceException();
        }
    
        [IgnoreDataMember]
        public int RosMessageLength
        {
            get {
                int size = 4;
                size += layout.RosMessageLength;
                size += 1 * data.Length;
                return size;
            }
        }
    
        [IgnoreDataMember]
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve]
        public const string RosMessageType = "std_msgs/ByteMultiArray";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve]
        public const string RosMd5Sum = "70ea476cbcfd65ac2f68f3cda1e891fe";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve]
        public const string RosDependenciesBase64 =
                "H4sIAAAAAAAAE71U32vbMBB+919xJC9tlmb5Ucpa6ENgsJcWBh2MEkJRrXOsRLaCJDfL/vp9kh3bafc4" +
                "ZgyW73R33/fpTkP6rlk4Jm3MjoQnnzM9VtqrpbXi+CCOpvJUsHNiwyQ5U6XyypSUGZsMSZq0Krj0Itrw" +
                "Cq2pCOEihLtJknxIRrr51s+Q3J5Tlam0SZKRFF40u5LXo+fVmnpP9FIXHiudwpIkuf/HT/L49O2OnJcv" +
                "hdu4z+/5QIUf0KwjDZVSLSw7ErThkq1Ka++VVNDKgaTQHWqBBHthvUorRNXs/HHPE6Kvp/1IZZmMlWxZ" +
                "UmZNQajMlgrjAgBvSJVl83+meZsCGqI85Fq2cp1ctLdmz0DALqlU6RfziOLFZJnj3jnthZSq3BBrDmfu" +
                "QrsAS+k78ZE+TdEsxjpyuam0pOXDz+XzE70yHazynktAJWAv3DkI562SjAyilKeWANnI8yrw6u3NlA08" +
                "h4S3E/5Cjbfj3SXdRzCrPodPIfilLrGarUfq3DJfj7aw7NbJMFAAFoAQVo5pcZXmAtJqurme/rr+MiVV" +
                "hEk4KJ+DCLBhfN6AMzXaWGo2O2Q5RPag3XER7i4WQOXVdD3R4hV5AXeQs9rkftC5nPrNFFyo2LNGtLAu" +
                "RkAzCmju6XY+u5lOiS5K47nZ2YhJytG2gnIxHdSO2C+bhLM+goOSPh90nhYACvWsZwDwnd3OT+55P12j" +
                "w6DztQkXPVubLsry8SQtZ4xOQnuHaylIbs1hTFssoHdVlOPYLbvwX1ec/Mf5b2crCUQwGA1/jEq9guIb" +
                "9YaObzv3NF+NGuHya47m3Ua6CFOCa4AqXLjusg2sJQuB9eovNf4A8nBJftQFAAA=";
                
    }
}
