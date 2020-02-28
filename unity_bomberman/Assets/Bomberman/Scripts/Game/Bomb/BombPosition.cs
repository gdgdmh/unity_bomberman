using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// マス目に合うように爆弾の位置を調整する
/// </summary>
public static class BombPosition {

	/// <summary>
	/// 爆弾の設置位置を取得(調整)する
	/// </summary>
	/// <param name="position">基準位置</param>
	/// <returns>調整された爆弾の設置位置</returns>
	public static Vector3 Get(Vector3 position) {
		Vector3 adjustPosition = position;
		adjustPosition.x = AdjustPosition(position.x);
		adjustPosition.y = AdjustPosition(position.y);
		adjustPosition.z = AdjustPosition(position.z);
		return adjustPosition;
	}

	/// <summary>
	/// 位置調整(2の倍数になるように調整)
	/// </summary>
	/// <param name="position">位置</param>
	/// <returns>調整された位置</returns>
	private static float AdjustPosition(float position) {
		float adjustPosition = position;
		// 少数切り捨て
		adjustPosition = Mathf.Round(adjustPosition);
		// 2の倍数になるように調整
		if ((adjustPosition % 2) != 0) {
			adjustPosition = (adjustPosition + 1);
		}
		return adjustPosition;
	}

}
