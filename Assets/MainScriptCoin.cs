using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class MainScriptCoin : MonoBehaviour
{
    public GameObject TCard = null;
    public List<int> cardsInt = Enumerable.Range(0, 53).ToList();
    public List<GameObject> handCards = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pullCard();
    }

    [ContextMenu("pullCard")]
    void pullCard()
    {
        int index = UnityEngine.Random.Range(0, cardsInt.Count);
        Debug.Log(index);
        handCards.Add(Instantiate(TCard));
        TCardScript t = handCards[handCards.Count - 1].GetComponent<TCardScript>();
        t.cardNo = index;
        t.Begin();
        cardsInt.RemoveAt(index);
        updateCenter();
    }

    private const float XGap = 0.315f;
    private const float TargetY = -0.385f;
    private const float TargetZ = 0f; // Assuming Z stays at 0, adjust if needed
    //[ContextMenu("updateCenter")] // Allows you to run it from the Inspector context menu
    public void updateCenter()
    {
        if (handCards == null || handCards.Count == 0)
        {
            Debug.LogWarning("Object list is empty!");
            return;
        }

        int count = handCards.Count;

        // 1. Calculate the starting X position so the whole group is centered at X = 0
        float totalWidth = (count - 1) * XGap;
        float startX = -totalWidth / 2f;

        // 2. Loop through and position each object
        for (int i = 0; i < count; i++)
        {
            if (handCards[i] == null) continue;

            // Calculate the specific X for this item
            float currentX = startX + (i * XGap);

            // Apply the new position (keeping Z at 0, or change to handCards[i].transform.position.z)
            handCards[i].transform.position = new Vector3(currentX, TargetY, TargetZ);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
