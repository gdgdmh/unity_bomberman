using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman
{
    public class Map001 : MonoBehaviour
    {
        private Map001BlockPosition blockPosition = new Map001BlockPosition();

        void Start()
        {
            {
                Vector3 v = blockPosition.ToVector3(Map001BlockPosition.Position.B2);
                Debug.Log(string.Format("x={0} y={1} z={2}", v.x, v.y, v.z));
            }
            {
                Vector3 v = blockPosition.ToVector3(Map001BlockPosition.Position.L10);
                Debug.Log(string.Format("x={0} y={1} z={2}", v.x, v.y, v.z));
            }
            // test
            {
                Vector3 v = blockPosition.ToVector3(Map001BlockPosition.Position.A1);
                Debug.Log(string.Format("x={0} y={1} z={2}", v.x, v.y, v.z));
                InnerBlock001Factory f = new InnerBlock001Factory();
                f.Create(v);
            }



        }

        void Update()
        {

        }
    }
}
