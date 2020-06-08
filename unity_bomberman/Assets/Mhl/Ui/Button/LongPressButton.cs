using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mhl
{
    public class LongPressButton :
        MonoBehaviour,
        UnityEngine.EventSystems.IPointerDownHandler,
        UnityEngine.EventSystems.IPointerUpHandler
    {
        private Mhl.ButtonLongPressSubject longPressSubject = new Mhl.ButtonLongPressSubject();


        private void Update()
        {
            if (longPressSubject.Pushing)
            {
                longPressSubject.NotifyObserversLongPress();
            }
        }

        /// <summary>
        /// ポインタ押下イベント
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerDown(PointerEventData eventData)
        {
            longPressSubject.NotifyObserversStartLongPress(eventData);
        }

        /// <summary>
        /// ポインタ持ち上げイベント
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerUp(PointerEventData eventData)
        {
            longPressSubject.NotifyObserversEndLongPress(eventData);
        }

        /// <summary>
        /// オブザーバー登録
        /// </summary>
        /// <param name="observer"></param>
        public void AddLongPressObserver(Mhl.IButtonLongPressObserverable observer)
        {
            longPressSubject.Add(observer);
        }
    }
}
