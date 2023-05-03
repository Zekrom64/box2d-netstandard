using System;
using System.Numerics;
using Box2D.NetStandard.Dynamics.Bodies;

namespace Box2D.NetStandard.Dynamics.Joints.Wheel
{
    public class WheelJointDef : JointDef
    {
        public float damping;

        public bool enableLimit;
        public bool enableMotor;

        public Vector2 localAnchorA;
        public Vector2 localAnchorB;
        public Vector2 localAxisA;
        public float lowerTranslation;
        public float maxMotorTorque;
        public float motorSpeed;

        public float stiffness;
        public float upperTranslation;

        public void Initialize(Body bA, Body bB, in Vector2 anchor, in Vector2 axis)
        {
            bodyA = bA;
            bodyB = bB;
            localAnchorA = bodyA.GetLocalPoint(anchor);
            localAnchorB = bodyB.GetLocalPoint(anchor);
            localAxisA = bodyA.GetLocalVector(axis);
        }
    }
}