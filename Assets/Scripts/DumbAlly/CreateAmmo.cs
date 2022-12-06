using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAmmo : MonoBehaviour
{
    private Rigidbody body;
    public GameObject pewpewPrefab;
    public string sceneName;
    private float currentSecondsPerShot, baseSecondsPerShot;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        baseSecondsPerShot = 0.8f;
        currentSecondsPerShot = baseSecondsPerShot;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentSecondsPerShot <= 0)
        {
            currentSecondsPerShot = baseSecondsPerShot;
            GameObject ammo = Instantiate(pewpewPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);

            ammo.transform.Find("Pewpew").GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-500, 0, 0));
        }
        else
        {
            currentSecondsPerShot -= Time.deltaTime;
        }
    }
}
