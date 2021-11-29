using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Screen _punishmentPlayerScreen;
    [SerializeField] private Professor _professor;
    [SerializeField] private MapMovement _mapMovement;

    private void Start()
    {
        _professor.CatchedPlayer += OnStop;
    }

    private void OnDisable()
    {
        _professor.CatchedPlayer -= OnStop;
    }

    public void SpankPlayer()
    {
        _professor.PunishPlayer();
        _player.GiveAss();
    }

    private void OnStop()
    {
        _player.StopMoving();
        _player.ResetPosition();
        _mapMovement.Stop();
        _punishmentPlayerScreen.Open();
    }
}
