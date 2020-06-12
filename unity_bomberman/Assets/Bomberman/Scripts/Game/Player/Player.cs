using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mhl;

namespace Bomberman
{
    public class Player : MonoBehaviour
    {
        // 移動方向
        enum MoveDirection
        {
            None,
            Up,
            Down,
            Left,
            Right,
            RightUp,
            RightDown,
            LeftUp,
            LeftDown
        };

        private static readonly string BombPrefabPath = "Prefabs/Bomb001";
        private float moveVelocity = 16.0f; // 移動速度

        // 移動
        private Rigidbody rigidBody;
        private Transform PlayerTransform;

        private Mhl.GameController controller = new Mhl.GameController();
        private UiTask uiTask = null;

        // memo
        // RigidBodyの設定で
        // Constraints
        //	FreezePosition Yのみチェック
        //	FreezeRotation X,Y,Z全てチェック
        // としておく。そうでないと物理演算で余計な回転などが効いてしまう

        /// <summary>
        /// 開始処理
        /// </summary>
        void Start()
        {
            // Componentを取得
            rigidBody = GetComponent<Rigidbody>();
            PlayerTransform = transform;

            {
                GameObject g = GameObject.Find("UI");
                UnityEngine.Assertions.Assert.IsNotNull(g);
                uiTask = g.GetComponent<UiTask>();
                UnityEngine.Assertions.Assert.IsNotNull(uiTask);
            }
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        void Update()
        {
            // 入力処理
            ProcessByInput();
        }

        /// <summary>
        /// 入力処理
        /// </summary>
        private void ProcessByInput()
        {
            // コントローラー処理更新
            controller.Update();
            // 移動処理
            MoveByInput();
            // 攻撃処理
            AttackByInput();
        }

        /// <summary>
        /// 入力による攻撃処理
        /// </summary>
        private void AttackByInput()
        {
            if (IsInputA())
            {
                // 爆弾を置く
                Debug.Log("ButtonA");
                GameObject bomb = Resources.Load(BombPrefabPath) as GameObject;
                Vector3 position = PlayerTransform.position;
                position = BombPosition.Get(position);
                Instantiate(bomb, position, Quaternion.identity);
                return;
            }
        }

        private bool IsInputA()
        {
            // タッチ入力
            UnityEngine.Assertions.Assert.IsNotNull(uiTask);
            if (uiTask.IsButtonDown(GameControllerConstant.Button.A))
            {
                return true;
            }
            // キー入力
            if (controller.IsButtonDown(GameControllerConstant.Button.A))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 入力による移動処理
        /// </summary>
        private void MoveByInput()
        {
            // 移動の方向を取る
            MoveDirection moveDirection = MoveDirection.None;

            // タッチ移動
            moveDirection = GetUiControllerMoveDirection();
            if (moveDirection != MoveDirection.None)
            {
                // 方向に応じた移動をする
                MoveByMoveDirection(moveDirection);
                return;
            }
            // キー入力移動
            moveDirection = GetControllerMoveDirection();
            // 方向に応じた移動をする
            MoveByMoveDirection(moveDirection);
        }

        private MoveDirection GetControllerMoveDirection()
        {
            if (controller.IsPress(GameControllerConstant.DirectionKey.RightUp))
            {
                return MoveDirection.RightUp;
            }
            if (controller.IsPress(GameControllerConstant.DirectionKey.RightDown))
            {
                return MoveDirection.RightDown;
            }
            if (controller.IsPress(GameControllerConstant.DirectionKey.LeftUp))
            {
                return MoveDirection.LeftUp;
            }
            if (controller.IsPress(GameControllerConstant.DirectionKey.LeftDown))
            {
                return MoveDirection.LeftDown;
            }
            if (controller.IsPress(GameControllerConstant.DirectionKey.Up))
            {
                return MoveDirection.Up;
            }
            if (controller.IsPress(GameControllerConstant.DirectionKey.Left))
            {
                return MoveDirection.Left;
            }
            if (controller.IsPress(GameControllerConstant.DirectionKey.Down))
            {
                return MoveDirection.Down;
            }
            if (controller.IsPress(GameControllerConstant.DirectionKey.Right))
            {
                return MoveDirection.Right;
            }
            return MoveDirection.None;
        }

        private MoveDirection GetUiControllerMoveDirection()
        {
            UnityEngine.Assertions.Assert.IsNotNull(uiTask);
            if (uiTask.IsPress(GameControllerConstant.DirectionKey.Left))
            {
                if (uiTask.IsPress(GameControllerConstant.DirectionKey.Up))
                {
                    return MoveDirection.LeftUp;
                }
                if (uiTask.IsPress(GameControllerConstant.DirectionKey.Down))
                {
                    return MoveDirection.LeftDown;
                }
                return MoveDirection.Left;
            }
            if (uiTask.IsPress(GameControllerConstant.DirectionKey.Right))
            {
                if (uiTask.IsPress(GameControllerConstant.DirectionKey.Up))
                {
                    return MoveDirection.RightUp;
                }
                if (uiTask.IsPress(GameControllerConstant.DirectionKey.Down))
                {
                    return MoveDirection.RightDown;
                }
                return MoveDirection.Right;
            }
            if (uiTask.IsPress(GameControllerConstant.DirectionKey.Up))
            {
                return MoveDirection.Up;
            }
            if (uiTask.IsPress(GameControllerConstant.DirectionKey.Down))
            {
                return MoveDirection.Down;
            }
            return MoveDirection.None;
        }

        private void MoveByMoveDirection(MoveDirection moveDirection)
        {
            Vector3 velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, rigidBody.velocity.z);
            // 方向によって移動速度を設定する
            switch (moveDirection)
            {
                case MoveDirection.Up:
                    velocity.z = -moveVelocity;
                    PlayerTransform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case MoveDirection.Down:
                    velocity.z = moveVelocity;
                    PlayerTransform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                case MoveDirection.Right:
                    velocity.x = -moveVelocity;
                    PlayerTransform.rotation = Quaternion.Euler(0, 90, 0);
                    break;
                case MoveDirection.Left:
                    velocity.x = moveVelocity;
                    PlayerTransform.rotation = Quaternion.Euler(0, 270, 0);
                    break;
                case MoveDirection.RightUp:
                    velocity.x = -moveVelocity;
                    velocity.z = -moveVelocity;
                    PlayerTransform.rotation = Quaternion.Euler(0, 45, 0);
                    break;
                case MoveDirection.RightDown:
                    velocity.x = -moveVelocity;
                    velocity.z = moveVelocity;
                    PlayerTransform.rotation = Quaternion.Euler(0, 135, 0);
                    break;
                case MoveDirection.LeftUp:
                    velocity.x = moveVelocity;
                    velocity.z = -moveVelocity;
                    PlayerTransform.rotation = Quaternion.Euler(0, 315, 0);
                    break;
                case MoveDirection.LeftDown:
                    velocity.x = moveVelocity;
                    velocity.z = moveVelocity;
                    PlayerTransform.rotation = Quaternion.Euler(0, 225, 0);
                    break;

                default:
                    // 方向入力なかったら止まる
                    velocity.x = 0;
                    velocity.y = 0;
                    velocity.z = 0;
                    break;
            }
            // 適用
            rigidBody.velocity = velocity;
        }

    }
}