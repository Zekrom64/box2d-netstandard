using System;
using System.Numerics;
using Box2D.NetStandard.Dynamics.Bodies;

namespace Box2D.NetStandard.Dynamics.Joints.Wheel
{
    public class WheelJointDef : JointDef
    {
        public float Damping;

        public bool EnableLimit;
        public bool EnableMotor;

        public Vector2 LocalAnchorA;
        public Vector2 LocalAnchorB;
        public Vector2 LocalAxisA;
        public float LowerTranslation;
        public float MaxMotorTorque;
        public float MotorSpeed;

        public float Stiffness;
        public float UpperTranslation;

        public void Initialize(Body bA, Body bB, in Vector2 anchor, in Vector2 axis)
        {
            BodyA = bA;
            BodyB = bB;
            LocalAnchorA = BodyA.GetLocalPoint(anchor);
            LocalAnchorB = BodyB.GetLocalPoint(anchor);
            LocalAxisA = BodyA.GetLocalVector(axis);
        }
    }
}