using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour{

    public Game game;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        string tag = collision.gameObject.tag;
        if(tag == "Ground" ^ tag == "Player"){
            game.flyingObjectsCount++;

            if(game.flyingObjectsCount % 5 == 0)
                IncriseFallSpeed();
            print(game.fallSpeed);
            Destroy(gameObject);
        }
    }

    void IncriseFallSpeed(){
        game.fallSpeed -= 0.1f;
    }
}
