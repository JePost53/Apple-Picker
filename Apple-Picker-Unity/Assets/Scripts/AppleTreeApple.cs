using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTreeApple : MonoBehaviour
{
    public int direction; // -1 = left, 1 = right
    public float startSpeed;
    public float currentSpeed;
    public float accelerationFactor;
    public float changeDirChance;
    public float edgeDist;

    public float defaultDropTime;
    public float dropTime;
    public float timer;

    public GameObject appleAppleTree;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = startSpeed;
        dropTime = defaultDropTime;
        timer = dropTime;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UpdateVariables();
        SpawnAppleTree();
    }


    public void Move()
    {
        Vector3 pos = transform.position;
        pos.x += direction * currentSpeed * Time.deltaTime;
        transform.position = pos;

        if (Mathf.Abs(pos.x + direction * currentSpeed * Time.deltaTime) > edgeDist || Random.value < changeDirChance)
            direction *= -1;
    }

    public void SpawnAppleTree()
    {
        if (timer <= 0.0f)
        {
            GameObject treeClone = Instantiate(appleAppleTree);
            treeClone.transform.position = transform.position;

            timer = dropTime;
        }
    }

    public void UpdateVariables()
    {
        currentSpeed += accelerationFactor * Time.deltaTime;
        timer -= Time.deltaTime;
        dropTime -= dropTime * accelerationFactor * accelerationFactor * Time.deltaTime;
    }
}
