using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitcherManager : MonoBehaviour
{
    [SerializeField]
    private List<SpriteSwitcher> _sprites;
    
    [SerializeField]
    private SpriteMode _mode;

    public void RegisterSpriteSwitcher(SpriteSwitcher switcher)
    {
        _sprites.Add(switcher);
    }

    public void SwitchSprite(SpriteMode mode)
    {
        foreach (SpriteSwitcher switcher in _sprites)
        {
            switcher.SwitchSprite(mode);
        }
        _mode = mode;
    }

    public void WinterMode() => SwitchSprite(SpriteMode.Winter);
    public void SummerMode() => SwitchSprite(SpriteMode.Summer);

    public void ToggleSpriteMode()
    {
        if (_mode == SpriteMode.Summer)
        {
            _mode = SpriteMode.Winter;
        }
        else
        {
            _mode = SpriteMode.Summer;
        }
        SwitchSprite(_mode);
    }

    
}
