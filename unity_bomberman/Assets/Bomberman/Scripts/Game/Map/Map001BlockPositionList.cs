using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman
{
    /// <summary>
    /// ブロック位置リストクラス
    /// </summary>
    public class Map001BlockPositionList
    {
        private List<Map001BlockPosition.Position> positions = new List<Map001BlockPosition.Position>();

        public Map001BlockPositionList()
        {
        }

        /// <summary>
        /// リストに追加
        /// </summary>
        /// <param name="position">追加するPosition</param>
        public void Add(Map001BlockPosition.Position[] position)
        {
            positions.AddRange(position);
        }

        /// <summary>
        /// リストから削除
        /// </summary>
        /// <param name="position">削除するPosition</param>
        public void Remove(Map001BlockPosition.Position position)
        {
            positions.Remove(position);
        }

        /// <summary>
        /// データ数の取得
        /// </summary>
        /// <returns>データ数</returns>
        public int Length()
        {
            return positions.Count;
        }

        /// <summary>
        /// リストの中に指定されたPositionが存在しているか
        /// </summary>
        /// <param name="position">存在するかチェックするPosition</param>
        /// <returns>trueなら指定Positionがリストに存在している</returns>
        public bool Has(Map001BlockPosition.Position position)
        {
            foreach (Map001BlockPosition.Position p in positions)
            {
                if (p == position)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
