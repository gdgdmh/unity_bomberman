﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mhl
{
    /// <summary>
    /// ボタン長押しサブジェクトクラス
    /// </summary>
    public class ButtonLongPressSubject : Mhl.GenericSubject<Mhl.IButtonLongPressObserverable>
    {
        private bool isPushing = false;

        public bool Pushing
        {
            get { return isPushing; }
        }

        /// <summary>
        /// 長押し開始通知
        /// </summary>
        /// <param name="eventData">押し始めのイベントパラメータ</param>
        public void NotifyObserversStartLongPress(PointerEventData eventData)
        {
            isPushing = true;
            foreach (var observer in observers)
            {
                observer.StartLongPress(eventData);
            }
            ExecuteRequestRemove();
        }

        /// <summary>
        /// 押し終わり通知
        /// </summary>
        /// <param name="eventData">押し終わりのイベントパラメータ</param>
        public void NotifyObserversEndLongPress(PointerEventData eventData)
        {
            isPushing = false;
            foreach (var observer in observers)
            {
                observer.EndLongPress(eventData);
            }
            ExecuteRequestRemove();
        }

        /// <summary>
        /// 長押し通知
        /// 長押ししている時に呼ばれる
        /// </summary>
        public void NotifyObserversLongPress()
        {
            foreach (var observer in observers)
            {
                observer.LongPress();
            }
            ExecuteRequestRemove();
        }
    }
}
