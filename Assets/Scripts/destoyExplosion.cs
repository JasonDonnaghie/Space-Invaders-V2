using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoyExplosion : MonoBehaviour
{
    public float timeWait;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeWait -= Time.deltaTime;
        if (timeWait <= 0){
            Destroy(gameObject);
        }
    }
}
