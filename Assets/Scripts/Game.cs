using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour{

    // Reference On Fly Script
    public Fly fly;

    public GameObject coinObject;
    public GameObject lifeObject;

    public Text coinText;
    public Text lifeText;

    private float flyingObjectsCount = 0; 

    private float gr = -2.0f;
    private float minusGr = 2.0f;
    private float maxGravity = -100f; // max gravity
    private float objectsForGravityChange = 10; 
    private float maxObjectsForGravityChange = 100; // max objects count in one level
    private float objectsCountForEveryNextLevel = 10; // add X items in every new level
    private int coinMultiplier = 10; // coin * X

    float timer;

    private int life = 3;
    private int coins = 0;

    // will be launched every X second
    private float maxSpeed = 0.3f;
    private float minSpeed = 1f;

    void FixedUpdate () {
    
        timer += Time.deltaTime;
        if (timer > minSpeed) { 
            timer -= minSpeed;
            fly.CreateObjects();
            generateGravity();
        }
    }

    public void generateGravity(){
        flyingObjectsCount++;
        if(flyingObjectsCount % objectsForGravityChange == 0){ 

            if(objectsForGravityChange != maxObjectsForGravityChange){
                objectsForGravityChange += objectsCountForEveryNextLevel; // Add objects for every next level
                coinMultiplier += 10; // Increse coin multiplier
            }


            if(gr != maxGravity)
                gr -= minusGr;

            Physics2D.gravity = new Vector3(0f, gr ,0f); // Change gravity for more speed

            if(objectsForGravityChange % objectsCountForEveryNextLevel == 0 && minSpeed >= maxSpeed){
                minSpeed -= 0.05f; // change spawn time
            }
        }
    }

    public void IncreseLife(){
        if(life > 0){
            life--;

            if(life == 0)
                print("Game Over!"); // 

            lifeObject = GameObject.Find("lifeText");
            lifeText = lifeObject.GetComponent<Text>();
            lifeText.text = life.ToString() + " X";
        
        }
    }

    public void IncreseCoins(){
        coins += coinMultiplier;
        coinObject = GameObject.Find("coinText");
        coinText = coinObject.GetComponent<Text>();

        coinText.text = coins.ToString();
    }
}
