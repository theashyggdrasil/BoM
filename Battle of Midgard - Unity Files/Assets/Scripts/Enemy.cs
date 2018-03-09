using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    //initiate varialbes for enemy
    Rigidbody2D rb = new Rigidbody2D();
    float enemySpeed = 20.0f;
    Vector2 initialSpeed = new Vector2(30.0f, 0);
    float enemyHealth;
    float enemyAttack;
    float enemyDefense;
    float experienceGiven;
    
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        InitialMovement(initialSpeed);
        enemyHealth = 5;
	}
	
	// Update is called once per frame
	void Update () {
        EnemyDeath();
	}

    void InitialMovement(Vector2 speed)
    {
        rb.AddForce(speed);
    }

    void Movement(GameObject collisionObject, float speed)
    {
        rb.velocity = Vector2.zero;
        GameObject nextPoint;
        Vector3 nextPointPosition;
        
        //solve the last point creating an out of index error
        if (TurnPointManager.instance.turnPoints.IndexOf(collisionObject) != TurnPointManager.instance.turnPoints.Count - 1)
        {
            nextPoint = TurnPointManager.instance.turnPoints[TurnPointManager.instance.turnPoints.IndexOf(collisionObject) + 1];
            nextPointPosition = new Vector3(nextPoint.transform.position.x, nextPoint.transform.position.y);
            Vector3 currentPointPosition = new Vector3(collisionObject.transform.position.x, collisionObject.transform.position.y);
            Vector3 difference = nextPointPosition - currentPointPosition;
            
            if (TurnPointManager.instance.turnPoints.Contains(collisionObject))
            {
                rb.AddForce((nextPointPosition - currentPointPosition) * speed);
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "TurnPoints")
        {
            Movement(collision.gameObject, enemySpeed);
        }

        if (collision.tag == "Projectile")
        {
            enemyHealth--;
            collision.gameObject.SetActive(false);
            Debug.Log(enemyHealth);
        }
    }



    void EnemyDeath()
    {
        if(enemyHealth == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
