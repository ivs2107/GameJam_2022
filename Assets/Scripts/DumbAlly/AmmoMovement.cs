using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmmoMovement : MonoBehaviour
{
    public static int nbProtections;
    public static int collisionsToDie;
    public static bool killDone = false;
    public CameraShake cameraShake;
    private bool hasTouched;

    GameObject gEnnemy;


    public Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            GameObject.Find("SoundEffectPewpew").GetComponent<AudioSource>().Play();
        }
        catch
        {

        }
        StartCoroutine(WaitTillDie());
        hasTouched = false;
        body = GetComponent<Rigidbody>();
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        gEnnemy = GameObject.FindGameObjectWithTag("enemyPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(cameraShake.Shake(10f, 0.4f));
        if (hasTouched == true)
        {
            StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
            StartCoroutine(waitShaking());
        }
        //body.velocity = new Vector3(speed * Mathf.Cos(body.rotation.y / 180f * Mathf.PI), 0, speed * Mathf.Sin(body.rotation.y / 180f * Mathf.PI));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "DumbAlly")
        {

            if (other.tag == "enemyPlayer")
            {
                hasTouched = true;
                GameObject particle = this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).gameObject;
                particle.transform.position = this.transform.position;
                particle.SetActive(true);

                if (nbProtections <= 0)
                {
                    collisionsToDie--;
                    if (collisionsToDie <= 0)
                    {
                        try
                        {
                            GameObject.Find("SoundEffectDeath").GetComponent<AudioSource>().Play();
                        }
                        catch
                        {

                        }
                        //Destroy(other.gameObject);
                        killDone = true;
                        StartCoroutine(Waiter());
                        nbProtections = 1;
                        MeshRenderer meshRendererEnnemy = gEnnemy.GetComponent<MeshRenderer>();
                        meshRendererEnnemy.enabled = false;
                        gEnnemy.GetComponent<SphereCollider>().enabled = false;
                      //  gEnnemy.GetComponent<scr>
                    }
                    else
                    {
                        try
                        {
                            GameObject.Find("SoundEffectExplosion").GetComponent<AudioSource>().Play();
                        }
                        catch
                        {

                        }
                        //MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
                        // meshRenderer.enabled = false;
                    }
                }
                else
                {
                    try
                    {
                        GameObject.Find("SoundEffectShielded").GetComponent<AudioSource>().Play();
                    }
                    catch
                    {

                    }
                    //MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
                    // meshRenderer.enabled = false;
                }

                MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
                meshRenderer.enabled = false;
                this.GetComponent<BoxCollider>().enabled = false;

            }
            else if (other.tag == "ProtectBlock")
            {
                hasTouched = true;
                GameObject particle = this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).gameObject;
                particle.transform.position = this.transform.position;
                particle.SetActive(true);
                Destroy(other.gameObject);
                nbProtections--;
                hasTouched = true;

                MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
                meshRenderer.enabled = false;
                this.GetComponent<BoxCollider>().enabled = false;
                if (nbProtections <= 0)
                {
                    if (gEnnemy != null)
                    {
                        gEnnemy.transform.Find("Shield").gameObject.SetActive(false);
                    }
                }
                //Destroy()

            }
            else if (other.tag == "WallBlock")
            {
                hasTouched = true;
                GameObject particle = this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).gameObject;
                particle.transform.position = this.transform.position;
                particle.SetActive(true);
                MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
                meshRenderer.enabled = false;
                this.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
    IEnumerator Waiter()
    {
        collisionsToDie = 3;
        try
        {
            GameObject particle = gEnnemy.transform.Find("DeathParticle").gameObject;
            particle.SetActive(true);
        }
        catch
        {

        }
        
        //Wait for 2 seconds
        yield return new WaitForSeconds(2);
        killDone = false;
        //SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1, LoadSceneMode.Single);

    }
    IEnumerator WaitTillDie()
    {
        yield return new WaitForSeconds(10);
        if(killDone == false)
        {
            Destroy(this.gameObject);
        }

    }

    IEnumerator waitShaking()
    {
       
        yield return new WaitForSeconds(0.15f);
        hasTouched = false;

    }
}
