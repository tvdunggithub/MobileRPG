using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{

    [SerializeField]
    private Player _currentPlayer;
    [SerializeField]
    private Button dashButton;
    [SerializeField]
    private Button attackButton;
    [SerializeField]
    private Button spellButton;
    private Image dashImage;
    private Image spellImage;

    private void Awake() {
        dashImage = dashButton.GetComponent<Image>();
        spellImage = spellButton.GetComponent<Image>();
    }

    private void Start() 
    {
        dashButton.onClick.AddListener(Dash);
        spellButton.onClick.AddListener(SpellAttack);
        attackButton.onClick.AddListener(MeleeAttack);
    }

    private void OnDestroy() 
    {
        dashButton.onClick.RemoveListener(Dash);
        spellButton.onClick.RemoveListener(SpellAttack);
        attackButton.onClick.RemoveListener(MeleeAttack);
    }

    private void Update()
    {
        dashImage.fillAmount = _currentPlayer.DashCoolDown / _currentPlayer.PlayerData.DashCoolDown;
        spellImage.fillAmount = _currentPlayer.SpellCoolDown / _currentPlayer.PlayerData.SpellCooldown;
    }

    public void Dash()
    {
        if(_currentPlayer.CanDash)
            _currentPlayer.StateMachine.ChangeState(_currentPlayer.DashState);
    }

    public void MeleeAttack()
    {
        if(_currentPlayer.CanAttack)
        {
            _currentPlayer.StateMachine.ChangeState(_currentPlayer.AttackState);
        }
    }

    public void SpellAttack()
    {
        if(_currentPlayer.CanSpell)
        {
            _currentPlayer.CheckEnemyxPosInRange();
            _currentPlayer.ResetSpellCoolDown();
            _currentPlayer.FlipPlayerOnSpell();
            _currentPlayer.StateMachine.ChangeState(_currentPlayer.SpellState);
        }
    }
}
