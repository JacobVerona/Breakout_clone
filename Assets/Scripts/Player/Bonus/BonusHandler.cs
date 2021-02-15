using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BonusHandler
{
    private Player _player;
    private List<BonusBase> _bonuses;

    public BonusHandler (Player player)
    {
        _player = player;
        _bonuses = new List<BonusBase>();
    }

    public void AddBonus (BonusBase bonus)
    {
        _bonuses.Add(bonus);
        bonus.Init();

        var coroutine = WaitDurationCoroutine(bonus);
        _player.StartCoroutine(coroutine);
    }
    
    public void RemoveBonus (BonusBase bonus)
    {
        _bonuses.Remove(bonus);
        bonus.UnInit();
    }

    private IEnumerator WaitDurationCoroutine (BonusBase bonus)
    {
        var time = new WaitForSeconds(bonus.Duration);

        yield return time;

        RemoveBonus(bonus);
    }
}
