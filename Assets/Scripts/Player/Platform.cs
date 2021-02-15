using UnityEngine;
using System.Reflection;

public class Platform : MonoBehaviour
{
    [SerializeField] private Player _parentPlayer;
    [SerializeField] private Vector2 _clampValues = new Vector2(-8, 8);
    [SerializeField] private InputBehaviour _inputBehaviour;

    private float horizontalVelocity;
    public Player Player => _parentPlayer;

    public void Awake ()
    {
        _inputBehaviour.OnMouseWorldPosition += OnGetInput;
    }

    public void OnGetInput (Vector2 input)
    {
        horizontalVelocity = input.x;
    }

    public void FixedUpdate ()
    {
        transform.position = new Vector2(Mathf.Clamp(horizontalVelocity, _clampValues.x, _clampValues.y), transform.position.y);
    }
}