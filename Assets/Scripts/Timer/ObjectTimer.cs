using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ObjectTimer : BaseTimerUI
{
    [SerializeField] private GameObject _heartPrefab;

    private List<GameObject> _currentObjects = new List<GameObject>();
    private HorizontalLayoutGroup _layoutGroup;

    protected override void OnInit()
    {
        for (var i = 0; i < _maxValue; i++)
        {
            GameObject heart = Instantiate(_heartPrefab, transform);
            _currentObjects.Add(heart);
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(gameObject.GetComponent<RectTransform>());
        _layoutGroup = GetComponent<HorizontalLayoutGroup>();
        _layoutGroup.enabled = false;
    }

    protected override void OnValueChange(float value)
    {
        
        int index = GetNumber(value);
        MakeGameObjectsActive(index, false);
    }

    private int GetNumber(float number)
    {
        int answer = 0;

        while (answer < number)
        {
            answer++;
        }

        return answer;
    }

    private void MakeGameObjectsActive(int count, bool isActive)
    {
        for (var i = 0; i < _currentObjects.Count; i++)
        {
            if (i < count)
                _currentObjects[i].SetActive(isActive == false);
            else
                _currentObjects[i].SetActive(isActive);
        }
    }
}
