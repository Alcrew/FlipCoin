using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _orderText;
    [SerializeField] Image _betImage;
    [SerializeField] Image _cameUpImage;
    [SerializeField] Sprite _tailSprite;
    [SerializeField] Sprite _headSprite;

    public struct ItemData
    {
        public int random;
        public int coinValue;
    }

    public void Initialize(ItemData data, int index)
    {
        _orderText.SetText($"#{index}");
        _betImage.sprite = data.coinValue == 0 ? _tailSprite : _headSprite;
        _cameUpImage.sprite = data.random == 0 ? _tailSprite : _headSprite;

    }
}
