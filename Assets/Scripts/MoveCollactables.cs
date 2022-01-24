using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveCollactables : MonoBehaviour
{
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
        if (other.CompareTag("money") || other.gameObject.CompareTag("gold") || other.gameObject.CompareTag("diamond"))
        {
            other.transform.DOMoveX(-10, 1f);
        }
    }
}
