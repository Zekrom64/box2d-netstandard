using Box2D.NetStandard.Collision;
using System;

namespace Box2D.NetStandard.Dynamics.Fixtures
{
    internal class FixtureProxy
    {
        internal AABB aabb;
        internal int childIndex;

		private Fixture? m_fixture;

        internal Fixture fixture {
			get {
#if DEBUG
				return m_fixture ?? throw new InvalidOperationException();
#else
				return m_fixture!;
#endif
			}
			set => m_fixture = value;
		}

        internal int proxyId = -1;
    }
}