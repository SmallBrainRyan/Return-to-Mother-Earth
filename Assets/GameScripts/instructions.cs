using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructions : MonoBehaviour
{
    public float time = 1;
    public float timeleft;

    private void Start()
    {
        timeleft = time;
    }
    
    private void Update()
    {
        timeleft-=1 * Time.deltaTime;

       if(timeleft <= 0)
        {
            Destroy(gameObject);
        }
    }
}
