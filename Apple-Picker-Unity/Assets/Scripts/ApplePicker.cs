using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{

    [Header("Inscribed")]
    public GameObject basketPrefab;
    public Transform basketParent;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;

    public List <GameObject> basketList;

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i=0; i<numBaskets; i++)
        {
            GameObject tBasketClone = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = basketParent.position;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketClone.transform.position = pos;
            tBasketClone.transform.SetParent(basketParent, true);

            basketList.Add(tBasketClone);
        }
    }

    public void AppleMissed()
    {
        int index = basketList.Count - 1;
        GameObject basket = basketList[index];
        basketList.RemoveAt(index);
        Destroy(basket);

        if (basketList.Count <= 0)
        {
            SceneManager.LoadScene("_Scene_0");
            return;
        }

        // Destroy ALL falling apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("AppleTree");
        foreach ( GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }
    }
}
