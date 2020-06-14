using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman
{
    public class Map001DestructableBlockPosition
    {
        public Map001BlockPositionList Get()
        {
            Map001BlockPositionList list = new Map001BlockPositionList();

            Map001BlockPosition.Position[] positions = new Map001BlockPosition.Position[]
            {
                Map001BlockPosition.Position.A4,
                Map001BlockPosition.Position.A5,
                Map001BlockPosition.Position.A6,
                Map001BlockPosition.Position.A7,
                Map001BlockPosition.Position.A8,
                Map001BlockPosition.Position.A9,
                Map001BlockPosition.Position.A10,

                Map001BlockPosition.Position.B5,
                Map001BlockPosition.Position.B7,
                Map001BlockPosition.Position.B9,

                Map001BlockPosition.Position.C4,
                Map001BlockPosition.Position.C5,
                Map001BlockPosition.Position.C6,
                Map001BlockPosition.Position.C7,
                Map001BlockPosition.Position.C8,
                Map001BlockPosition.Position.C9,
                Map001BlockPosition.Position.C10,

                Map001BlockPosition.Position.D5,
                Map001BlockPosition.Position.D7,
                Map001BlockPosition.Position.D9,


                Map001BlockPosition.Position.E1,
                Map001BlockPosition.Position.E2,
                Map001BlockPosition.Position.E3,
                Map001BlockPosition.Position.E4,
                Map001BlockPosition.Position.E5,
                Map001BlockPosition.Position.E6,
                Map001BlockPosition.Position.E7,
                Map001BlockPosition.Position.E8,
                Map001BlockPosition.Position.E9,
                Map001BlockPosition.Position.E10,
                Map001BlockPosition.Position.E11,
                Map001BlockPosition.Position.E12,
                Map001BlockPosition.Position.E13,

                Map001BlockPosition.Position.F1,
                Map001BlockPosition.Position.F3,
                Map001BlockPosition.Position.F5,
                Map001BlockPosition.Position.F7,
                Map001BlockPosition.Position.F9,
                Map001BlockPosition.Position.F11,
                Map001BlockPosition.Position.F13,

                Map001BlockPosition.Position.G1,
                Map001BlockPosition.Position.G2,
                Map001BlockPosition.Position.G3,
                Map001BlockPosition.Position.G4,
                Map001BlockPosition.Position.G5,
                Map001BlockPosition.Position.G6,
                Map001BlockPosition.Position.G7,
                Map001BlockPosition.Position.G8,
                Map001BlockPosition.Position.G9,
                Map001BlockPosition.Position.G10,
                Map001BlockPosition.Position.G11,
                Map001BlockPosition.Position.G12,
                Map001BlockPosition.Position.G13,

                Map001BlockPosition.Position.H1,
                Map001BlockPosition.Position.H3,
                Map001BlockPosition.Position.H5,
                Map001BlockPosition.Position.H7,
                Map001BlockPosition.Position.H9,
                Map001BlockPosition.Position.H11,
                Map001BlockPosition.Position.H13,

                Map001BlockPosition.Position.I1,
                Map001BlockPosition.Position.I2,
                Map001BlockPosition.Position.I3,
                Map001BlockPosition.Position.I4,
                Map001BlockPosition.Position.I5,
                Map001BlockPosition.Position.I6,
                Map001BlockPosition.Position.I7,
                Map001BlockPosition.Position.I8,
                Map001BlockPosition.Position.I9,
                Map001BlockPosition.Position.I10,
                Map001BlockPosition.Position.I11,
                Map001BlockPosition.Position.I12,
                Map001BlockPosition.Position.I13,

                Map001BlockPosition.Position.J5,
                Map001BlockPosition.Position.J7,
                Map001BlockPosition.Position.J9,

                Map001BlockPosition.Position.K4,
                Map001BlockPosition.Position.K5,
                Map001BlockPosition.Position.K6,
                Map001BlockPosition.Position.K7,
                Map001BlockPosition.Position.K8,
                Map001BlockPosition.Position.K9,
                Map001BlockPosition.Position.K10,

                Map001BlockPosition.Position.L5,
                Map001BlockPosition.Position.L7,
                Map001BlockPosition.Position.L9,

                Map001BlockPosition.Position.M4,
                Map001BlockPosition.Position.M5,
                Map001BlockPosition.Position.M6,
                Map001BlockPosition.Position.M7,
                Map001BlockPosition.Position.M8,
                Map001BlockPosition.Position.M9,
                Map001BlockPosition.Position.M10,
            };

            list.Add(positions);
            return list;
        }
    }
}