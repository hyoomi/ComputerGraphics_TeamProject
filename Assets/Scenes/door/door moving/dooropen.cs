using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//toystorytelling: door set에 적용
public class dooropen : MonoBehaviour {

	public static int angle=-1; //회전변환 하게하는 카운트변수. movearm.cs에서도 사용된다
	public float speed=3.0f;
	void Start()
 	   {
        		
 	   }

	void Update()
	{
		//문 열리는 event 제어
		if (jump.play == true)
		{
			if (jump.doing == true && jump.gameover == false && jump.fall == false) 
			{
				if (angle >= 0 && angle < 30 && movearm.ok == false)
				{

					transform.Rotate(new Vector3(0, 7.0f, 0)*speed);
					angle += 1;
				}
				else if (angle == 30)
				{
					transform.Translate(new Vector3(0, 0, 0));
					if (movearm.ok == true)
					{ angle -= 1; }
				}

				else if (movearm.ok == true && angle >= 0)
				{

					transform.Rotate(new Vector3(0, -7.0f, 0)*speed);
					angle -= 1;
				}
				else if (Random.Range(0, 100) == 0)
				{
					movearm.reverse = false;
					movearm.ok = false;
					angle = 0;
					movearm.times = 0;
					GameObject.Find("door set").GetComponent<AudioSource>().Play();	//문열리는 소리 재생
					//모두 초기화하면 다시 실행됨
					//타이밍 값 바꾸어주어 랜덤타이밍 안맞게 다시설정
				}
			}
		}//finish if(jump.play == true)
		
	}//finish Update
}
