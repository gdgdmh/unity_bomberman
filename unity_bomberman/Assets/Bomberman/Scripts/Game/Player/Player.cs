using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MhCommon.System.Input;

namespace Bomberman {
	public class Player : MonoBehaviour {
		/// <summary>
		/// 開始処理
		/// </summary>
		void Start() {
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
			if (controller.IsPress(GameController.DirectionKey.Up)) {
				Debug.Log("Up");
			} else if (controller.IsPress(GameController.DirectionKey.Left)) {
				Debug.Log("Left");
			} else if (controller.IsPress(GameController.DirectionKey.Down)) {
				Debug.Log("Down");
			} else if (controller.IsPress(GameController.DirectionKey.Right)) {
				Debug.Log("Right");
			}
		}

		GameController controller = new GameController();
	}
}