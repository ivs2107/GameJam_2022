using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPlayerBulletActions : MonoBehaviour
{
    public static int nbLives;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            GameObject.Find("SoundEffectEnnemyPewpew").GetComponent<AudioSource>().Play();
        }
        catch
        {

        }
        StartCoroutine(WaitTillDie());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "enemyPlayer")
        {
            
            if (other.tag == "DumbAlly")
            {
                nbLives--;
                if (nbLives <= 0)
                {
                    try
                    {
                        GameObject.Find("SoundEffectExplosion").GetComponent<AudioSource>().Play();
                    }
                    catch
                    {

                    }
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
                }
                else
                {
                    
                    switch(nbLives)
                    {
                        
                        case 1:
                            GameObject cube1 = other.gameObject.transform.Find("cubeLife1").gameObject;
                            MeshRenderer mesh1 = cube1.GetComponent<MeshRenderer>();
                            
                            GameObject particle1 = cube1.gameObject.transform.Find("DeathPlayerParticle").gameObject;
                            particle1.transform.position = cube1.transform.position;
                            particle1.SetActive(true);
                            
                            mesh1.enabled = false;
                            break;
                        
                        case 2:
                            GameObject cube2 = other.gameObject.transform.Find("cubeLife2").gameObject;
                            MeshRenderer mesh2 = cube2.GetComponent<MeshRenderer>();

                            GameObject particle2 = cube2.gameObject.transform.Find("DeathPlayerParticle").gameObject;
                            particle2.transform.position = cube2.transform.position;
                            particle2.SetActive(true);

                            mesh2.enabled = false;
                            break;

                    }
                    
                    Destroy(this.gameObject);
                }
            }
        }
    }
    IEnumerator WaitTillDie()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
}
