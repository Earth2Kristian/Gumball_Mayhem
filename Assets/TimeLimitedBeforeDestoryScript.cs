using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimitedBeforeDestoryScript : MonoBehaviour
{
    public float timeLimited = 10f;
  
    void Update()
    {
        timeLimited -= Time.deltaTime;

        if (timeLimited <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
