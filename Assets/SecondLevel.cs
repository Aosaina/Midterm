using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondLevel : MonoBehaviour
{
    int trashNum = 3;
    bool cleaning = false;

    public AudioSource mySource;
    public AudioClip trashSound;
    public AudioClip npcSound;
    public AudioClip cleanSound;


    public GameObject npcWarn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

  
    void OnTriggerEnter2D(Collider2D other)
    {
        if (cleaning && other.gameObject.CompareTag("trash"))
        {
            mySource.PlayOneShot(trashSound);
            Destroy(other.gameObject);
            trashNum++;
            Debug.Log("you hit me!");
        }

        if(trashNum == 3)
        {
            cleaning = false;
        }

        if(other.gameObject.name == "greyS")
        {
            mySource.PlayOneShot(npcSound);
            npcWarn.SetActive(true);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "greyS")
        {
            npcWarn.SetActive(false);
        }


    }



    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.name == "cleanSpot" && Input.GetKeyDown(KeyCode.Space))
        {
            mySource.PlayOneShot(cleanSound);
            trashNum = 0;
            cleaning = true;
        }

    }
}