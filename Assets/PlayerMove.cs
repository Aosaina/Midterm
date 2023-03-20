using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float PlayerSpeed = 1f;

    bool havetrash = false;
    bool texton = false;
    bool secondLevel = false;
    int trashnum = 0;
    int trashNumTwo = 0;


    public GameObject npcText1;
    public GameObject npcText2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            newPos.y += PlayerSpeed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.S))
        {
            newPos.y -= PlayerSpeed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.A))
        {
            newPos.x -= PlayerSpeed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.D))
        {
            newPos.x += PlayerSpeed * Time.deltaTime;

        }
        transform.position = newPos;

        if (secondLevel && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("next!");
            SceneManager.LoadScene(1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "trash1")
        {
            Destroy(other.gameObject);
            trashnum++;
        }

       if (other.gameObject.name == "trash2")
        {
            Destroy(other.gameObject);
            trashnum++;
        }

        if (other.gameObject.name == "trash3")
        {
            Destroy(other.gameObject);
            trashnum++;
        }

        if(trashnum == 3)
        {
            havetrash = true;
            secondLevel = true;
        }

        if (havetrash && other.gameObject.name == "npc")
        {
            npcText1.SetActive(true);
            npcText2.SetActive(false);
        }
        else if (!havetrash && other.gameObject.name == "npc")
        {
            npcText2.SetActive(true);
            npcText1.SetActive(false);

        }



    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "npc")
        {
            npcText1.SetActive(false);
            npcText2.SetActive(false);
        }
    }


}
