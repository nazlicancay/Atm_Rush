using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class MoveCreditCart : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 2;
    public bool moveLeft;
    public bool moveRight;

    void Start()
    {
        moveLeft = true;
        moveRight = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= -4)
            {
                moveLeft = false;
                moveRight = true;
            }
        }
        if(moveRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x > 3.6)
            {
                moveRight = false;
                moveLeft = true;
            }
                
            
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
                CubeManager.cubeManagerInstanse.collactList[index].gameObject.tag = "Untagged";


                CubeManager.cubeManagerInstanse.collactList.Remove(CubeManager.cubeManagerInstanse.collactList[index]);


            }
            Debug.Log(index);
            Debug.Log("kaybet");
        }
    }
}
