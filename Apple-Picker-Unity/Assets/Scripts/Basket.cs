using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{

    public ScoreCounter scoreCounter;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject otherObj = other.gameObject;
        if (otherObj.CompareTag("AppleTree"))
        {
            Destroy(otherObj);
            scoreCounter.score += 500;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
    }
}
