using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームのメインシーンで行うタスク
/// </summary>
public class GameMainTask : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        //out Vector3[] explosionPosition, Direction direction, Vector3 position, Vector3 blockOffset, Vector3 explosionRange, int blockRange
		/*
        Vector3[] explosionPosition;
        CheckExplosionRange.Direction direction = CheckExplosionRange.Direction.Up;
        Vector3 position = new Vector3(0.0f, 0.0f, 0.0f);
        Vector3 blockOffset = new Vector3(2.0f, 2.0f, 2.0f); // ブロックの間隔は2
        Vector3 explosionRange = new Vector3(1.9f, 1.9f, 1.9f); // ぴったりだとギリギリ当たる可能性があるので-0.1する
        int blockRange = 2; // 2ブロック先まで届く
        CheckExplosionRange.GetDirectionRange(out explosionPosition, direction, position, blockOffset, explosionRange, blockRange);

		if (explosionPosition != null) {
			if (explosionPosition.Length == 0) {
                Debug.Log("pos empty");
			}
			foreach (Vector3 outPosition in explosionPosition) {
                Debug.Log(string.Format("pos x={0} y={1} z={2}", outPosition.x, outPosition.y, outPosition.z));
			}
		} else {
            Debug.Log("pos null");
		}
		*/

    }

    // Update is called once per frame
    void Update() {
		if (Input.GetKeyDown(UnityEngine.KeyCode.KeypadEnter)) {
            Vector3[] explosionPosition;
            CheckExplosionRange.Direction direction = CheckExplosionRange.Direction.Up;
            Vector3 position = new Vector3(0.0f, 0.0f, -10.0f);
            float blockOffset = 2.0f; // ブロックの間隔は2
            Vector3 explosionRange = new Vector3(1.9f, 1.9f, 1.9f); // ぴったりだとギリギリ当たる可能性があるので-0.1する
            int blockRange = 2; // 2ブロック先まで届く
            CheckExplosionRange.GetDirectionRange(out explosionPosition, direction, position, blockOffset, blockRange);

            if (explosionPosition != null) {
                if (explosionPosition.Length == 0) {
                    Debug.Log("pos empty");
                }
                foreach (Vector3 outPosition in explosionPosition) {
                    Debug.Log(string.Format("pos x={0} y={1} z={2}", outPosition.x, outPosition.y, outPosition.z));
                }
            } else {
                Debug.Log("pos null");
            }

        }
    }
}
