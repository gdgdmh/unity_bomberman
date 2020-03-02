using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb001 : MonoBehaviour {

    private static readonly string ExplosionEffectPrefabPath = "Prefabs/Explosion001";
    private static readonly float PositionYOffset = 1;

    // Start is called before the first frame update
    void Start() {
        Debug.Log("Bomb001 Start");
		// 3秒後に爆発する
        StartCoroutine(ExecuteExplosion(3.0f));
    }

    // Update is called once per frame
    void Update() {        
    }

	/// <summary>
	/// 爆発処理
	/// </summary>
	/// <param name="waitTime">何秒後に爆発するか</param>
	/// <returns></returns>
	private IEnumerator ExecuteExplosion(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Explosion");
        Vector3 position = transform.position;
        position.y += PositionYOffset;
		// 爆発したら消滅
        Destroy(this.gameObject);
		// 爆発エフェクトを生成
        GameObject effect = Resources.Load(ExplosionEffectPrefabPath) as GameObject;
        Instantiate(effect, position, Quaternion.identity);
	}


}
