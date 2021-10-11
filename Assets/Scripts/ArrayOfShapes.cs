using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Прошу пояснить суть этого класса)

//#refactor
//Если данный класс нигде в сцене не используется, то лучше убрать MonoBehaviour. Мы ведь только данными пользуемся
public class ArrayOfShapes : MonoBehaviour
{
    public static List<Sprite> AllSprites { get; private set; } = new List<Sprite>();
    public static List<Color> AllColors { get; private set; } = new List<Color>();

    /* #refactor
     * Методы AddElements и RemoveElements
     * Название говорит о том, что добавится несколько элементов. Но по факту заносится только одно и удаляется только одно
     */
    public static void AddElements(SpriteRenderer main_sprite)
    {
        AllSprites.Add(main_sprite.sprite);
        AllColors.Add(main_sprite.color);
    }
    public static void RemoveElements()
    {
        AllSprites.RemoveAt(0);
        AllColors.RemoveAt(0);
    }
    public static bool IsSprite(int level, SpriteRenderer main_sprite)
    {
        return AllSprites[AllSprites.Count - level] == main_sprite.sprite;
    }
    public static bool IsColor(int level, SpriteRenderer main_sprite)
    {
        return AllColors[AllColors.Count - level] == main_sprite.color;
    }
}
