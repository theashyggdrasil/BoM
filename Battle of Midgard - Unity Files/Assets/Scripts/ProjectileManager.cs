using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour {

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent < Rigidbody2D >();
    }
    // Use this for initialization
    void Start () {
        //Give projectile force based from player stats
		if(gameObject.activeSelf)
        {
            Vector3 _shootLocation = PlayerManager.instance.shootLocation;
            float playerSpeed = 50.0f; //change based on the player speed stat
            Debug.Log(GetComponentInParent<Transform>().position);
            Debug.Log(_shootLocation);
            rb.AddForce((_shootLocation - GetComponentInParent<Transform>().position) * playerSpeed);
        }
	}
	
	// Update is called once per frame
	void Update () {

	}
}
