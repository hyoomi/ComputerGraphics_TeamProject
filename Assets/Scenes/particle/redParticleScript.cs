using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//finishScene: redParticle에 적용
public class redParticleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (finishCamera.camAngle > 1 && finishCamera.camAngle < 15 )
        {
            transform.Translate(new Vector3(0, 10, 0));
            
        }
        else if(finishCamera.camAngle == 15)
        {
            GetComponent<ParticleSystem>().Play();
        }
    }
}
