using System;

namespace Box2D.NetStandard.Dynamics.World
{
    public class SolverData
    {
        internal Position[] positions = Array.Empty<Position>();
        internal TimeStep step;
        internal Velocity[] velocities = Array.Empty<Velocity>();
    }
}