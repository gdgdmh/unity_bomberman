using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UiTask : MonoBehaviour, Mhl.IButtonLongPressObserverable
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

    List<bool> pressKeyList = null;
    List<bool> buttonDownList = null;

    // Start is called before the first frame update
    public void Start()
    {
        InitializeKeyList();
        InitializeButtonDownList();

        // 長押しは標準ではできないのでオブザーバー登録して取得する
        // AボタンはUnity標準機能でOnClickに割り当て
        AddLongPressObserver(TouchUiLeftKeyObjectPath, MoveLeft);
        AddLongPressObserver(TouchUiRightKeyObjectPath, MoveRight);
        AddLongPressObserver(TouchUiUpKeyObjectPath, MoveUp);
        AddLongPressObserver(TouchUiDownKeyObjectPath, MoveDown);
    }

    private void InitializeKeyList()
    {
        int size = System.Enum.GetValues(typeof(Mhl.GameControllerConstant.DirectionKey)).Length;
        pressKeyList = new List<bool>(size);
        for (int i = 0; i < size; ++i)
        {
            pressKeyList.Add(false);
        }
    }

    private void InitializeButtonDownList()
    {
        int size = System.Enum.GetValues(typeof(Mhl.GameControllerConstant.Button)).Length;
        buttonDownList = new List<bool>(size);
        for (int i = 0; i < size; ++i)
        {
            buttonDownList.Add(false);
        }
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
    public void Update()
    {
        buttonDownList[(int)Mhl.GameControllerConstant.Button.A] = false;
    }

    public void OnClick(int number)
    {
        if (number == KeyA)
        {
            Debug.Log("push A");
            buttonDownList[(int)Mhl.GameControllerConstant.Button.A] = true;
        }
    }

    /// <summary>
    /// 長押し開始
    /// </summary>
    /// <param name="eventData">タッチイベントデータ</param>
    /// <param name="parameter">登録時に割り当てられたパラメーター</param>
    public void StartLongPress(PointerEventData eventData, int parameter)
    {
        int index = GetParameterToDirectionKeyIndex(parameter);
        pressKeyList[index] = true;
    }

    /// <summary>
    /// 長押し終了
    /// </summary>
    /// <param name="eventData">タッチイベントデータ</param>
    /// <param name="parameter">登録時に割り当てられたパラメーター</param>
    public void EndLongPress(PointerEventData eventData, int parameter)
    {
        int index = GetParameterToDirectionKeyIndex(parameter);
        pressKeyList[index] = false;
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
            return;
        }
        if (parameter == MoveRight)
        {
            Debug.Log("press Right");
            return;
        }
        if (parameter == MoveUp)
        {
            Debug.Log("press Up");
            return;
        }
        if (parameter == MoveDown)
        {
            Debug.Log("press Down");
            return;
        }
    }

    public bool IsPress(Mhl.GameControllerConstant.DirectionKey key)
    {
        return pressKeyList[(int)key];
    }

    public bool IsButtonDown(Mhl.GameControllerConstant.Button button)
    {
        return buttonDownList[(int)button];
    }

    private int GetParameterToDirectionKeyIndex(int parameter)
    {
        if (parameter == MoveLeft)
        {
            return (int)Mhl.GameControllerConstant.DirectionKey.Left;
        }
        if (parameter == MoveRight)
        {
            return (int)Mhl.GameControllerConstant.DirectionKey.Right;
        }
        if (parameter == MoveUp)
        {
            return (int)Mhl.GameControllerConstant.DirectionKey.Up;
        }
        if (parameter == MoveDown)
        {
            return (int)Mhl.GameControllerConstant.DirectionKey.Down;
        }
        // 特定のDirectionKey以外は指定できない
        UnityEngine.Assertions.Assert.IsTrue(false);
        return 0;
    }
}
