using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb001 : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        Debug.Log("Bomb001 Start");
		// 3秒後に消滅
        StartCoroutine(ExecuteExplosion(3.0f));
    }

    // Update is called once per frame
    void Update() {        
    }

	private IEnumerator ExecuteExplosion(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Explosion");
		// 爆発後消滅する
        Destroy(this.gameObject);
	}
}
