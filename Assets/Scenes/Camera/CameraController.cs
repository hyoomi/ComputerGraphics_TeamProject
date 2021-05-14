using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//toystorytelling:GameCamera에 적용
public class CameraController : MonoBehaviour
{

    GameObject player;  //우디 모델
    int timer;          //시간 경과를 체크하는 변수
    float posX;         //카메라의 x좌표
    float posZ;         //카메라의 y좌표
    private int angle;  //회전 각도를 조절하기 위한 변수
	public static bool retry;

    void Start()
    {
        //변수 초기화
        timer = 0;
        angle = 0;
        retry = false;
        this.player = GameObject.Find("Idle");
    }

    void delaygameover()
    {
        jump.play = false;
        jump.caught = false;    
        Invoke("gameoverdelay", 4.0f);
    }

    void gameoverdelay()
    {
        jump.gameover = true;
    }

    void Update()
    {
        Vector3 playerPos = this.player.transform.position;


        //movearm.cs에서 들키면 카메라 이동
        if (jump.caught == true)
        {
            Invoke("delaygameover", 1.4f);
            posX = playerPos.x - transform.position.x;
            posX += 200.0f;
            posZ = playerPos.z - transform.position.z;
            //카메라 회전
            if (timer < 10)
            {
                transform.Rotate(new Vector3(0, -1.0f, 0));
            }
            //카메라 이동
            else if (timer < 20)
            {
                transform.Translate(new Vector3(posX, 50.0f, posZ) * 0.1f);
            }
            //우디 회전
            else if (timer<60) //60
            {
                if (angle < 45 && timer > 30)
                {
                    this.player.transform.Rotate(new Vector3(0, -2.0f, 0));
		            angle++;
                }

            }
            timer++;
        }
        //카메라가 우디를 따라서 올라감
        else if (playerPos.y > 89 && timer == 0)
        {
            transform.position = new Vector3(
                transform.position.x, playerPos.y, transform.position.z);
        }
        
    }
}
