using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondLevel : MonoBehaviour
{
    int trashNum = 0;
    bool cleaning = true;

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
            Destroy(other.gameObject);
            trashNum++;
            Debug.Log("you hit me!");
        }

        if(trashNum == 3)
        {
            cleaning = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.name == "cleanSpot" && Input.GetKeyDown(KeyCode.Space))
        {
            trashNum = 0;
            cleaning = true;
        }

    }
}