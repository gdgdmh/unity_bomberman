using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman
{
    [RequireComponent(typeof(GameObject))]

    public class Bomb001 : MonoBehaviour
    {
        // 爆発方向
        enum ExplosionDirection : int
        {
            Up,
            Down,
            Left,
            Right
        };

        private static readonly string ExplosionEffectPrefabPath = "Prefabs/Explosion001"; // 爆風Prefabのパス
        private static readonly float PositionYOffset = 3; // 爆発エフェクト用のYオフセット
        private int explosionRange = 3;         // 爆発範囲
        private float explosionXZOffset = 2.0f; // 爆発エフェクトのオフセット(XZ共通)
        public GameObject map;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Bomb001 Start");
            // 3秒後に爆発する
            StartCoroutine(ExecuteExplosion(3.0f));
        }

        // Update is called once per frame
        void Update()
        {
        }

        /// <summary>
        /// 爆発処理
        /// </summary>
        /// <param name="waitTime">何秒後に爆発するか</param>
        /// <returns></returns>
        private IEnumerator ExecuteExplosion(float waitTime)
        {
            // 何秒か待って爆発する
            yield return new WaitForSeconds(waitTime);
            Vector3 position = transform.position;
            position.y += PositionYOffset;
            // 爆弾は消滅する
            Destroy(this.gameObject);
            // 爆発エフェクトを生成
            CreateExplosionEffect(position, explosionRange);
        }

        /// <summary>
        /// 爆発のエフェクトを作成
        /// </summary>
        /// <param name="basePosition">爆風の中央</param>
        /// <param name="range">爆発の飛距離</param>
        private void CreateExplosionEffect(Vector3 basePosition, int range)
        {
            if (range == 0)
            {
                // 爆発距離0なら生成しない
                return;
            }
            // 爆心地
            CreateEffect(basePosition);
            if (range == 1)
            {
                // 爆発距離1なら爆心地のみ
                return;
            }
            // 各方向の爆発
            int directionRange = range - 1;
            CreateEffectByDirection(ExplosionDirection.Up, basePosition, directionRange);
            CreateEffectByDirection(ExplosionDirection.Down, basePosition, directionRange);
            CreateEffectByDirection(ExplosionDirection.Left, basePosition, directionRange);
            CreateEffectByDirection(ExplosionDirection.Right, basePosition, directionRange);
        }

        /// <summary>
        /// 方向に応じた爆発エフェクトを作成する
        /// </summary>
        /// <param name="direction">方向</param>
        /// <param name="basePosition">基準位置</param>
        /// <param name="range">爆発の飛距離</param>
        private void CreateEffectByDirection(ExplosionDirection direction, Vector3 basePosition, int range)
        {
            float x = 0;
            float y = 0;
            float z = 0;
            for (int i = 0; i < range; ++i)
            {
                x = basePosition.x;
                y = basePosition.y;
                z = basePosition.z;
                // 方向に応じてオフセットを足す
                switch (direction)
                {
                    case ExplosionDirection.Down:
                        CreateEffect(new Vector3(x, y, z + (i + 1) * explosionXZOffset));
                        break;
                    case ExplosionDirection.Up:
                        CreateEffect(new Vector3(x, y, z + (i + 1) * -explosionXZOffset));
                        break;
                    case ExplosionDirection.Right:
                        CreateEffect(new Vector3(x + (i + 1) * -explosionXZOffset, y, z));
                        break;
                    case ExplosionDirection.Left:
                        CreateEffect(new Vector3(x + (i + 1) * explosionXZOffset, y, z));
                        break;
                }
            }
        }

        /// <summary>
        /// 指定位置に爆発エフェクトを生成する
        /// </summary>
        /// <param name="position">エフェクト発生位置</param>
        private void CreateEffect(Vector3 position)
        {
            GameObject effect = Resources.Load(ExplosionEffectPrefabPath) as GameObject;
            Instantiate(effect, position, Quaternion.identity);
        }

    }
}
