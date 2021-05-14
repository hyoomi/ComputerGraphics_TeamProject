using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//toystorytelling: back:floor에 적용
public class hitsound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //바닥에 부딪히는 소리
        if (jump.fall == true)
        {
            GameObject.Find("floor").GetComponent<AudioSource>().Play();
        }
    }
}
