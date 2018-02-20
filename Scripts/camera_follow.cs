using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour {

    public GameObject player;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MatchHeight();
	}

    void MatchHeight()
    {
        Vector3 pos = transform.position;

        Vector2 player_pos = player_controller.instance.getPlayerPos();
        pos.y = player_pos.y;
        pos.x = player_pos.x;
        pos.z = -10;
        transform.position = pos;
    }
}
