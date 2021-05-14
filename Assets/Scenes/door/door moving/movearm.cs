using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//toystorytelling: arms1fbx에 적용
public class movearm : MonoBehaviour
{
     public static bool ok=false; 
    public static int times=-1;  //시간 조절
    public static bool reverse=false; //손을 뻗을때 false, 손이 돌아올때 true
    //위 변수 세개는 dooropen.cs에서 사용된다
    public float speed=1.5f;        //손이 움직이는 거리를 조절

    void Update()
    {
      //손내밀기 event 제어
        if (jump.play == true)
        {
            //start 손을 뻗는다
             if (times < 30 && times >= 0 && reverse == false && dooropen.angle == 30)
             {
                transform.Translate(new Vector3(15, 0, 60)*speed);
                times += 1;
            
                if (jump.checkDown == false)        //우디 들켰다!
                {
                   jump.caught = true;
                   jump.play = false;	
	               GameObject.Find("arms1fbx").GetComponent<AudioSource> ().Play(); //oh may god 효과음 재생
                }
             }//finish 손을 뻗는다

             //start 손이 도착했다
             else if (times == 30)
             {
                reverse = true;
                times -= 1;
                transform.Translate(new Vector3(0, 0, 0));
             } //finish 손이 도착했다

             //start 손이 돌아온다
             else if (times < 30 && dooropen.angle == 30 && times >= 0)
             {

                transform.Translate(new Vector3(-15, 0, -60)*speed);
                times -= 1;
                // 우디 들켰다!
                if (jump.checkDown == false)
                {
                   jump.caught = true;
                   jump.play = false;	
	               GameObject.Find("arms1fbx").GetComponent<AudioSource> ().Play();
                }

                if (times == -1)
                {
                   ok = true;
                }

                else
                {
                   transform.Translate(new Vector3(0, 0, 0));
                }
             }//finish 손이 돌아온다
      }//finish if(jump.play == ture)
   }//finish Update()
}
