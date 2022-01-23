using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sarkac : MonoBehaviour
{
    float timer = 0f;
    float speed = 2f;
    int phase = 0;




   
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > 1f)
        {
            phase++;
            phase %= 4;
            timer = 0f;
        }

        switch (phase)
        {
            case 0:
                transform.Rotate(0f, 0f, speed * (1 - timer));  // first quarter
                break;
            case 1:
                transform.Rotate(0f, 0f, -speed * timer);       //second quarter
                break;
            case 2:
                transform.Rotate(0f, 0f, -speed * (1 - timer)); //thirt quarter
                break;
            case 3:
                transform.Rotate(0f, 0f, speed * timer);        //fourt quarter 
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("stacked"))
        {
            int index = CubeManager.cubeManagerInstanse.collactList.IndexOf(other.gameObject);
            for (; index < CubeManager.cubeManagerInstanse.collactList.Count; index++)
            {

                CubeManager.cubeManagerInstanse.collactList[index].transform.parent = null;

                CubeManager.cubeManagerInstanse.collactList.Remove(CubeManager.cubeManagerInstanse.collactList[index]);
                other.gameObject.tag = "collact";


            }
            Debug.Log("kaybet");
        }
    }


}
