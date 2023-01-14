using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerUI : MonoBehaviour
{
    [SerializeField] List<GameObject> Hammers;

    public int RestHammer;

    public void SetHammers(int hammerCount)
    {
        RestHammer = hammerCount;
        UpdateHammer();
    }

    public bool TryDecreaseHammer()
    {
        if (RestHammer <= 0) return false;
        RestHammer--;
        UpdateHammer();
        return true;
    }

    private void UpdateHammer()
    {
        foreach (var item in Hammers)
        {
            item.SetActive(false);
        }

        int count = 0;

        foreach (var item in Hammers)
        {
            if (RestHammer <= count) break;
            item.SetActive(true);
            count++;
        }
    }
}
