using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotWithRotation : MonoBehaviour
{
    private Rigidbody body;
    public GameObject ballBulletPrefab;
    public float frequency;
    private float currentSecondsPerShot, baseSecondsPerShot;
    private int force;
    private float rotation;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        baseSecondsPerShot = frequency;
        currentSecondsPerShot = baseSecondsPerShot;
        force = 500;
        rotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (AmmoMovement.killDone == false)
        {
            if (currentSecondsPerShot <= 0)
            {
                currentSecondsPerShot = baseSecondsPerShot;

                for (int i = 0; i <= 3; i++)
                {
                    GameObject ammo = Instantiate(ballBulletPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
                    ammo.transform.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(force * Mathf.Sin(rotation + i * Mathf.PI / 2), 0, force * Mathf.Cos(rotation + i * Mathf.PI / 2)));
                }
                rotation += Mathf.PI / 12f;

            }
            else
            {
                currentSecondsPerShot -= Time.deltaTime;
            }
        }
    }
}
