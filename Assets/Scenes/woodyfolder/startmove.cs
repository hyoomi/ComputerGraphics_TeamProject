using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//startScene: Idle(우디)에 적용
public class startmove : MonoBehaviour
{
	private Animator ani;   //lookaroundController
    // Start is called before the first frame update
    void Start()
    {
        ani = gameObject.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //두리번거리는 모션
        if (cameramove.looking == true)
        {
            ani.SetBool("lookaround", true);
        }
        else
        {
            ani.SetBool("lookaround", false);
        }
    }
}
