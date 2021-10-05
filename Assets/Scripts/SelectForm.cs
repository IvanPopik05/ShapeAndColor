using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectForm : MonoBehaviour
{
    [SerializeField] private SpriteRenderer main_sprite;
    [Header("Data")]
    public DataFigure[] dataFigures;
    private DataFigure spriteData;

    private bool isActive = false;
    private List<Sprite> allSprites = new List<Sprite>();
    private Animator main_sprite_anim;

    LevelNext _levelNext;
    private int counter = 0;

    private void Awake()
    {
        main_sprite_anim = main_sprite.GetComponent<Animator>();
        _levelNext = GetComponent<LevelNext>();
    }
    private void Start()
    {
        Initialize();
    }

    private void SetDataFigure() 
    {
        spriteData = dataFigures[_levelNext.Level - 2];
    }
    private void SetNewSprite(SpriteRenderer sprite) 
    {
        sprite.sprite = RandomSprites(GetSprites());
        allSprites.Add(sprite.sprite);
    }
    private void Initialize() 
    {
        allSprites.Add(main_sprite.sprite);
        SetDataFigure();
        ChangeCards();
    }

    private void ChangeCards() 
    {
        StartCoroutine(CoroutineAnim());
    }
    private void ActiveAnim(bool isHide, bool isShow) 
    {
        main_sprite_anim.SetBool("Hide",isHide);
        main_sprite_anim.SetBool("Show",isShow);
    }
    private IEnumerator CoroutineAnim() 
    {
        ActiveAnim(true,false);
        yield return new WaitForSeconds(2);
        SetNewSprite(main_sprite);
        ActiveAnim(false,true);
    }
    private bool isSprite(int level) 
    {
        return allSprites[allSprites.Count - level] == main_sprite.sprite;
    }
    private void Won() 
    {
        Debug.Log("Вы угадали");
        counter++;
        if (counter >= 10) 
        {
            StartCoroutine(_levelNext.ShowLevelPanel(0,140));
            _levelNext.LevelNextMethod();
            main_sprite.color = _levelNext.GetColorWithText();
            counter = 0;
            SetDataFigure();
        }
        ChangeCards();
    }
    public void SelectBtn(int numberBtn) 
    {
        bool isEven;
        isEven = numberBtn == 1 ? true : false;
        isActive = !isActive;
        if (isSprite(_levelNext.Level) && isEven)
        {
            Won();
        }
        else if (!isSprite(_levelNext.Level) && !isEven)
        {
            Won();
        }
        else 
        {
            Debug.Log("Вы не угадали");
            Repeat();
        }

    }
    private void Repeat() 
    {
        Debug.Log("Повторите");
    }

    private Sprite[] GetSprites() 
    {
        return spriteData.sprites;
    }
    private Sprite RandomSprites(Sprite[] sprites) 
    {
        int randSprite = Random.Range(0,sprites.Length);
        return sprites[randSprite];
    }

}
