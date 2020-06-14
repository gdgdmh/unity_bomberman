using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman
{
    public class Map001Block001RandomCreate
    {
        static readonly int RandMin = 0;
        static readonly int RandMax = 100;
        static readonly int CreatePercent = 80;

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
            Mhl.IRandIntGeneratable random = new Mhl.RandIntSystem();
            // 破壊可能ブロックの生成(ランダム)
            int length = list.Length();
            for (int i = 0; i < length; ++i)
            {
                if (IsRandomBlockCreate(random) == false)
                {
                    continue;
                }
                Vector3 vector3 = position.ToVector3(list.Get(i));
                factory.Create(vector3);
            }
        }

        /// <summary>
        /// ランダムでブロックを作成するか(乱数で決まる)
        /// </summary>
        /// <returns>trueなら作成</returns>
        private bool IsRandomBlockCreate(Mhl.IRandIntGeneratable random)
        {
            random.SetSeed(random.Get());
            int percent = random.GetRange(RandMin, RandMax);
            Debug.Log(percent);
            if (percent >= (RandMax - CreatePercent))
            {
                return true;
            }
            return false;
        }
    }
}
