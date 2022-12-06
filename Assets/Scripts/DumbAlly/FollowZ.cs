using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowZ : MonoBehaviour
{
    GameObject gEnnemy;
    // Start is called before the first frame update
    void Start()
    {
        gEnnemy = GameObject.FindGameObjectWithTag("enemyPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        if (gEnnemy != null)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, gEnnemy.transform.position.z);
        }
    }
}
