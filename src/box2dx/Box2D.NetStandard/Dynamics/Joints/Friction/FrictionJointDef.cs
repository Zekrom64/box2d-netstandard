using System.Numerics;
using Box2D.NetStandard.Dynamics.Bodies;

namespace Box2D.NetStandard.Dynamics.Joints.Friction
{
    public class FrictionJointDef : JointDef
    {
        public Vector2 LocalAnchorA;
        public Vector2 LocalAnchorB;
        public float MaxForce;
        public float MaxTorque;

        public void Initialize(Body bA, Body bB, in Vector2 anchor)
        {
            BodyA = bA;
            BodyB = bB;
            LocalAnchorA = BodyA.GetLocalPoint(anchor);
            LocalAnchorB = BodyB.GetLocalPoint(anchor);
        }
    }
}