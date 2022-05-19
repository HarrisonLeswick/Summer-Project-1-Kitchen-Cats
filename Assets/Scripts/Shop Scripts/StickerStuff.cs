using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerStuff : MonoBehaviour
{
    public GameObject[] stickerPrefabs;
    public bool allStickersUsed = false;
    
    private int selectedSticker;
    private int stickerbookRange; //total number of stickers - number of stickers spawned
    

    void Start()
    {
        stickerbookRange = stickerPrefabs.Length;
    }






    public void PickSticker()
    {
        selectedSticker = Random.Range(0, stickerbookRange);
        SpawnSticker();
        stickerbookRange--;
        SwapSticker(selectedSticker, stickerbookRange);

        if(stickerbookRange == 0)
        {
            allStickersUsed = true;
        }
    }

    public void SpawnSticker()
    {
        GameObject newSticker = Instantiate(
            stickerPrefabs[selectedSticker],
            new Vector3(0, 0, 0),
            Quaternion.identity,
            transform);
        newSticker.name = "Sticker";
        newSticker.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        newSticker.GetComponent<DragDropCanvas>().canvas = newSticker.transform.parent.transform.parent.GetComponent<Canvas>();
    }

    private void SwapSticker(int a, int b)
    {
        GameObject hold = stickerPrefabs[a];
        stickerPrefabs[a] = stickerPrefabs[b];
        stickerPrefabs[b] = hold;
    }
}
