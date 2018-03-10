using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public GameObject projectile, clone;
    public Vector3 shootLocation;
    private bool isShooting = false;
    public static PlayerManager instance = new PlayerManager();
    
	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update ()
    { 
		if(Input.GetMouseButtonDown(0) && !isShooting)
        {
            StartCoroutine(ProjectileSpawn());
        }
	}

    IEnumerator ProjectileSpawn()
    {
        //enter initial code
        shootLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        yield return new WaitForSeconds(0.1f);
        SpawnProjectile();
    }

    IEnumerator ProjectileCooldown()
    {
        //cooldown timer for the shooting of projectiles based on the player's speed
        isShooting = true;
        yield return new WaitForSeconds(2.0f); // change this based on player's speed
        isShooting = false;

    }

    void SpawnProjectile()
    {
        clone = Instantiate(projectile, gameObject.transform);
    }
}
