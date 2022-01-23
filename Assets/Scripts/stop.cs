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
        var wait = new WaitForSeconds(2f);
        yield return wait;
        gameObject.transform.DOMoveY(GameManager.gameManagerInstance.CoinNumber + GameManager.gameManagerInstance.atmCoinNumber, 0.5f);
        //for(int i =0; i<)
        
        
       
        



    }


}
