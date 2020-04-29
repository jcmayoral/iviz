using System.Runtime.Serialization;

namespace Iviz.Msgs.rosbridge_library
{
    public sealed class TestMultipleRequestFields : IService
    {
        /// <summary> Request message. </summary>
        public TestMultipleRequestFieldsRequest Request { get; }
        
        /// <summary> Response message. </summary>
        public TestMultipleRequestFieldsResponse Response { get; set; }
        
        /// <summary> Empty constructor. </summary>
        public TestMultipleRequestFields()
        {
            Request = new TestMultipleRequestFieldsRequest();
            Response = new TestMultipleRequestFieldsResponse();
        }
        
        /// <summary> Setter constructor. </summary>
        public TestMultipleRequestFields(TestMultipleRequestFieldsRequest request)
        {
            Request = request;
            Response = new TestMultipleRequestFieldsResponse();
        }
        
        public IService Create() => new TestMultipleRequestFields();
        
        IRequest IService.Request => Request;
        
        IResponse IService.Response => Response;
        
        public string ErrorMessage { get; set; }
        
        [IgnoreDataMember]
        public string RosType => RosServiceType;
        
        /// <summary> Full ROS name of this service. </summary>
        [Preserve]
        public const string RosServiceType = "rosbridge_library/TestMultipleRequestFields";
        
        /// <summary> MD5 hash of a compact representation of the service. </summary>
        [Preserve]
        public const string RosMd5Sum = "6cce9fb727dd0f31d504d7d198a1f4ef";
    }

    public sealed class TestMultipleRequestFieldsRequest : IRequest
    {
        public int @int;
        public float @float;
        public string @string;
        public bool @bool;
    
        /// <summary> Constructor for empty message. </summary>
        public TestMultipleRequestFieldsRequest()
        {
            @string = "";
        }
        
        public unsafe void Deserialize(ref byte* ptr, byte* end)
        {
            BuiltIns.Deserialize(out @int, ref ptr, end);
            BuiltIns.Deserialize(out @float, ref ptr, end);
            BuiltIns.Deserialize(out @string, ref ptr, end);
            BuiltIns.Deserialize(out @bool, ref ptr, end);
        }
    
        public unsafe void Serialize(ref byte* ptr, byte* end)
        {
            BuiltIns.Serialize(@int, ref ptr, end);
            BuiltIns.Serialize(@float, ref ptr, end);
            BuiltIns.Serialize(@string, ref ptr, end);
            BuiltIns.Serialize(@bool, ref ptr, end);
        }
    
        [IgnoreDataMember]
        public int RosMessageLength
        {
            get {
                int size = 13;
                size += BuiltIns.UTF8.GetByteCount(@string);
                return size;
            }
        }
    }

    public sealed class TestMultipleRequestFieldsResponse : Internal.EmptyResponse
    {
    }
}
