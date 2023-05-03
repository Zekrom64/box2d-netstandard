using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Box2D.NetStandard.Common
{
    public struct Rot
    {
        /// Sine and cosine
        internal float s;

        /// Sine and cosine
        internal float c;

        /// Initialize from an angle in radians
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Rot(float angle)
        {
            s = MathF.Sin(angle);
            c = MathF.Cos(angle);
        }

        /// Set using an angle in radians.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Set(float angle)
        {
            s = MathF.Sin(angle);
            c = MathF.Cos(angle);
        }

        /// Set to the identity rotation
        public void SetIdentity()
        {
            s = 0.0f;
            c = 1.0f;
        }

		/// Get the angle in radians
		public float GetAngle() => MathF.Atan2(s, c);

		/// Get the x-axis
		public Vector2 GetXAxis() => new(c, s);

		/// Get the u-axis
		public Vector2 GetYAxis() => new(-s, c);
    }
}