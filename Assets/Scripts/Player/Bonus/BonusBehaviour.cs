using UnityEngine;

public abstract class BonusBehaviour : MonoBehaviour, IBonusPickable
{
    public abstract BonusBase Pick (Player pickedBy);

    public void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.TryGetComponent(out Platform platform))
        {
            var player = platform.Player;
            player.BonusHandler.AddBonus(Pick(player));
            Destroy(gameObject);
        }
    }
}
