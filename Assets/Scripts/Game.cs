using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour{

    public GameObject FlyPrehabs;
    public Transform Fly;

    public float fallSpeed = 2f; // Object Falling Speed
    public float flyingObjectsCount = 0; 

    private float timer = 0f;
    private float randomPosition;



    void Start(){
        
    }

    void Update(){
        Invoke("CreateFlyingObject", 2);
    }

    void CreateFlyingObject(){

        timer += Time.deltaTime;

        // Spawn a new block every second
        if (timer > fallSpeed) {
            GameObject flyingObject = Instantiate(FlyPrehabs , Fly.position , Quaternion.identity);
            SetMinAndMaxX();
            flyingObject.transform.position = new Vector3(randomPosition, Fly.position.y , 0);
            timer = 0f;
        }
    }

    void SetMinAndMaxX() {
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0));

        randomPosition =  Random.Range(-bounds.x + 0.3f , bounds.x - 0.3f);

	}
}
