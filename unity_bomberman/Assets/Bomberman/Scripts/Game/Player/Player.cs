using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mhl.Input;

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

        /// <summary>
        /// 開始処理
        /// </summary>
        void Start()
        {
            // Componentを取得
            rigidBody = GetComponent<Rigidbody>();
            PlayerTransform = transform;
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
            // 爆弾を置く
            if (controller.IsButtonDown(GameController.Button.A))
            {
                Debug.Log("ButtonA");
                GameObject bomb = Resources.Load(BombPrefabPath) as GameObject;
                Vector3 position = PlayerTransform.position;
                position = BombPosition.Get(position);
                Instantiate(bomb, position, Quaternion.identity);
            }
        }

        /// <summary>
        /// 入力による移動処理
        /// </summary>
        private void MoveByInput()
        {
            // 移動の方向を取る
            MoveDirection moveDirection = MoveDirection.None;
            if (controller.IsPress(GameController.DirectionKey.RightUp))
            {
                moveDirection = MoveDirection.RightUp;
            }
            else if (controller.IsPress(GameController.DirectionKey.RightDown))
            {
                moveDirection = MoveDirection.RightDown;
            }
            else if (controller.IsPress(GameController.DirectionKey.LeftUp))
            {
                moveDirection = MoveDirection.LeftUp;
            }
            else if (controller.IsPress(GameController.DirectionKey.LeftDown))
            {
                moveDirection = MoveDirection.LeftDown;
            }
            else if (controller.IsPress(GameController.DirectionKey.Up))
            {
                moveDirection = MoveDirection.Up;
            }
            else if (controller.IsPress(GameController.DirectionKey.Left))
            {
                moveDirection = MoveDirection.Left;
            }
            else if (controller.IsPress(GameController.DirectionKey.Down))
            {
                moveDirection = MoveDirection.Down;
            }
            else if (controller.IsPress(GameController.DirectionKey.Right))
            {
                moveDirection = MoveDirection.Right;
            }
            // 方向に応じた移動をする
            MoveByMoveDirection(moveDirection);
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

        private float moveVelocity = 16.0f; // 移動速度

        // 移動
        private Rigidbody rigidBody;
        private Transform PlayerTransform;

        private GameController controller = new GameController();

        // memo
        // RigidBodyの設定で
        // Constraints
        //	FreezePosition Yのみチェック
        //	FreezeRotation X,Y,Z全てチェック
        // としておく。そうでないと物理演算で余計な回転などが効いてしまう
    }
}