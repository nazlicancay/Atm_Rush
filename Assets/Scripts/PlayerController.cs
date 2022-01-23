using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    

    public Animator animator;
    public float rotateMultiplier;
    public float swipeSpeed;
    public float maxLeftX;
    public float maxRightX;

    public float speed;


  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManagerInstance.isGameActive)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 13f);

            animator.Play("run");

        }

        if (transform.position.y ==
            GameManager.gameManagerInstance.CoinNumber + GameManager.gameManagerInstance.atmCoinNumber)
        {
            ShowScore();
        }

        void Update()
        {
            if (GameManager.gameManagerInstance.isGameActive)
            {
                if (transform.rotation != Quaternion.identity)
                {
                    transform.rotation =
                        Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * speed);
                }


            }


        }

    }
    
    public void RotateCharacter(Vector2 position)
    {
        position = position.normalized;
        Quaternion rotation = Quaternion.AngleAxis(position.x * rotateMultiplier, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 2);
    }


    public void InputUpdate(Vector2 delta)
    {
        if (GameManager.gameManagerInstance.isGameActive)
        {
            Vector3 newPos = transform.position + new Vector3(delta.x * swipeSpeed* Time.deltaTime, 0, 0);
            newPos.x = Mathf.Clamp(newPos.x, maxRightX, maxLeftX);
            transform.position = newPos;

        }



    }

    public void ShowScore()
    {
       
        UıManager.uıManagerInstance.RestartCanvas.gameObject.SetActive(true);
        UıManager.uıManagerInstance.scoretext.text = ((GameManager.gameManagerInstance.CoinNumber + GameManager.gameManagerInstance.atmCoinNumber).ToString());
        

    }




}
