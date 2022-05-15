using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game
{
    //����� ��������� ������ � ������ ������ ����� � ����� ������(�� � ����)?
    //��� � ��������� ������� ���������� ����� ���������� ������ ������, � �� �������� ��� ������, ���� � ��
    //� ����� ������ ��������� � ���� ��������� ������?(����� � ��)
    public Player Player, Enemy;

    public List<Card> EnemyDeck, PlayerDeck, EnemyDiscardPile, PlayerDiscardPile;

    public Game()
    {
        EnemyDeck = GiveDeckCard();
        PlayerDeck = GiveDeckCard();
        EnemyDiscardPile = new List<Card>();
        PlayerDiscardPile = new List<Card>();

        Player = new Player();
        Enemy = new Player();
    }

    List<Card> GiveDeckCard()
    {
        List<Card> list = new List<Card>();

        for (int i = 0; i < 10; i++)
        {
            var card = CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)];

            if (card.IsSpell)
                list.Add(((SpellCard)card).GetCopy());
            else
                list.Add(card.GetCopy());
        }
        return list;
    }
}

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance;

    public Game CurrentGame;
    public Transform EnemyHand, PlayerHand;

    public GameObject CardPref;

    int Turn, TurnTime = 30;

    int StartHandSize = 6;

    public List<CardController> PlayerHandCards = new List<CardController>(),
                                PlayerFieldCards = new List<CardController>(),
                                EnemyFieldCards = new List<CardController>();

    public bool IsPlayerTurn
    {
        get
        {
            return Turn % 2 == 0;
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        Turn = 0;
        CurrentGame = new Game();

        GiveHandCards(CurrentGame.EnemyDeck, EnemyHand);
        GiveHandCards(CurrentGame.PlayerDeck, PlayerHand);

        UiController.Instance.StartGame();

        StartCoroutine(TurnFunc());
    }

    void GiveHandCards(List<Card> deck, Transform hand) //������� ������ ��������� ���� � ����
    {
        int i = 0;
        while (i++ < StartHandSize)
            GiveCardToHand(deck, hand);
    }

    void GiveCardToHand(List<Card> deck, Transform hand)
    {
        if (deck.Count == 0)
            return;
        //ReshufflDiscardPile(deck) - ����� ����������� ���������� �������, ��� ����������� ���� �� ������ ���������� � ������� ������

        CreateCardPref(deck[0], hand);

        deck.RemoveAt(0);
    }

    void ReshuffleDiscardPile(List<Card> deck)
    {
        var discard = new List<Card>();
        if (deck == CurrentGame.PlayerDeck)
            discard = CurrentGame.PlayerDiscardPile;
        else discard = CurrentGame.EnemyDiscardPile;  //������� ������ � ������ � ����� ������ ��� �� ����� �����
        deck.AddRange(discard);
        discard.Clear();
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            var value = deck[k];
            deck[k] = deck[n];
            deck[n] = value;
        }
    }

    void CreateCardPref(Card card, Transform hand)
    {
        GameObject cardFF = Instantiate(CardPref, hand, false);
        CardController cardC = cardFF.GetComponent<CardController>();

        cardC.Init(card, hand == PlayerHand);

        if (cardC.IsPlayerCard)
            PlayerHandCards.Add(cardC);
    }

    // � �������� ���� - ������ ������������ � ��� ���������, �.�. �� ������� ���� � ���� � ������� ��������� ������������,
    // � �������� ���� ����� �������� ���������� �� ���������� ��������� ������ �� ����, ������ ������������� "����� ����� � ������� ����"

    IEnumerator TurnFunc() // ���� ������� ������ ������� ������ �������� (������ ����� ������������)
    {
        TurnTime = 30;
        UiController.Instance.UpdateTurnTime(TurnTime);

        CheckCardsForManaAvaliability();

        if (IsPlayerTurn)
        {
            while (TurnTime-- > 0)
            {
                UiController.Instance.UpdateTurnTime(TurnTime);
                yield return new WaitForSeconds(1);
            }
        }
        else
        {
            while (TurnTime-- > 27)
            {
                UiController.Instance.UpdateTurnTime(TurnTime);
                yield return new WaitForSeconds(1);
            }
        }
        ChangeTurn();
    }

    public void ChangeTurn()
    {
        StopAllCoroutines();
        Turn++;

        UiController.Instance.DisableTurnBtn();

        if (IsPlayerTurn)
        {
            GiveNewCards();
            CurrentGame.Player.RestoreRoundMana();

            UiController.Instance.UpdateMana();
        }

        else
        {
            CurrentGame.Enemy.RestoreRoundMana();
        }

        StartCoroutine(TurnFunc());
    }

    void DrawFullHand(List<Card> deck, Transform hand) // ������ ������ ����� ����� �� ������ ���� ��������� ����� ���� �� 6 ����
    {
        int i = PlayerHandCards.Count;
        while (i++ < StartHandSize)
            GiveCardToHand(deck, hand);
    }

    void GiveNewCards()
    {
        GiveCardToHand(CurrentGame.EnemyDeck, EnemyHand);
        DrawFullHand(CurrentGame.PlayerDeck, PlayerHand);
    }


    public void ReduceMana(bool playerMana, int manacost)
    {
        if (playerMana)
            CurrentGame.Player.Mana -= manacost;
        else
            CurrentGame.Enemy.Mana -= manacost;

        UiController.Instance.UpdateMana();
    }

    public void CheckCardsForManaAvaliability()
    {
        foreach (var card in PlayerHandCards)
            card.Info.HiglightManaAvaliability(CurrentGame.Player.Mana);
    }

    /*public void HighlightTargets(CardController attacker, bool highlight)
    {
        List<CardController> targets = new List<CardController>();

        if (attacker.Card.IsSpell)
        {
            var spellCard = (SpellCard)attacker.Card;

            if (spellCard.SpellTarget == SpellCard.TargetType.NoTarget)
                targets = new List<CardController>();
            else if (spellCard.SpellTarget == SpellCard.TargetType.Ally)
                targets = PlayerFieldCards;
            else
                targets = EnemyFieldCards;
        }
        else
        {
            if (EnemyFieldCards.Exists(x => x.Card.IsProvocation))
                targets = EnemyFieldCards.FindAll(x => x.Card.IsProvocation);
            else
            {
                targets = EnemyFieldCards;
            }
        }

        foreach (var card in targets)
        {
            if (attacker.Card.IsSpell)
                card.Info.HighlightAsSpellTarget(highlight);
        }
    }*/
}
