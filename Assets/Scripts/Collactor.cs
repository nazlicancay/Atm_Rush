using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Collactor : MonoBehaviour
{
    public GameObject _stackObj;
    public GameObject collactor;
    private GameObject lastItem;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fail"))
        {
            return;
        }
        if (other.gameObject.CompareTag("collact"))
        {
            other.gameObject.tag = "Untagged";

            if (CubeManager.cubeManagerInstanse.collactList.Count != 0)
            {
                lastItem = CubeManager.cubeManagerInstanse.collactList.Last();
            }

            CubeManager.cubeManagerInstanse.collactList.Add(other.gameObject);
            GameManager.gameManagerInstance.CoinNumber = CubeManager.cubeManagerInstanse.collactList.Count;

         
          
            _stackObj = other.gameObject;

            _stackObj.transform.position = new Vector3(CubeManager.cubeManagerInstanse.stackHolder.transform.position.x, _stackObj.transform.position.y, lastItem.transform.position.z + 1f);
            _stackObj.transform.parent = CubeManager.cubeManagerInstanse.stackHolder;

            _stackObj.AddComponent<Collactor>();
            StartCoroutine(CubeManager.cubeManagerInstanse.Bounce());
            other.gameObject.tag = "stacked";

        }
        
        





    }

   
}
    