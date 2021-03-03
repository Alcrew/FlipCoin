/*using System;
using System.Collections.Generic;
using UnityEngine;

namespace NvutiSimulator
{
    public class HistoryManager : MonoBehaviour
    {
        [SerializeField] GameObject _itemPrefab;
        [SerializeField] RectTransform _itemContainer;

        // ох ни хух ))) давно я массивы руками не делал
        //private List<HistoryItem.ItemData> _historyData = new List<HistoryItem.ItemData> ();
        private List<HistoryItem> _pool = new List<HistoryItem> (); // нужна ссылка на сам скрипт в сцене а не данные

        HistoryItem GetItemFromPool()
        {
            foreach (var item in _pool)
            {
                // мы возвращаем неактивный обьек - то есть если он не используется!
                if (!item.gameObject.activeSelf)
                    return item;
            }

            // если же в пуле не нашлось обьекта создаем новый
            var obj = Instantiate(_itemPrefab, _itemContainer);
            var script = obj.GetComponent<HistoryItem>();
            _pool.Add(script);
            return script;
        }

        public void AddHistory(HistoryItem.ItemData data)
        {
            //_historyData.Add(data);
        }
        // это все
        void Show(HistoryItem.ItemData[] data)
        {
            // угу
            foreach (var d in data)
            {
                var script = GetItemFromPool();
                // но я забыл его включить когда мы его юзает
                script.gameObject.SetActive(true);
                script.Setup(d);
            }
        }
        // неа - не обязательно / все равно на код смотерть будут/ ну и если будет запускаться будет полюсом =))
        // разные бывают люди, попадались и такие))
        void RegenerateList()
        {
            // выключаем все итемы
            foreach (var data in _pool)
            {
                data.gameObject.SetActive(false);
            }

            var count = UnityEngine.Random.Range(5, 50);
            Debug.Log($"Count: {count}");
            var newList = new HistoryItem.ItemData[count];
            for (int i = 0; i < count; i++)
            {
                var data = new HistoryItem.ItemData()
                {
                    ItemName = $"Data - {i}"
                };
                newList[i] = data;
            }
            Show(newList);
        }

        private void Update()
        {
            // когда нажал кнопку P - это чисто для теста что бы быстро
            if (Input.GetKeyUp(KeyCode.P))
            {
                RegenerateList();
            }
        }
    }
}
*/