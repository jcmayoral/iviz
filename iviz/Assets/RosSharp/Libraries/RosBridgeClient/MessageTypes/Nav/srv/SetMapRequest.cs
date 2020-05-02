/* 
 * This message is auto generated by ROS#. Please DO NOT modify.
 * Note:
 * - Comments from the original code will be written in their own line 
 * - Variable sized arrays will be initialized to array of size 0 
 * Please report any issues at 
 * <https://github.com/siemens/ros-sharp> 
 */

using Newtonsoft.Json;
using RosSharp.RosBridgeClient.MessageTypes.Geometry;

namespace RosSharp.RosBridgeClient.MessageTypes.Nav
{
    public class SetMapRequest : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "nav_msgs/SetMap";

        //  Set a new map together with an initial pose
        public OccupancyGrid map;
        public PoseWithCovarianceStamped initial_pose;

        public SetMapRequest()
        {
            this.map = new OccupancyGrid();
            this.initial_pose = new PoseWithCovarianceStamped();
        }

        public SetMapRequest(OccupancyGrid map, PoseWithCovarianceStamped initial_pose)
        {
            this.map = map;
            this.initial_pose = initial_pose;
        }
    }
}
