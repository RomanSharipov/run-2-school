using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Screen _punishmentPlayerScreen;
    [SerializeField] private Professor _professor;
    [SerializeField] private MapMovement _mapMovement;
    [SerializeField] private InscriptionOnReward _inscriptionOnReward;
    [SerializeField] private Canvas _canvas;

    private void OnEnable()
    {
        _professor.CatchedPlayer += OnStop;
        _player.Bag.AddedBook += ShowInscriptionOnReward;
    }

    private void OnDisable()
    {
        _professor.CatchedPlayer -= OnStop;
        _player.Bag.AddedBook -= ShowInscriptionOnReward;
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

    private void ShowInscriptionOnReward(Book book)
    {
        Instantiate(_inscriptionOnReward, _canvas.transform);
    }
}
