using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class Resize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResizeObj()
    {
        transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.2f).OnComplete(() => transform.DOScale(new Vector3(1f, 1f, 1f), 0.05f));

    }
}
