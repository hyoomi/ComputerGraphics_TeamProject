using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//finishScene: Idle모델(우디)에 적용
public class finishWoody : MonoBehaviour
{
    private Animator ani;   //finishController
    private int going;  //시간의 경과를 카운트하는 변수
    private int angle;  //우디의 회전 각도
    public static bool turn; //우디가 회전할 때 true

    void Start()
    {
        //변수 초기화
        ani = gameObject.GetComponent<Animator>();
        going = 0;
        angle = 0;
        turn = false;

        //마지막칸 점프 모션
        ani.SetBool("jump", true);
        Invoke("jumpUp", 0.40f);
        Invoke("jumpUp", 0.43f);
        Invoke("jumpUp", 0.46f);
        Invoke("jumpUp", 0.49f);
        Invoke("jumpUp", 0.52f);
        Invoke("jumpUp", 0.55f);
        Invoke("jumpUp", 0.56f);

        Invoke("jumpFront", 0.42f);
        Invoke("jumpFront", 0.44f);
        Invoke("jumpFront", 0.46f);
        Invoke("jumpFront", 0.48f);
        Invoke("jumpFront", 0.50f);
        Invoke("jumpFront", 0.51f);
        Invoke("jumpFront", 0.52f);
        Invoke("jumpFront", 0.53f);
        Invoke("jumpFront", 0.54f);
        Invoke("jumpFront", 0.55f);
        Invoke("jumpFront", 0.56f);
        Invoke("jumpFront", 0.57f);
        Invoke("jumpFront", 0.58f);
        Invoke("jumpFront", 0.60f);
        Invoke("jumpFront", 0.61f);
        Invoke("jumpFront", 0.62f);
        Invoke("jumpFront", 0.63f);
        Invoke("jumpFront", 0.64f);
    }

    void jumpFront()    //+Z축 이동
    {
        transform.Translate(new Vector3(0, 0, 5));
    }

    void jumpUp()       //+Y축 이동
    {
        transform.position += Vector3.up * 5f;
    }

    void Update()
    {
        going++;
        //우디가 환호하는 모션
        if (going == 30)
        {
            ani.SetBool("jump", false);
            ani.SetBool("ending", true);
        }
        //우디가 180도 회전함
        else if(going > 100)
        {
            turn = true;
            if (angle < 90)
            {
                transform.Rotate(new Vector3(0, 2.0f, 0));
            }
            angle++;
        }
        
    }
}
