using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    public float dropDistance;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < dropDistance)
        {
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleMissed();
            Destroy(this.gameObject);
        }
    }
}
