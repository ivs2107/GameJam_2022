using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot4Directions : MonoBehaviour
{
    private Rigidbody body;
    public GameObject ballBulletPrefab;
    private float currentSecondsPerShot, baseSecondsPerShot;
    private int force;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        baseSecondsPerShot = 1f;
        currentSecondsPerShot = baseSecondsPerShot;
        force = 500;
    }

    // Update is called once per frame
    void Update()
    {
        if (AmmoMovement.killDone == false)
        {
            if (currentSecondsPerShot <= 0)
            {
                currentSecondsPerShot = baseSecondsPerShot;

                for (int i = -1; i <= 1; i += 2)
                {
                    for (int j = -1; j <= 1; j += 2)
                    {
                        GameObject ammo = Instantiate(ballBulletPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
                        ammo.transform.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(force * i, 0, force * j));
                    }
                }

            }
            else
            {
                currentSecondsPerShot -= Time.deltaTime;
            }
        }
    }
}