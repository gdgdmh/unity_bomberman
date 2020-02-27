using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb001 : MonoBehaviour {

    public static readonly string ExplosionEffectPrefabPath = "Prefabs/Explosion001";

    // Start is called before the first frame update
    void Start() {
        Debug.Log("Bomb001 Start");
        StartCoroutine(ExecuteExplosion(3.0f));
    }

    // Update is called once per frame
    void Update() {        
    }

	private IEnumerator ExecuteExplosion(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Explosion");
		// 爆発したら消滅
        Destroy(this.gameObject);
		// 爆発エフェクトを生成
        GameObject effect = Resources.Load(ExplosionEffectPrefabPath) as GameObject;
        Instantiate(effect, new Vector3(0, 0, 0), Quaternion.identity);
	}


}
