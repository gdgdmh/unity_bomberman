using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy002 : MonoBehaviour
{
    // 移動
    private Rigidbody rigidBody;
    private Transform PlayerTransform;

    // Start is called before the first frame update
    void Start()
    {
        // Componentを取得
        rigidBody = GetComponent<Rigidbody>();
        PlayerTransform = transform;

    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector3(0, 0, 0.5f);
        
    }
}
