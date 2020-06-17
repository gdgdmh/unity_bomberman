using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman
{
    /// <summary>
    /// InnerBlock001作成クラス
    /// </summary>
    public class InnerBlock001Factory
    {
        // Prefabのパス
        private static readonly string Path = "Prefabs/InnerBlock001";

        /// <summary>
        /// InnerBlock001の作成
        /// </summary>
        /// <param name="position">作成位置</param>
        /// <returns>作成したInnerBlock001のGameObject</returns>
        public GameObject Create(Vector3 position)
        {
            GameObject b = Resources.Load(Path) as GameObject;
            return Object.Instantiate(b, position, Quaternion.identity);
        }
    }
}
