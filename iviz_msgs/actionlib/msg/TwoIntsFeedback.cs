/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.Actionlib
{
    [DataContract (Name = "actionlib/TwoIntsFeedback")]
    public sealed class TwoIntsFeedback : IDeserializable<TwoIntsFeedback>, IFeedback<TwoIntsActionFeedback>
    {
        /// <summary> Constructor for empty message. </summary>
        public TwoIntsFeedback()
        {
        }
        
        /// <summary> Constructor with buffer. </summary>
        public TwoIntsFeedback(ref Buffer b)
        {
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new TwoIntsFeedback(ref b);
        }
        
        TwoIntsFeedback IDeserializable<TwoIntsFeedback>.RosDeserialize(ref Buffer b)
        {
            return new TwoIntsFeedback(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
        }
        
        public void RosValidate()
        {
        }
    
        /// <summary> Constant size of this message. </summary>
        public const int RosFixedMessageLength = 0;
        
        public int RosMessageLength => RosFixedMessageLength;
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "actionlib/TwoIntsFeedback";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "d41d8cd98f00b204e9800998ecf8427e";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAAE+MCAJMG1zIBAAAA";
                
    }
}
