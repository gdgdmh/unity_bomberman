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
            Map001BlockPosition position = new Map001BlockPosition();

            // list test
            //Debug.Log(list.Length());
            //Debug.Log(list.Has(Map001BlockPosition.Position.A2));
            //Debug.Log(list.Has(Map001BlockPosition.Position.A4));

            InnerBlock001Factory factory = new InnerBlock001Factory();
            int length = list.Length();
            for (int i = 0; i < length; ++i)
            {
                Vector3 vector3 = position.ToVector3(list.Get(i));
                factory.Create(vector3);
            }
        }
    }
}
