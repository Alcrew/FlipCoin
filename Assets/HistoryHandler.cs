using System;
using System.Collections.Generic;
using UnityEngine;

public class HistoryHandler : MonoBehaviour
{
    [SerializeField] GameObject _itemPrefab;
    [SerializeField] RectTransform _itemContainer;
    private int index = 1;
    private List<ItemScript.ItemData> _historyData = new List<ItemScript.ItemData>();

    public void AddHistory(ItemScript.ItemData data)
    {
        _historyData.Add(data);
    }

    public void Show()
    {
        CleanUp();
        foreach (var data in _historyData)
        {
            var idx = index++;
            var obj = Instantiate(_itemPrefab, _itemContainer);
            var script = obj.GetComponent<ItemScript>();
            script.Initialize(data, idx);
        }
    }

    private void CleanUp()
    {
        index = 1;
        foreach (Transform item in _itemContainer)
        {
            Destroy(item.gameObject);
        }
    }
}