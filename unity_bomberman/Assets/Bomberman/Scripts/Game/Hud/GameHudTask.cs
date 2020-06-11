using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameHudTask : MonoBehaviour, Mhl.IButtonLongPressObserverable
{
    private static readonly string TouchUiLeftKeyObjectPath = "Canvas/UiLeft";
    private static readonly string TouchUiRightKeyObjectPath = "Canvas/UiRight";
    private static readonly string TouchUiUpKeyObjectPath = "Canvas/UiUp";
    private static readonly string TouchUiDownKeyObjectPath = "Canvas/UiDown";

    private static readonly int MoveLeft = 1;
    private static readonly int MoveRight = 2;
    private static readonly int MoveUp = 3;
    private static readonly int MoveDown = 4;
    private static readonly int KeyA = 10;

    // Start is called before the first frame update
    void Start()
    {
        // 長押しは標準ではできないのでオブザーバー登録して取得する
        // AボタンはUnity標準機能でOnClickに割り当て
        AddLongPressObserver(TouchUiLeftKeyObjectPath, MoveLeft);
        AddLongPressObserver(TouchUiRightKeyObjectPath, MoveRight);
        AddLongPressObserver(TouchUiUpKeyObjectPath, MoveUp);
        AddLongPressObserver(TouchUiDownKeyObjectPath, MoveDown);
    }

    /// <summary>
    /// 長押しのオブザーバー登録
    /// </summary>
    /// <param name="objectPath">長押し用のボタンスクリプトがあるオブジェクトのパス</param>
    /// <param name="parameter">オブザーバーイベント用の固有パラメーター</param>
    private void AddLongPressObserver(string objectPath, int parameter)
    {
        var g = transform.Find(objectPath);
        UnityEngine.Assertions.Assert.IsNotNull(g);
        var script = g.GetComponent<Mhl.LongPressButton>();
        script.AddLongPressObserver(this);
        script.SetObserverParameter(parameter);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick(int number)
    {
        if (number == KeyA)
        {
            Debug.Log("push A");
        }
    }

    /// <summary>
    /// 長押し開始
    /// </summary>
    /// <param name="eventData">タッチイベントデータ</param>
    /// <param name="parameter">登録時に割り当てられたパラメーター</param>
    public void StartLongPress(PointerEventData eventData, int parameter)
    {
        //Debug.Log("start" + parameter);
    }

    /// <summary>
    /// 長押し終了
    /// </summary>
    /// <param name="eventData">タッチイベントデータ</param>
    /// <param name="parameter">登録時に割り当てられたパラメーター</param>
    public void EndLongPress(PointerEventData eventData, int parameter)
    {
        //Debug.Log("end" + parameter);
    }

    /// <summary>
    /// 長押ししている時に呼ばれる
    /// </summary>
    /// <param name="parameter"></param>
    public void LongPress(int parameter)
    {
        if (parameter == MoveLeft)
        {
            Debug.Log("press Left");
        }
        if (parameter == MoveRight)
        {
            Debug.Log("press Right");
        }
        if (parameter == MoveUp)
        {
            Debug.Log("press Up");
        }
        if (parameter == MoveDown)
        {
            Debug.Log("press Down");
        }
    }
}
