﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour {

    public GameObject explo;
    public GameObject cross;
    public static int score;
    public Text txt;

	// Use this for initialization
	void Start () {
        score = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.F) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Debug.Log("Fire");
            RaycastHit hit;

            if(Physics.Raycast(cross.transform.position,cross.transform.forward,out hit))
            {
                if(hit.transform.name== "Mon_00(Clone)")
                {
                    Debug.Log("Destory!");
                    Destroy(hit.transform.gameObject);
                    GameObject boom = Instantiate(explo, hit.point, Quaternion.LookRotation(hit.normal));
                    score++;
                    txt.text = score.ToString();
                }
            }
        }
	}

    
}