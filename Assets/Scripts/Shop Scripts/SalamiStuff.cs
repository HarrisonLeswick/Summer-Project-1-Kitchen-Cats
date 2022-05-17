using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalamiStuff : MonoBehaviour
{
    public GameObject salamiPrefab;

    public float countdown;
    public void SpawnSalami()
    {
            GameObject newSalami = Instantiate(
                salamiPrefab,
                new Vector3(0, 0, 0),
                Quaternion.identity,
                transform);
            newSalami.name = "Salami";
            newSalami.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            newSalami.GetComponent<DragDropCanvas>().canvas = newSalami.transform.parent.transform.parent.GetComponent<Canvas>();
    }

    void Update()
    { 
    
    
    }


}
