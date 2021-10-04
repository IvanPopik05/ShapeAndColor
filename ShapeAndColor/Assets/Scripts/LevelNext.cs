using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNext : MonoBehaviour
{
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private Text showLevelText;
    [SerializeField] private Text meetLevelText;
    [SerializeField] int level = 2;
    [SerializeField] float timer;

    ColorScript _mainColor;

    public int Level 
    {
        get => level;
        private set => level = value;
    }
    private void Awake()
    {
        TextOutput();
        showLevelText.text = string.Empty;
        _mainColor = GetComponent<ColorScript>();
    }
    private void TextOutput() 
    {
        meetLevelText.text = $"Соответствует << {level - 1}";
        showLevelText.text = $"{level - 1} УРОВЕНЬ!";
    }
    public void LevelNextMethod() 
    {
        level++;
        TextOutput();
        Debug.Log("Вы перешли на новый уровень!");
    }
    public void GetLevelPanel() 
    {
        StartCoroutine(ShowLevelPanel(0,140));
    }
    public Color GetColorWithText() 
    {
        return showLevelText.color;
    }
    public IEnumerator ShowLevelPanel(float startSize,float endSize) 
    {
        Color startColor = Color.black;
        Color endColor = Color.clear;
        showLevelText.color = _mainColor.GetColor(); 
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            levelPanel.GetComponent<Image>().color = Color.Lerp(startColor,endColor,t);
            showLevelText.fontSize = (int)Mathf.Lerp(startSize,endSize,t);
            yield return new WaitForSeconds(timer);
        }
        showLevelText.fontSize = (int)startSize;
        showLevelText.text = string.Empty;
        Debug.Log("Новый Level");
    }
}
