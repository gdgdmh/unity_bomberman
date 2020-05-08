using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Mhl {

	public class SingleTouchActionPc : SingleTouchActionBase, ISingleTouchActionable {

		public SingleTouchActionPc() {
			Initialize();
		}

		public SingleTouchActionPc(int displayWidth, int displayHeight) {
			Initialize();
			this.displayWidth = displayWidth;
			this.displayHeight = displayHeight;
		}

		/// <summary>
		/// 初期化
		/// </summary>
		public override void Initialize() {
			base.Initialize();
		}

		/// <summary>
		/// 更新処理
		/// </summary>
		public override void Update() {
			SetTouchInfoPc();
		}

		void ISingleTouchActionable.SetDisplaySize(int width, int height) {
			SetDisplaySize(width, height);
		}

		/// <summary>
		/// タッチが全くされていない状態か
		/// </summary>
		/// <returns>タッチが全くされていない状態ならtrue</returns>
		bool ISingleTouchActionable.IsTouchNone() {
			Assert.IsNotNull(touchInfo);
			Assert.IsNotNull(touchInfo[kCurrentFrame]);
			if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kNone) {
				return true;
			}
			return false;
		}

		/// <summary>
		/// タッチが開始された状態か
		/// </summary>
		/// <returns>タッチが開始された状態ならtrue</returns>
		bool ISingleTouchActionable.IsTouchBegan() {
			Assert.IsNotNull(touchInfo);
			Assert.IsNotNull(touchInfo[kCurrentFrame]);
			if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kBegan) {
				return true;
			}
			return false;
		}

		/// <summary>
		/// タッチをし続けていて移動中か
		/// </summary>
		/// <returns>タッチをし続けていて移動中ならtrue</returns>
		bool ISingleTouchActionable.IsTouchMoved() {
			Assert.IsNotNull(touchInfo);
			Assert.IsNotNull(touchInfo[kCurrentFrame]);
			if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kMoved) {
				return true;
			}
			return false;
		}

		/// <summary>
		/// タッチをし続けていて移動していないか
		/// </summary>
		/// <returns>タッチをし続けていて移動していないならtrue</returns>
		bool ISingleTouchActionable.IsTouchStationary() {
			Assert.IsNotNull(touchInfo);
			Assert.IsNotNull(touchInfo[kCurrentFrame]);
			if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kStationary) {
				return true;
			}
			return false;
		}

		/// <summary>
		/// タッチが終了したか(タッチをして持ち上げた)
		/// </summary>
		/// <returns>タッチが終了したならtrue</returns>
		bool ISingleTouchActionable.IsTouchEnded() {
			Assert.IsNotNull(touchInfo);
			Assert.IsNotNull(touchInfo[kCurrentFrame]);
			if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kEnded) {
				return true;
			}
			return false;
		}

		/// <summary>
		/// タッチがキャンセルされたか(タッチをして何らかの理由でキャンセルされた)
		/// </summary>
		/// <returns>タッチがキャンセルされたならtrue</returns>
		bool ISingleTouchActionable.IsTouchCanceled() {
			Assert.IsNotNull(touchInfo);
			Assert.IsNotNull(touchInfo[kCurrentFrame]);
			if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kCanceled) {
				return true;
			}
			return false;
		}

		/// <summary>
		/// ドラッグ動作をしているか
		/// </summary>
		/// <returns><c>true</c>ドラッグ動作をしている<c>false</c>ドラッグ動作をしていない</returns>
		bool ISingleTouchActionable.IsDragging() {
			Assert.IsNotNull(touchInfo);
			Assert.IsNotNull(touchInfo[kCurrentFrame]);
			TouchInfo.TouchStatus status = touchInfo[kCurrentFrame].status;
			if ((status == TouchInfo.TouchStatus.kBegan) || (status == TouchInfo.TouchStatus.kMoved) || (status == TouchInfo.TouchStatus.kStationary)) {
				return true;
			} else {
				return false;
			}
		}

		/// <summary>
		/// アプリケーション上でのタッチ位置を取得する
		/// 必ずしもディスプレイサイズと同じではない
		/// </summary>
		/// <returns></returns>
		Vector3 ISingleTouchActionable.GetApplicationTouchPosition() {
			Assert.IsNotNull(touchInfo);
			Assert.IsNotNull(touchInfo[kCurrentFrame]);
			return GetTouchPosition(displayWidth, displayHeight, touchInfo[kCurrentFrame].position);
		}


		/// <summary>
		/// システムから取得できる無加工のタッチ位置を取得する
		/// </summary>
		/// <returns></returns>
		Vector3 ISingleTouchActionable.GetRawTouchPosition() {
			Assert.IsNotNull(touchInfo);
			Assert.IsNotNull(touchInfo[kCurrentFrame]);
			return touchInfo[kCurrentFrame].position;
		}

		/// <summary>
		/// 初期化
		/// </summary>
		void ISingleTouchActionable.Initialize() {
			Initialize();
		}

		/// <summary>
		/// 更新処理
		/// (毎フレーム処理する)
		/// </summary>
		void ISingleTouchActionable.Update() {
			Update();
		}

		/// <summary>
		/// データのリセットを行う
		/// シーン移動などで以前のデータが残らないようにする
		/// </summary>
		void ISingleTouchActionable.Reset() {
			Assert.IsNotNull(touchInfo);
			Assert.IsNotNull(touchInfo[kCurrentFrame]);
			Assert.IsNotNull(touchInfo[kBefore1Frame]);
			base.Reset();
		}

		/// <summary>
		/// デバッグ用データの出力
		/// </summary>
		void ISingleTouchActionable.Print() {
			Assert.IsNotNull(touchInfo);
			Assert.IsNotNull(touchInfo[kCurrentFrame]);
			touchInfo[kCurrentFrame].Print();
		}

		/// <summary>
		/// デバッグ用のデータ出力
		/// 前回のフレームからタッチ状態から異なっていたら出力
		/// </summary>
		void ISingleTouchActionable.PrintDifference() {
			Assert.IsNotNull(touchInfo);
			Assert.IsNotNull(touchInfo[kCurrentFrame]);
			Assert.IsNotNull(touchInfo[kBefore1Frame]);
			if (touchInfo[kCurrentFrame].Equals(touchInfo[kBefore1Frame]) == false) {
				touchInfo[kCurrentFrame].Print();
			}
		}
	}
}