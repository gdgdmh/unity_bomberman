using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestTask : MonoBehaviour, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTestPointerDown2()
    {
        Debug.Log("down!!");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("pointerdown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("pointerup");
    }

    public void OnPointerDown2()
    {
        Debug.Log("pointerdown2");
    }

    public void OnPointerUp2()
    {
        Debug.Log("pointerup2");
    }

}
