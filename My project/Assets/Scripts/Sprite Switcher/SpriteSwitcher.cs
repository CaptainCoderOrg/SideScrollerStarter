using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteSwitcher : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Sprite[] _sprites;
    [SerializeField]
    private SpriteMode _spriteMode;
    // Start is called before the first frame update
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SwitchSprite(SpriteMode mode)
    {
        _spriteMode = mode;
        _spriteRenderer.sprite = _sprites[(int)_spriteMode];
    }

    public void OnValidate()
    {
        // _spriteMode = _spriteMode % _sprites.Length;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _sprites[(int)_spriteMode];
    }

}
