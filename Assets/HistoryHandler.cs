using System;
using System.Collections.Generic;
using UnityEngine;

public class HistoryHandler : MonoBehaviour
{
    [SerializeField] GameObject _itemPrefab;
    [SerializeField] RectTransform _itemContainer;

    public void AddHistory(ItemScript.ItemData data)
    {
        _historyData.Add(data);
    }

    private List<ItemScript.ItemData> _historyData = new List<ItemScript.ItemData>();

    public void Show()
    {
        var index = 0;

        foreach (var data in _historyData)
        {
            var obj = Instantiate(_itemPrefab, _itemContainer);
            var script = obj.GetComponent<ItemScript>();
            script.Initialize(data, index++);
        }
    }
}