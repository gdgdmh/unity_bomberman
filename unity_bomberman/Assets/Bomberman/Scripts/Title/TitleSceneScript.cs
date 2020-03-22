using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman {
    public class TitleSceneScript : MonoBehaviour {
        // Start is called before the first frame update
        void Start() {
        }

        // Update is called once per frame
        void Update() {
            if (IsTouch()) {
                // 画面がタッチされた
                Debug.Log("touched title");
            }
        }

        private bool IsTouch() {
            int touchCount = UnityEngine.Input.touchCount;
			for (int i = 0; i < touchCount; ++i) {
                Touch touch = UnityEngine.Input.GetTouch(i);
				if (touch.phase == TouchPhase.Ended) {
					// 実機のタッチ
                    return true;
				}
			}

            if (UnityEngine.Input.GetMouseButtonDown(0)) {
				// PCのタッチ
                return true;
            }
            return false;
        }
    }

}
