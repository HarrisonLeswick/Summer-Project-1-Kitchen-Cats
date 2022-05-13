using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerStuff : MonoBehaviour
{
    public GameObject stickerPrefab;


    public void SpawnSticker()
    {
        GameObject newSticker = Instantiate(
            stickerPrefab,
            new Vector3(0, 0, 0),
            Quaternion.identity,
            transform);
        newSticker.name = "Sticker";
        newSticker.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        newSticker.GetComponent<DragDropCanvas>().canvas = newSticker.transform.parent.transform.parent.GetComponent<Canvas>();
    }
}
