using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainCamera : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        Debug.Log("MainCamera Start");
		// 注視点設定
        transform.LookAt(LookPosition);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public Vector3 LookPosition;
}
