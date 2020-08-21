using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour{

    // Reference On Fly Script
    public Fly fly;

    private float flyingObjectsCount = 0; 

    private float gr = -2.0f;
    private float minusGr = 2.0f;
    private float maxGravity = -100f;
    private float objectsForGravityChange = 5;
    float timer;

    public float death = 0;
    private float coins = 0;

    // will be launched every X second
    public float maxSpeed;
    public float minSpeed;

    void FixedUpdate () {
    
        timer += Time.deltaTime;
        if (timer > minSpeed) { 
                timer -= minSpeed;
                fly.CreateObjects();
                flyingObjectsCount++;

                if(flyingObjectsCount % objectsForGravityChange == 0){
                    if(gr != maxGravity)
                        gr -= minusGr;
                    Physics2D.gravity = new Vector3(0f, gr ,0f);
                }
        }
    }

    public void IncreseDeath(){
        death++;
        print(death);
    }

    public void IncreseCoins(){
        coins++;
    }
}
