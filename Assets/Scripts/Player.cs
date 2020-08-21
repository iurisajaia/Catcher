using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    private float horizontal = 0.0f;
    public float speed;

    private Rigidbody2D _rigidBody2D;

    void Start(){
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        PlayerMove();
    }

    void PlayerMove(){
        horizontal = Input.GetAxis("Horizontal");
        _rigidBody2D.velocity = new Vector2(speed * horizontal , _rigidBody2D.velocity.y);
    }

}
