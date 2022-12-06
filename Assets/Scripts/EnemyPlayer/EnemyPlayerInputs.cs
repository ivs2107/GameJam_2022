using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerInputs : MonoBehaviour
{
    public Rigidbody body;
    private float speed;
    public int nbProtections;
    public int nbLives;
    private int nbPlayersLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        speed = 10;
        AmmoMovement.nbProtections = nbProtections;
        AmmoMovement.collisionsToDie = nbLives;
        EnemyPlayerBulletActions.nbLives = nbPlayersLives;
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxis("Horizontal");
        float directionZ = Input.GetAxis("Vertical");
        body.velocity = new Vector3(speed * directionX, 0, speed * directionZ);
    }
}
