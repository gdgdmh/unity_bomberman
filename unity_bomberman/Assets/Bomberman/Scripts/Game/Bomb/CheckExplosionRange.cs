using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 爆発範囲をチェックする
/// </summary>
public class CheckExplosionRange {

	/// <summary>
	/// 方向
	/// </summary>
	public enum Direction {
		Up,
		Down,
		Left,
		Right
	};

	/// <summary>
	/// 指定した方向の爆発範囲を取得する
	/// </summary>
	/// <param name="explosionPosition">爆発範囲</param>
	/// <param name="direction">方向</param>
	/// <param name="range">爆発距離</param>
	/// <param name="position">基準位置</param>
	public static void GetDirectionRange(out Vector3[] explosionPosition, Direction direction, int range, Vector3 position) {
		explosionPosition = new Vector3[1]; // 仮
	}

	public static void GetRange(out Vector3[] upExplosionPosition, out Vector3[] downExplosionPosition, out Vector3[] leftExplosionPosition, out Vector3[] rightExplosionPosition, int upRange, int downRange, int leftRange, int rightRange, Vector3 position) {
		upExplosionPosition = new Vector3[1]; // 仮
		downExplosionPosition = new Vector3[1]; // 仮
		leftExplosionPosition = new Vector3[1]; // 仮
		rightExplosionPosition = new Vector3[1]; // 仮
	}
}
