using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//finishScene: Camera에 적용
public class finishCamera : MonoBehaviour
{
    public static int camAngle;
    // Start is called before the first frame update
    void Start()
    {
        camAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (finishWoody.turn == true)
        {
            //카메라 회전
            if (camAngle < 15)
            {
                transform.Rotate(new Vector3(-2.0f, 0, 0));


            }
            //카메라 이동
            else if (camAngle < 75)
            {
                transform.Rotate(new Vector3(0, 2.0f, 0));
                transform.Translate(new Vector3(-8, -2, 1));
            }
            camAngle++;
        }
    }
}
