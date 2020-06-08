using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameHudTask : MonoBehaviour, Mhl.IButtonLongPressObserverable
{
    // Start is called before the first frame update
    void Start()
    {
        var g = transform.Find("Canvas/UiLeft");
        UnityEngine.Assertions.Assert.IsNotNull(g);
        var script = g.GetComponent<Mhl.LongPressButton>();
        script.AddLongPressObserver(this);
        script.SetObserverParameter(1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick(int number)
    {
        Debug.Log(number);
    }

    public void OnPointerDownUiRight()
    {
    }

    public void StartLongPress(PointerEventData eventData, int parameter)
    {
        Debug.Log("start" + parameter);
    }

    public void EndLongPress(PointerEventData eventData, int parameter)
    {
        Debug.Log("end" + parameter);
    }

    public void LongPress(int parameter)
    {
        Debug.Log("press" + parameter);
    }
}
