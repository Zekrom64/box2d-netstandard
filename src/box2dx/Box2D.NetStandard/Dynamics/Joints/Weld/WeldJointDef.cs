using System;
using System.Numerics;

namespace Box2D.NetStandard.Dynamics.Joints.Weld
{
    public class WeldJointDef : JointDef
    {
        /// <summary>
        ///  The rotational damping in N*m*s
        /// </summary>
        public float Damping;

        public Vector2 LocalAnchorA;
        public Vector2 LocalAnchorB;
        public float ReferenceAngle;

        /// <summary>
        ///  The rotational stiffness in N*m
        ///  Disable softness with a value of 0
        /// </summary>
        public float Stiffness;
    }
}