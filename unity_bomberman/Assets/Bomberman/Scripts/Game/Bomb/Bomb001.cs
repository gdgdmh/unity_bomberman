using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb001 : MonoBehaviour {

    private static readonly string ExplosionEffectPrefabPath = "Prefabs/Explosion001";
    private static readonly float PositionYOffset = 3;

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
        Vector3 position = transform.position;
        position.y += PositionYOffset;
		// 爆発したら消滅
        Destroy(this.gameObject);
        //Debug.Log(string.Format("Bomb001::ExecuteExplosion position x={0} y={1} z={2}", position.x, position.y, position.z));
        // 爆発エフェクトを生成
        CreateExplosionEffect(position, explosionRange);
	}

	private void CreateExplosionEffect(Vector3 basePosition, int range) {
		if (range == 0) {
			// 爆発距離0なら生成しない
            return;
		}
		// 爆心地
        CreateEffect(basePosition);
		if (range == 1) {
			// 爆発距離1なら爆心地のみ
            return;
		}

        int directionRange = range - 1;
		// up
		for (int i = 0; i < directionRange; ++i) {
            CreateEffect(new Vector3(
				basePosition.x,
				basePosition.y,
				basePosition.z + (i + 1) * -explosionXZOffset));
		}
		// down
		for (int i = 0; i < directionRange; ++i) {
			CreateEffect(new Vector3(
				basePosition.x,
				basePosition.y,
				basePosition.z + (i + 1) * explosionXZOffset));
		}
		// left
		for (int i = 0; i < directionRange; ++i) {
			CreateEffect(new Vector3(
				basePosition.x + (i + 1) * explosionXZOffset,
				basePosition.y,
				basePosition.z));
		}
		// right
		for (int i = 0; i < directionRange; ++i) {
			CreateEffect(new Vector3(
				basePosition.x + (i + 1) * -explosionXZOffset,
				basePosition.y,
				basePosition.z));
		}
	}

	/// <summary>
	/// 指定位置に爆発エフェクトを生成する
	/// </summary>
	/// <param name="position">エフェクト発生位置</param>
	private void CreateEffect(Vector3 position) {
        GameObject effect = Resources.Load(ExplosionEffectPrefabPath) as GameObject;
        Instantiate(effect, position, Quaternion.identity);
    }

    private int explosionRange = 3;			// 爆発範囲
    private float explosionXZOffset = 2.0f;	// 爆発エフェクトのオフセット(XZ共通)
}
