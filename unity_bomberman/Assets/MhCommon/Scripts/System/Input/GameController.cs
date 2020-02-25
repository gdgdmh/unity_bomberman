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
				/// <param name="key">方向キー</param>
				/// <returns>trueなら押されている</returns>
				public bool IsPress(DirectionKey key) {
					KeyCode keyCode = ConvertDirectionKeyToUnityKeyCode(key);
					if (UnityEngine.Input.GetKey(keyCode)) {
						return true;
					}
					return false;
				}

				/// <summary>
				/// 方向キーからUnityのKeyCodeに変換
				/// </summary>
				/// <param name="key">方向キー</param>
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

            }
        }
    }
}
