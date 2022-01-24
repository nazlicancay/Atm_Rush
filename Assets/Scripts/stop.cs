using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class stop : MonoBehaviour
{
    GameObject playerObj;
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.gameManagerInstance.isGameActive = false;
           StartCoroutine(movePlayerUp(other.gameObject));
            playerObj.GetComponent<PlayerController>().animator.Play("idle");

            Debug.Log("player finish");


        }
    }

    private IEnumerator movePlayerUp(GameObject gameObject)
    {
        CameraManager.cameraManagerInstance.ActivateCamera(2);

        var wait = new WaitForSeconds(2f);
        yield return wait;
        gameObject.transform.DORotate(new Vector3(0,180,0), 1, 0);
        for (int i = 0; i <=GameManager.gameManagerInstance.CoinNumber; i++)
        {
            gameObject.transform.DOMoveY(GameManager.gameManagerInstance.CoinNumber + GameManager.gameManagerInstance.atmCoinNumber, 2f);
        }
       
        
        
       
        



    }


}
