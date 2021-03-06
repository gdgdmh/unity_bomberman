﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman
{
    /// <summary>
    /// 爆発範囲をチェックする
    /// </summary>
    public class CheckExplosionRange
    {

        /// <summary>
        /// 方向
        /// </summary>
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        };

        /// <summary>
        /// 指定した方向の爆発範囲を取得する
        /// </summary>
        /// <param name="explosionPosition">爆発可能な位置(複数)</param>
        /// <param name="direction">方向</param>
        /// <param name="position">基準位置(マス中央)</param>
        /// <param name="blockOffset">ブロックの間隔</param>
        /// <param name="blockRange">最大何ブロック先まで届くか</param>
        public static void GetDirectionRange(out Vector3[] explosionPosition, Direction direction, Vector3 position, float blockOffset, int blockRange)
        {
            // 値を返す配列を作成
            explosionPosition = new Vector3[0];
            // Rayを使用するための方向を設定
            Vector3 directionVector = Vector3.zero;
            switch (direction)
            {
                case Direction.Up:
                    directionVector = Vector3.back;
                    break;
                case Direction.Down:
                    directionVector = Vector3.forward;
                    break;
                case Direction.Left:
                    directionVector = Vector3.right;
                    break;
                case Direction.Right:
                    directionVector = Vector3.left;
                    break;
                default:
                    break;
            }

            int arrayCount = 1;
            Vector3 basePosition = position;
            for (int i = 0; i < blockRange; ++i)
            {

                // 爆発判定(Rayから特定レイヤーのオブジェクトがあるかによって判断)
                int mask = 1 << 9;
                //LayerMask mask = LayerMask.NameToLayer("indestructible_block");
                float maxDistance = (i + 1) * blockOffset; // マスの中央までの距離

                if (Physics.Raycast(basePosition, directionVector, maxDistance, mask))
                {
                    Debug.Log("hit");

                    return;
                }
                else
                {
                    Debug.Log("not hit");
                    // 配列追加
                    System.Array.Resize(ref explosionPosition, arrayCount);
                    // position設定
                    Vector3 outPosition = basePosition;
                    switch (direction)
                    {
                        case Direction.Up:
                            // z-
                            outPosition.z -= maxDistance;
                            break;
                        case Direction.Down:
                            // z+
                            outPosition.z += maxDistance;
                            break;
                        case Direction.Left:
                            // x+
                            outPosition.x += maxDistance;
                            break;
                        case Direction.Right:
                            // x-
                            outPosition.x -= maxDistance;
                            break;
                        default:
                            break;
                    }
                    explosionPosition[arrayCount - 1] = outPosition;
                    ++arrayCount;
                }
            }
        }

        public static void GetRange(out Vector3[] upExplosionPosition, out Vector3[] downExplosionPosition, out Vector3[] leftExplosionPosition, out Vector3[] rightExplosionPosition, int upRange, int downRange, int leftRange, int rightRange, Vector3 position, float blockOffset)
        {

            GetDirectionRange(out upExplosionPosition, Direction.Up, position, blockOffset, upRange);
            GetDirectionRange(out downExplosionPosition, Direction.Down, position, blockOffset, downRange);
            GetDirectionRange(out leftExplosionPosition, Direction.Left, position, blockOffset, leftRange);
            GetDirectionRange(out rightExplosionPosition, Direction.Right, position, blockOffset, rightRange);
        }
    }
}