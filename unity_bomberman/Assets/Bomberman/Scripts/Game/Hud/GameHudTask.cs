using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameHudTask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick(int number)
    {
        Debug.Log(number);
    }

    public void OnPointerDown(PointerEventData data)
    {
    }

    public void OnPointerTest(UnityEngine.EventSystems.PointerEventData data)
    {
    }


    public void OnTest(UnityEngine.EventSystems.BaseEventData data)
    {
        Debug.Log("OnTest");
    }

    public void OnPointerDownUiLeft()
    {
        Debug.Log("Left");
    }

    public void OnPointerDownUiRight()
    {
    }

}
