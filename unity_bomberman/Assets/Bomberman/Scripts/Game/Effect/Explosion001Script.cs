﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion001Script : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

	/// <summary>
	/// パーティクルの再生終了時のCallback
	/// </summary>
	private void OnParticleSystemStopped() {
		Debug.Log("Explosion001Script OnParticleSystemStopped");
		// パーティクル終了後に消滅する
		Destroy(this.gameObject);
	}
}
