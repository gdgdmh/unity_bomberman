using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy002 : MonoBehaviour
{
    // 移動
    private Rigidbody rigidBody;
    private Transform PlayerTransform;

    private static readonly float speed = 1.0f;

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
        // bottom
        rigidBody.velocity = new Vector3(0, 0, speed);
        // left
        //rigidBody.velocity = new Vector3(speed, 0, 0);
        // right
        //rigidBody.velocity = new Vector3(-speed, 0, 0);
        // top
        //rigidBody.velocity = new Vector3(0, 0, -speed);

        
    }
}
