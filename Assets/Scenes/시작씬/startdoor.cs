using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//startScene 1: door set에 적용
public class startdoor : MonoBehaviour
{

    void Update()
    {
        //문이 열린다
        if (cameramove.doormove == true)
        {
            transform.Rotate(new Vector3(0, 1.0f, 0) * 0.1f);
        }
    }
}
