using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MhCommon {
	namespace System {
		namespace Input {
            public class GameController {

				public GameController() {
				}

				/// <summary>
				/// 方向キー
				/// </summary>
				public enum DirectionKey {
					Up,
					Down,
					Right,
					Left
				};

				/// <summary>
				/// ボタン
				/// </summary>
				public enum Button {
					A,
					B,
					X,
					Y
				};

				public void Update() {
				}

				/// <summary>
				/// 方向キーが押されたか
				/// </summary>
				/// <param name="key">対象の方向キー</param>
				/// <returns>対象の方向キーが押されている間trueが返される</returns>
				public bool IsPress(DirectionKey key) {
					KeyCode keyCode = ConvertDirectionKeyToUnityKeyCode(key);
					if (UnityEngine.Input.GetKey(keyCode)) {
						return true;
					}
					return false;
				}

				/// <summary>
				/// ボタンが押されたか
				/// </summary>
				/// <param name="button">対象のボタン</param>
				/// <returns>対象のボタンがtrueなら押されている</returns>
				public bool IsButtonDown(Button button) {
					KeyCode keyCode = ConvertButtonToUnityKeyCode(button);
					if (UnityEngine.Input.GetKeyDown(keyCode)) {
						return true;
					}
					return false;
				}

				/// <summary>
				/// ボタンが持ち上げられたか
				/// </summary>
				/// <param name="button">対象のボタン</param>
				/// <returns>trueなら持ち上げられた</returns>
				public bool IsButtonUp(Button button) {
					KeyCode keyCode = ConvertButtonToUnityKeyCode(button);
					if (UnityEngine.Input.GetKeyUp(keyCode)) {
						return true;
					}
					return false;
				}

				/// <summary>
				/// 方向キーからUnityのKeyCodeに変換
				/// </summary>
				/// <param name="key">対象の方向キー</param>
				/// <returns>UnityEngineのキーコード</returns>
				private KeyCode ConvertDirectionKeyToUnityKeyCode(DirectionKey key) {
					switch (key) {
						case DirectionKey.Up:
							return KeyCode.UpArrow;
						case DirectionKey.Down:
							return KeyCode.DownArrow;
						case DirectionKey.Right:
							return KeyCode.RightArrow;
						case DirectionKey.Left:
							return KeyCode.LeftArrow;
						default:
							return KeyCode.None;
					}
				}

				/// <summary>
				/// ボタンからUnityのKeyCodeに変換
				/// </summary>
				/// <param name="button">対象のボタン</param>
				/// <returns>UnityEngineのキーコード</returns>
				private KeyCode ConvertButtonToUnityKeyCode(Button button) {
					switch (button) {
						case Button.A:
							return KeyCode.Space;
							// A以外は今の所使用しないので割り当てなしとしています
							// 必要があれば割り当てをしてください
						case Button.B:
							return KeyCode.None;
						case Button.X:
							return KeyCode.None;
						case Button.Y:
							return KeyCode.None;
						default:
							return KeyCode.None;
					}
				}

            }
        }
    }
}
