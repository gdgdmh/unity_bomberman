using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman
{
    /// <summary>
    /// Map001でのInnerBlock001をランダム生成クラス
    /// </summary>
    public class Map001Block001RandomCreate
    {
        static readonly int RandMin = 0;        // 確率生成用の最小値
        static readonly int RandMax = 100;      // 確率生成用の最大値
        static readonly int CreatePercent = 80; // InnerBlock001が生成される確率

        /// <summary>
        /// InnerBlock001をランダム生成する
        /// </summary>
        public void Create()
        {
            // 破壊可能なブロックの位置を取得
            Map001DestructableBlockPosition destructableBlockPosition = new Map001DestructableBlockPosition();
            Map001BlockPositionList list = destructableBlockPosition.Get();
            Map001BlockPosition position = new Map001BlockPosition();

            InnerBlock001Factory factory = new InnerBlock001Factory();
            Mhl.IRandIntGeneratable random = new Mhl.RandIntSystem();
            // 破壊可能ブロックの生成(ランダム)
            int length = list.Length();
            for (int i = 0; i < length; ++i)
            {
                if (IsRandomBlockCreate(random) == false)
                {
                    // 確率判定で作成しないと判断された時はスキップ
                    continue;
                }
                Vector3 vector3 = position.ToVector3(list.Get(i));
                factory.Create(vector3);
            }
        }

        /// <summary>
        /// ランダムでブロックを作成するか(乱数で決まる)
        /// </summary>
        /// <param name="random">乱数生成インターフェースクラス</param>
        /// <returns>trueなら作成する</returns>
        private bool IsRandomBlockCreate(Mhl.IRandIntGeneratable random)
        {
            random.SetSeed(random.Get());
            int percent = random.GetRange(RandMin, RandMax);
            if (percent >= (RandMax - CreatePercent))
            {
                return true;
            }
            return false;
        }
    }
}
