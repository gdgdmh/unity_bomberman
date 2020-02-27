using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MhCommon.System.Input;

namespace Bomberman {

	public class Player : MonoBehaviour {

		// 移動方向
		enum MoveDirection {
			None,
			Up,
			Down,
			Left,
			Right
		};

		/// <summary>
		/// 開始処理
		/// </summary>
		void Start() {
			// Componentを取得
			rigidBody = GetComponent<Rigidbody>();
			PlayerTransform = transform;
		}

		/// <summary>
		/// 更新処理
		/// </summary>
		void Update() {
			// 入力処理
			ProcessByInput();
		}

		/// <summary>
		/// 入力処理
		/// </summary>
		private void ProcessByInput() {
			MoveByInput();
		}

		/// <summary>
		/// 入力による移動処理
		/// </summary>
		private void MoveByInput() {
			controller.Update();
			// 移動の方向を取る
			MoveDirection moveDirection = MoveDirection.None;
			if (controller.IsPress(GameController.DirectionKey.Up)) {
				moveDirection = MoveDirection.Up;
			} else if (controller.IsPress(GameController.DirectionKey.Left)) {
				moveDirection = MoveDirection.Left;
			} else if (controller.IsPress(GameController.DirectionKey.Down)) {
				moveDirection = MoveDirection.Down;
			} else if (controller.IsPress(GameController.DirectionKey.Right)) {
				moveDirection = MoveDirection.Right;
			}
			// 方向に応じた移動をする
			MoveByMoveDirection(moveDirection);
		}

		private void MoveByMoveDirection(MoveDirection moveDirection) {

			Vector3 velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, rigidBody.velocity.z);
			// 方向によって移動速度を設定する
			switch (moveDirection) {
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