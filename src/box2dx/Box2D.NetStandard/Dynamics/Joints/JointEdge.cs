using Box2D.NetStandard.Dynamics.Bodies;
using System;

namespace Box2D.NetStandard.Dynamics.Joints
{
    /// <summary>
    ///  A joint edge is used to connect bodies and joints together
    ///  in a joint graph where each body is a node and each joint
    ///  is an edge. A joint edge belongs to a doubly linked list
    ///  maintained in each attached body. Each joint has two joint
    ///  nodes, one for each attached body.
    /// </summary>
    public class JointEdge
    {
		private Joint? joint;

		/// <summary>
		///  The joint.
		/// </summary>
		public Joint Joint {
			get {
#if DEBUG
				return joint ?? throw new InvalidOperationException();
#else
				return joint!;
#endif
			}
			set => joint = value;
		}

		/// <summary>
		///  The next joint edge in the body's joint list.
		/// </summary>
		public JointEdge? Next;

		private Body? body;

        /// <summary>
        ///  Provides quick access to the other body attached.
        /// </summary>
        public Body Other {
			get {
#if DEBUG
				return body ?? throw new InvalidOperationException();
#else
				return body!;
#endif
			}
			set => body = value;
		}

		/// <summary>
		///  The previous joint edge in the body's joint list.
		/// </summary>
		public JointEdge? Prev;
    }
}