using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman
{
    public class Map001BlockPosition
    {
        public static readonly int Width = 13;
        public static readonly int Height = 13;
        public static readonly float BlockWidth = 2.0f;     // ブロックの横幅
        public static readonly float BlockHeight = 2.0f;    // ブロックの縦幅
        public static readonly float BlockHalfWidth = 1.0f;     // ブロックの横幅の半分
        public static readonly float BlockHalfHeight = 1.0f;    // ブロックの縦幅の半分

        private static readonly float A1_X = 12.0f;
        private static readonly float A1_Y = BlockHalfHeight;// ブロックの配置のために浮かせる(そのままだと半分地面にめり込む)
        private static readonly float A1_Z = -12.0f;

        public enum Position : int
        {
            A1,A2,A3,A4,A5,A6,A7,A8,A9,A10,A11,A12,A13, // 1段目
            B1,B2,B3,B4,B5,B6,B7,B8,B9,B10,B11,B12,B13, // 2段目
            C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12,C13,
            D1,D2,D3,D4,D5,D6,D7,D8,D9,D10,D11,D12,D13,
            E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11,E12,E13,
            F1,F2,F3,F4,F5,F6,F7,F8,F9,F10,F11,F12,F13,
            G1,G2,G3,G4,G5,G6,G7,G8,G9,G10,G11,G12,G13,
            H1,H2,H3,H4,H5,H6,H7,H8,H9,H10,H11,H12,H13,
            I1,I2,I3,I4,I5,I6,I7,I8,I9,I10,I11,I12,I13,
            J1,J2,J3,J4,J5,J6,J7,J8,J9,J10,J11,J12,J13,
            K1,K2,K3,K4,K5,K6,K7,K8,K9,K10,K11,K12,K13,
            L1,L2,L3,L4,L5,L6,L7,L8,L9,L10,L11,L12,L13,
            M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12,M13
        };

        /// <summary>
        /// Positionからブロックの中央座標へ変換
        /// </summary>
        /// <param name="position">対象Position</param>
        /// <returns>対象Positionの中央座標へ変換する</returns>
        public Vector3 ToVector3(Position position)
        {
            float x = A1_X - ((ToInt(position) % Width) * BlockWidth);
            float z = A1_Z + ((ToInt(position) / Width) * BlockHeight);
            return new Vector3(x, A1_Y, z);
        }

        // Positionをintに変換
        /// <summary>
        /// Positionからintに変換
        /// </summary>
        /// <param name="position">対象Position</param>
        /// <returns>intに変換されたPosition</returns>
        public int ToInt(Position position)
        {
            return (int)position;
        }

        /// <summary>
        /// intからPositionに変換
        /// intの値が範囲外の時はAugumentOutOfRangeExceptionをスロー
        /// </summary>
        /// <param name="position">対象int</param>
        /// <returns>Positionに変換されたint</returns>
        public Position ToPosition(int position)
        {
            if ((ToInt(Position.A1) <= position) && (position <= ToInt(Position.M13)))
            {
                // 範囲内であれば変換した値を返す
                return (Position)position;
            }
            throw new System.ArgumentOutOfRangeException("position out of range");
        }

        /// <summary>
        /// 3D座標から正規化したPositionを返す
        /// ピッタリの座標ではなく範囲で判断する
        /// </summary>
        /// <param name="vector3"></param>
        /// <returns></returns>
        public Position Normalize(Vector3 vector3)
        {
            Position[] positions = GetPositions();
            foreach (Position p in positions)
            {
                if (InBlockRange(ToVector3(p), vector3))
                {
                    return p;
                }
            }
            // どれかの座標に該当していないとおかしい
            UnityEngine.Assertions.Assert.IsFalse(true);
            return Position.A1;
        }

        /// <summary>
        /// 区画に入っているかどうか
        /// </summary>
        /// <param name="blockCenter">区画の中央座標</param>
        /// <param name="target">対象の座標(点)</param>
        /// <returns>trueなら区画に入っている</returns>
        public bool InBlockRange(Vector3 blockCenter, Vector3 target)
        {
            // 区画のボリュームを加味して入っているかチェック
            if (((blockCenter.x - BlockHalfWidth) <= target.x)
                && ((blockCenter.x + BlockHalfWidth) >= target.x)
                && ((blockCenter.y - BlockHalfWidth) <= target.y)
                && ((blockCenter.y + BlockHalfWidth) >= target.y))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 全ての座標を取得する
        /// </summary>
        /// <returns></returns>
        public Position[] GetPositions()
        {
            return new Position[] {
                Position.A1,Position.A2,Position.A3,Position.A4,Position.A5,Position.A6,Position.A7,Position.A8,Position.A9,Position.A10,Position.A11,Position.A12,Position.A13,
                Position.B1,Position.B2,Position.B3,Position.B4,Position.B5,Position.B6,Position.B7,Position.B8,Position.B9,Position.B10,Position.B11,Position.B12,Position.B13,
                Position.C1,Position.C2,Position.C3,Position.C4,Position.C5,Position.C6,Position.C7,Position.C8,Position.C9,Position.C10,Position.C11,Position.C12,Position.C13,
                Position.D1,Position.D2,Position.D3,Position.D4,Position.D5,Position.D6,Position.D7,Position.D8,Position.D9,Position.D10,Position.D11,Position.D12,Position.D13,
                Position.E1,Position.E2,Position.E3,Position.E4,Position.E5,Position.E6,Position.E7,Position.E8,Position.E9,Position.E10,Position.E11,Position.E12,Position.E13,
                Position.F1,Position.F2,Position.F3,Position.F4,Position.F5,Position.F6,Position.F7,Position.F8,Position.F9,Position.F10,Position.F11,Position.F12,Position.F13,
                Position.G1,Position.G2,Position.G3,Position.G4,Position.G5,Position.G6,Position.G7,Position.G8,Position.G9,Position.G10,Position.G11,Position.G12,Position.G13,
                Position.H1,Position.H2,Position.H3,Position.H4,Position.H5,Position.H6,Position.H7,Position.H8,Position.H9,Position.H10,Position.H11,Position.H12,Position.H13,
                Position.I1,Position.I2,Position.I3,Position.I4,Position.I5,Position.I6,Position.I7,Position.I8,Position.I9,Position.I10,Position.I11,Position.I12,Position.I13,
                Position.J1,Position.J2,Position.J3,Position.J4,Position.J5,Position.J6,Position.J7,Position.J8,Position.J9,Position.J10,Position.J11,Position.J12,Position.J13,
                Position.K1,Position.K2,Position.K3,Position.K4,Position.K5,Position.K6,Position.K7,Position.K8,Position.K9,Position.K10,Position.K11,Position.K12,Position.K13,
                Position.L1,Position.L2,Position.L3,Position.L4,Position.L5,Position.L6,Position.L7,Position.L8,Position.L9,Position.L10,Position.L11,Position.L12,Position.L13,
                Position.M1,Position.M2,Position.M3,Position.M4,Position.M5,Position.M6,Position.M7,Position.M8,Position.M9,Position.M10,Position.M11,Position.M12,Position.M13
            };
        }

    }
}
