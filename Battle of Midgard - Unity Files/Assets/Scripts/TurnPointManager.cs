using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPointManager : MonoBehaviour {

    public List<GameObject> turnPoints = new List<GameObject>();
    public static TurnPointManager instance = new TurnPointManager();

    private void Awake()
    {
        instance = this;
        ListTurnPoints();
    }

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ListTurnPoints()
    {
        foreach (Transform child in transform)
        {
            turnPoints.Add(child.gameObject);
        }

       
    }
}
