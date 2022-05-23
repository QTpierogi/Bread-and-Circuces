using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public Card Card;
    public CardInfoScript Info;
    public CardMovementScript Movement;
    public UnitInfo Unit;
    public UnitControl UnitControl;
    public GameManagerScript Game;
    private TurnManager turnManager;

    public int numberCard = 0; // for spell
    public bool IsPlayerCard;

    GameManagerScript gameManager;
    public void Init(Card card, bool isPlayerCard)
    {
        Card = card;
        gameManager = GameManagerScript.Instance;
        turnManager = FindObjectOfType<TurnManager>();
        IsPlayerCard = isPlayerCard;

        if (isPlayerCard)
            Info.ShowCardInfo();
    }

    public void OnCast()
    {
        numberCard += 1;

        if (IsPlayerCard)
        {
            gameManager.CurrentGame.Player.HandCards.Remove(this);
            gameManager.ReduceMana(true, Card.Manacost);
        }
        else
        {
            gameManager.CurrentGame.Enemy.HandCards.Remove(this);
            gameManager.ReduceMana(false, Card.Manacost);
            Info.ShowCardInfo();
        }

        Card.IsPlaced = true;
        Unit = turnManager.activeUnit.GetComponent<UnitInfo>();
        UnitControl = turnManager.activeUnit.GetComponent<UnitControl>();

        UseSpell(Card, Unit);
        UiController.Instance.UpdateMana();
    }

    public void UseSpell(Card card, UnitInfo unit)
    {
        unit.ChangeStance(card.EndStance);
        switch (card.FirstCardEff)
        {
            case Card.CardEffect.Damage://confirmed
                turnManager.AddAction(new Action(ActionType.Attack, card.SpellValue));
                break;

            case Card.CardEffect.DamagePlusMovement:// ������ ����� ����� ������ �����������, ����� �������� ��� ��������� � ����� �����
                {
                    turnManager.AddAction(new Action(ActionType.Attack, card.SpellValue));

                    turnManager.AddAction(new Action(ActionType.Push, card.SpellValue));
                }
                break;

            case Card.CardEffect.PlusDamageCard: // ����� �������� ��������� numberCard � ������ ����� ����(�� ���� � ��� �� �����)
                turnManager.AddAction(new Action(ActionType.Attack, card.SpellValue + numberCard));
                break;

            case Card.CardEffect.Defense:// confirmed
                unit.defence += card.SpellValue;
                break;

            case Card.CardEffect.CheckDefenseStance: // ����� ��������
                break;

            case Card.CardEffect.DefensePlusType:
                {
                    unit.defence += card.SpellValue;
                    if (unit.withShield)
                        unit.defence += 1;
                }
                break;

            case Card.CardEffect.Survived:
                unit.CheckForAlive();
                break;

            case Card.CardEffect.Movement:// confirmed
                turnManager.AddAction(new Action(ActionType.Push, card.SpellValue));
                break;
        }
        switch (card.FirstCardEffTwo)
        {
            case Card.CardEffect.Damage:// confirmed
                turnManager.AddAction(new Action(ActionType.Attack, card.SecondSpellValue));
                break;

            case Card.CardEffect.IfDamage:
                break;

            case Card.CardEffect.Movement:// confirmed
                turnManager.AddAction(new Action(ActionType.Push, card.SecondSpellValue));
                break;

            case Card.CardEffect.CardDrow:// confirmed
                turnManager.AddAction(new Action(ActionType.Draw, card.SecondSpellValue));
                break;

            case Card.CardEffect.AliveCardDrow:
                if (unit.CheckForAlive())
                    turnManager.AddAction(new Action(ActionType.Draw, card.SecondSpellValue));
                break;

            case Card.CardEffect.IfCardDrow:
                break;

            case Card.CardEffect.ResetCard:
                turnManager.AddAction(new Action(ActionType.DiscardOpponent, card.SecondSpellValue));
                break;

            case Card.CardEffect.ManaAdd:
                {
                    Game.CurrentGame.Player.SpellManapool();
                    UiController.Instance.UpdateMana();
                }
                break;

            case Card.CardEffect.Type:
                if (unit.withShield)
                    unit.defence += card.SecondSpellValue;
                break;

            case Card.CardEffect.Mechanics:
                break;

            case Card.CardEffect.No:
                break;
        }

        DiscardCard();
    }

    public void DiscardCard()
    {
        gameManager.CurrentGame.Player.DiscardPile.Add(this.Card);
        Movement.OnEndDrag(null);

        RemoveCardFromList(gameManager.CurrentGame.Player.HandCards);

        Destroy(gameObject);
       // LastCardCast(this.Card, Game.PlayerCardPanel);
    }
    void LastCardCast(Card card, Transform leftPanel)
    {
        GameObject cardLast = Instantiate(Game.CardPref, leftPanel, false);
        CardController cardLast1 = cardLast.GetComponent<CardController>();

        cardLast1.Init(card, leftPanel);
    }

    void RemoveCardFromList(List<CardController> list)
    {
        if (list.Exists(x => x == this))
            list.Remove(this);
    }
}