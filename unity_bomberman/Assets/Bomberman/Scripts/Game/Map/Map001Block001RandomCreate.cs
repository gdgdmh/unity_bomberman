using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman
{
    public class Map001Block001RandomCreate
    {
        public void Create()
        {
            Map001DestructableBlockPosition destructableBlockPosition = new Map001DestructableBlockPosition();
            Map001BlockPositionList list = destructableBlockPosition.Get();

            Debug.Log(list.Length());
            Debug.Log(list.Has(Map001BlockPosition.Position.A2));
            Debug.Log(list.Has(Map001BlockPosition.Position.A4));

        }
    }
}
