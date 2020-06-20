﻿/*
  Box2DX Copyright (c) 2008 Ihar Kalasouski http://code.google.com/p/box2dx
  Box2D original C++ version Copyright (c) 2006-2007 Erin Catto http://www.gphysics.com

  This software is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this software.

  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this software must not be misrepresented; you must not
     claim that you wrote the original software. If you use this software
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original software.
  3. This notice may not be removed or altered from any source distribution.
*/

using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Box2D.NetStandard.Common
{
	/// <summary>
	/// A 2-by-2 matrix. Stored in column-major order.
	/// </summary>
	public struct Mat22
	{
		public Vector2 ex, ey;

		/// <summary>
		/// Construct this matrix using columns.
		/// </summary>
		public Mat22(Vector2 c1, Vector2 c2)
		{
			ex = c1;
			ey = c2;
		}

		/// <summary>
		/// Construct this matrix using scalars.
		/// </summary>
		public Mat22(float a11, float a12, float a21, float a22)
		{
			ex.X = a11; ex.Y = a21;
			ey.X = a12; ey.Y = a22;
		}

		/// <summary>
		/// Construct this matrix using an angle. 
		/// This matrix becomes an orthonormal rotation matrix.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Mat22(float angle)
		{
			float c = (float)System.Math.Cos(angle), s = (float)System.Math.Sin(angle);
			ex.X = c; ey.X = -s;
			ex.Y = s; ey.Y = c;
		}

		/// <summary>
		/// Initialize this matrix using columns.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(Vector2 c1, Vector2 c2)
		{
			ex = c1;
			ey = c2;
		}

		/// <summary>
		/// Initialize this matrix using an angle.
		/// This matrix becomes an orthonormal rotation matrix.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(float angle)
		{
			float c = (float)System.Math.Cos(angle), s = (float)System.Math.Sin(angle);
			ex.X = c; ey.X = -s;
			ex.Y = s; ey.Y = c;
		}

		/// <summary>
		/// Set this to the identity matrix.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetIdentity()
		{
			ex.X = 1.0f; ey.X = 0.0f;
			ex.Y = 0.0f; ey.Y = 1.0f;
		}

		/// <summary>
		/// Set this matrix to all zeros.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetZero()
		{
			ex.X = 0.0f; ey.X = 0.0f;
			ex.Y = 0.0f; ey.Y = 0.0f;
		}

		/// <summary>
		/// Extract the angle from this matrix (assumed to be a rotation matrix).
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float GetAngle() => (float)System.Math.Atan2(ex.Y, ex.X);

		/// <summary>
		/// Compute the inverse of this matrix, such that inv(A) * A = identity.
		/// </summary>
		public Mat22 GetInverse()
		{
			float a = ex.X, b = ey.X, c = ex.Y, d = ey.Y;
			Mat22 B = new Mat22();
			float det = a * d - b * c;
			Debug.Assert(det != 0.0f);
			det = 1.0f / det;
			B.ex.X = det * d; B.ey.X = -det * b;
			B.ex.Y = -det * c; B.ey.Y = det * a;
			return B;
		}

		/// <summary>
		/// Solve A * x = b, where b is a column vector. This is more efficient
		/// than computing the inverse in one-shot cases.
		/// </summary>
		public Vector2 Solve(Vector2 b)
		{
			float a11 = ex.X, a12 = ey.X, a21 = ex.Y, a22 = ey.Y;
			float det = a11 * a22 - a12 * a21;
			Debug.Assert(det != 0.0f);
			det = 1.0f / det;
			Vector2 x = new Vector2();
			x.X = det * (a22 * b.X - a12 * b.Y);
			x.Y = det * (a11 * b.Y - a21 * b.X);
			return x;
		}

		public static Mat22 Identity {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => new Mat22(1, 0, 0, 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Mat22 operator +(Mat22 A, Mat22 B) => new Mat22(A.ex + B.ex, A.ey + B.ey);
	}
}
