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
			MoveDirection moveDirection = MoveDirection.None;
			if (controller.IsPress(GameController.DirectionKey.Up)) {
				Debug.Log("Up");
				moveDirection = MoveDirection.Up;
			} else if (controller.IsPress(GameController.DirectionKey.Left)) {
				Debug.Log("Left");
				moveDirection = MoveDirection.Left;
			} else if (controller.IsPress(GameController.DirectionKey.Down)) {
				Debug.Log("Down");
				moveDirection = MoveDirection.Down;
			} else if (controller.IsPress(GameController.DirectionKey.Right)) {
				Debug.Log("Right");
				moveDirection = MoveDirection.Right;
			}
			MoveByMoveDirection(moveDirection);
		}

		private void MoveByMoveDirection(MoveDirection moveDirection) {

			Vector3 velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, rigidBody.velocity.z);
			// 方向によって移動速度を設定する
			switch (moveDirection) {
				case MoveDirection.Up:
					velocity.z = -moveVelocity;
					//rigidBody.AddForceAtPosition(new Vector3(0, 0, -1), rigidBody.position);

					//PlayerTransform.rotation = Quaternion.Euler(0, 0, 0);
					break;
				case MoveDirection.Down:
					velocity.z = moveVelocity;
					//rigidBody.AddForceAtPosition(new Vector3(0, 0, 1), rigidBody.position);
					//PlayerTransform.rotation = Quaternion.Euler(0, 270, 0);
					break;
				case MoveDirection.Right:
					velocity.x = -moveVelocity;
					//rigidBody.AddForceAtPosition(new Vector3(-1, 0, 0), rigidBody.position);
					//PlayerTransform.rotation = Quaternion.Euler(0, 180, 0);
					break;
				case MoveDirection.Left:
					velocity.x = moveVelocity;
					//rigidBody.AddForceAtPosition(new Vector3(1, 0, 0), rigidBody.position);
					//PlayerTransform.rotation = Quaternion.Euler(0, 90, 0);
					break;
				default:
					// 方向入力なかったら止まる
					velocity.x = 0;
					velocity.y = 0;
					velocity.z = 0;
					//rigidBody.AddForceAtPosition(new Vector3(0, 0, 0), rigidBody.position);
					break;
			}
			// 適用
			rigidBody.velocity = velocity;
			//rigidBody.AddForceAtPosition(Vector3.forward, rigidBody.position)
			//rigidBody.MoveRotation(Quaternion.identity);
		}

		private float moveVelocity = 16.0f;

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