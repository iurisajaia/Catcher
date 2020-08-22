using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour{
    
    public Game game;

    private Rigidbody2D rb;

    public float delay = 1f;

    private float randomPosition;


    void OnCollisionEnter2D(Collision2D collision){
        
        string tag = collision.gameObject.tag;

        game =  GameObject.FindObjectOfType<Game>();

        if(tag == "Ground")
            game.IncreseLife();
        else if(tag == "Player")
            game.IncreseCoins();
        

        Destroy(gameObject);
        
    }


    // Generate Prefab
    public void CreateObjects(){
        GameObject flyingObject = Instantiate(gameObject , gameObject.transform.position , Quaternion.identity);
        SetMinAndMaxX(); 
        flyingObject.transform.position = new Vector3(randomPosition, gameObject.transform.position.y , 0);
    }

    // Generate Random X - alignement
    void SetMinAndMaxX() {
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0));
        float width = GetComponent<SpriteRenderer>().bounds.size.x + 0.1f;
        randomPosition =  Random.Range(-bounds.x + width , bounds.x - width);
	}
}
