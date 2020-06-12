using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman
{
    public class InnerBlock001Factory
    {
        private static readonly string Path = "Prefabs/InnerBlock001";

        public GameObject Create(Vector3 position)
        {
            GameObject b = Resources.Load(Path) as GameObject;
            return Object.Instantiate(b, position, Quaternion.identity);
        }
    }
}
