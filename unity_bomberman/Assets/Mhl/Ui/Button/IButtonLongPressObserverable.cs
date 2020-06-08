using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mhl
{
    /// <summary>
    /// ボタン長押し通知インターフェース
    /// </summary>
    public interface IButtonLongPressObserverable
    {
        /// <summary>
        /// 長押しの開始
        /// </summary>
        /// <param name="eventData">押し始めのイベントパラメータ</param>
        void StartLongPress(PointerEventData eventData);

        /// <summary>
        /// 長押しの終了
        /// </summary>
        /// <param name="eventData">押し終わりのイベントパラメータ</param>
        void EndLongPress(PointerEventData eventData);

        /// <summary>
        /// 長押ししている時に呼ばれる
        /// </summary>
        void LongPress();
    }
}
