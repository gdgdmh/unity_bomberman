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
                Map001BlockPosition.Position.A10
            };

            list.Add(positions);
            return list;
        }
    }
}