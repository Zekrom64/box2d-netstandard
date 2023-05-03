using Box2D.NetStandard.Dynamics.Bodies;
using System;

namespace Box2D.NetStandard.Dynamics.Joints
{
    /// <summary>
    ///  Joint definitions are used to construct joints.
    /// </summary>
    public class JointDef
    {

		private Body? bodyA;

        /// <summary>
        ///  The first attached body.
        /// </summary>
        public Body BodyA {
			get {
#if DEBUG
				return bodyA ?? throw new InvalidOperationException();
#else
				return bodyA!;
#endif
			}
			set => bodyA = value;
		}

		private Body? bodyB;

        /// <summary>
        ///  The second attached body.
        /// </summary>
        public Body BodyB {
			get {
#if DEBUG
				return bodyB ?? throw new InvalidOperationException();
#else
				return bodyB!;
#endif
			}
			set => bodyB = value;
		}

		/// <summary>
		///  Set this flag to true if the attached bodies should collide.
		/// </summary>
		public bool CollideConnected;

        /// <summary>
        ///  Use this to attach application specific data to your joints.
        /// </summary>
        public object? UserData;

        public JointDef()
        {
            UserData = null;
            CollideConnected = false;
        }
    }
}