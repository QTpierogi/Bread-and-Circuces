using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public enum AbilityType
    {
        NO_ABILITY,
        INSTANT_ACTIVE,
        DOUBLE_ATTACK,
        SHIELD,
        PROVOCATION,
        REGENERATION_EACH_TURN,
        COUNTER_ATTACK

    }

    public string Name;
    public Sprite Logo;
    public int Attack, Defense, Manacost;
    public bool IsPlaced;

    public List<AbilityType> Abilities;

    public bool IsSpell;

    public bool IsAlive
    {
        get
        {
            return Defense > 0;
        }
    }
    public bool HasAbility
    {
        get
        {
            return Abilities.Count > 0;
        }
    }
    public bool IsProvocation
    {
        get
        {
            return Abilities.Exists(x => x == AbilityType.PROVOCATION);
        }
    }

    public int TimesDealedDamage;

    public Card(string name, string logoName, int attack, int defense, int manacost, AbilityType abilityType = 0)
    {
        Name = name;
        Logo = Resources.Load<Sprite>(logoName);
        Attack = attack;
        Defense = defense;
        Manacost = manacost;
        IsPlaced = false;

        Abilities = new List<AbilityType>();

        if (abilityType != 0)
            Abilities.Add(abilityType);

        TimesDealedDamage = 0;
    }

    public Card(Card card)
    {
        Name = card.Name;
        Logo = card.Logo;
        Attack = card.Attack;
        Defense = card.Defense;
        Manacost = card.Manacost;
        IsPlaced = false;

        Abilities = new List<AbilityType>(card.Abilities);

        TimesDealedDamage = 0;
    }

    public void GetDamage(int dmg)
    {
        Defense -= dmg;
    }

    public Card GetCopy()
    {
        return new Card(this);
    }
}

public class SpellCard : Card
{
    public enum SpellType
    {
        NO_SPELL,
        AOE_HEAL,
        HEAL_ALLY_CARD,
        AOE_DAMAGE,
        DAMAGE_TARGET,
        ARMOR,
        BUFF_CARD_DAMAGE,
        DEBUFF_CARD_DAMAGE,
        CANCEL
    }

    public enum TargetType
    {
        NO_TARGET,
        SELF,
        AOE_CARD_TARGET,
        ENEMY_CARD_TARGET,
        ALLY_CARD_TARGET
    }

    public enum CardDrow
    {
        No,
        Yes
    }

    public enum Movement
    {
        No,
        Yes
    }

    public enum ResetCard
    {
        No,
        Yes
    }

    public SpellType Spell;
    public TargetType SpellTarget;
    public int SpellValue;

    public SpellCard(string name, string logoPath, int manacost, SpellType spellType = 0,
                     int spellValue = 0, TargetType targetType = 0, CardDrow cardDrow = 0,
                     Movement movement = 0, ResetCard resetCard = 0) : base(name, logoPath, 0, 0, manacost)
    {
        IsSpell = true;

        Spell = spellType;
        SpellTarget = targetType;
        SpellValue = spellValue;
    }

    public SpellCard(SpellCard card) : base(card)
    {
        IsSpell = true;

        Spell = card.Spell;
        SpellTarget = card.SpellTarget;
        SpellValue = card.SpellValue;
    }

    public new SpellCard GetCopy()
    {
        return new SpellCard(this);
    }
}

public static class CardManager
{
    public static List<Card> AllCards = new List<Card>();
}

public class ManagerCard : MonoBehaviour
{
    public void Awake()
    {
        //"��������"
        CardManager.AllCards.Add(new SpellCard("������ ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.CANCEL, 0, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.No));// ������ �� ������������
        CardManager.AllCards.Add(new SpellCard("������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 3, SpellCard.TargetType.SELF, SpellCard.CardDrow.No, SpellCard.Movement.Yes, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 3, SpellCard.TargetType.SELF, SpellCard.CardDrow.No, SpellCard.Movement.Yes, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("�����������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 3, SpellCard.TargetType.SELF, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("�����������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 3, SpellCard.TargetType.SELF, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("����� � ������������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.Yes, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("����� � ������������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.Yes, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("�������� ���������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 5, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.Yes, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("���������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 4, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.Yes));
        CardManager.AllCards.Add(new SpellCard("���������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 4, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.Yes));
        CardManager.AllCards.Add(new SpellCard("���������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 3, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));//������������� ������������
        CardManager.AllCards.Add(new SpellCard("���������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 3, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));//������������� ������������
        CardManager.AllCards.Add(new SpellCard("����� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.Yes, SpellCard.Movement.Yes, SpellCard.ResetCard.No));//����� �������� ������������
        CardManager.AllCards.Add(new SpellCard("����� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.Yes, SpellCard.Movement.Yes, SpellCard.ResetCard.No));//����� �������� ������������
        CardManager.AllCards.Add(new SpellCard("����� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.Yes, SpellCard.Movement.Yes, SpellCard.ResetCard.No));//����� �������� ������������
        CardManager.AllCards.Add(new SpellCard("��� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 1, SpellCard.TargetType.SELF, SpellCard.CardDrow.Yes, SpellCard.Movement.Yes, SpellCard.ResetCard.No));//������ �� ������������
        CardManager.AllCards.Add(new SpellCard("��� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 1, SpellCard.TargetType.SELF, SpellCard.CardDrow.Yes, SpellCard.Movement.Yes, SpellCard.ResetCard.No));//������ �� ������������

        //"�������"

        CardManager.AllCards.Add(new SpellCard("Take it", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 1, SpellCard.TargetType.SELF, SpellCard.CardDrow.No, SpellCard.Movement.Yes, SpellCard.ResetCard.No));//����� �������� ������������
        CardManager.AllCards.Add(new SpellCard("Take it", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 1, SpellCard.TargetType.SELF, SpellCard.CardDrow.No, SpellCard.Movement.Yes, SpellCard.ResetCard.No));//����� �������� ������������
        CardManager.AllCards.Add(new SpellCard("�������� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 4, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.Yes, SpellCard.ResetCard.No));//������ �� ������������
        CardManager.AllCards.Add(new SpellCard("�������� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 4, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.Yes, SpellCard.ResetCard.No));//������ �� ������������
        CardManager.AllCards.Add(new SpellCard("����������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.Yes));//������ �� ������������
        CardManager.AllCards.Add(new SpellCard("����������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.Yes));//������ �� ������������
        CardManager.AllCards.Add(new SpellCard("Rip and tear", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 3, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.Yes));//������ �� ������������
        CardManager.AllCards.Add(new SpellCard("�������� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.No));//������ �� ������������
        CardManager.AllCards.Add(new SpellCard("�������� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 0, SpellCard.TargetType.SELF, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.Yes));// + ��������
        CardManager.AllCards.Add(new SpellCard("�������� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 0, SpellCard.TargetType.SELF, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.Yes));// + ��������
        CardManager.AllCards.Add(new SpellCard("����������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("����������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("���� �������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("���� �������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("���� �������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.No));

        //"���������"

        CardManager.AllCards.Add(new SpellCard("��������� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.NO_SPELL, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.Yes));//+��������
        CardManager.AllCards.Add(new SpellCard("��������� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.NO_SPELL, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.Yes));//+��������
        CardManager.AllCards.Add(new SpellCard("�������� �������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 5, SpellCard.TargetType.SELF, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 2, SpellCard.TargetType.SELF, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.No));//������ � ������ ����
        CardManager.AllCards.Add(new SpellCard("����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 2, SpellCard.TargetType.SELF, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.No));//������ � ������ ����
        CardManager.AllCards.Add(new SpellCard("����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 2, SpellCard.TargetType.SELF, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.No));//������ � ������ ����
        CardManager.AllCards.Add(new SpellCard("����������� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 1, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.No));//������ �� ������������ �����
        CardManager.AllCards.Add(new SpellCard("����������� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 1, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.No));//������ �� ������������ �����
        CardManager.AllCards.Add(new SpellCard("���� �������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 3, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("���� �������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 3, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("����������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 1, SpellCard.TargetType.SELF, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));// ������ �� ������������ �����
        CardManager.AllCards.Add(new SpellCard("����������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 1, SpellCard.TargetType.SELF, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));// ������ �� ������������ �����
        CardManager.AllCards.Add(new SpellCard("��������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 3, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("��������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 3, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));

        //������������� � ���� "��������"

        CardManager.AllCards.Add(new SpellCard("�����������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 3, SpellCard.TargetType.SELF, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("�����������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 3, SpellCard.TargetType.SELF, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 2, SpellCard.TargetType.SELF, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.No));//������ � ������ ����
        CardManager.AllCards.Add(new SpellCard("����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 2, SpellCard.TargetType.SELF, SpellCard.CardDrow.No, SpellCard.Movement.No, SpellCard.ResetCard.No));//������ � ������ ����
        CardManager.AllCards.Add(new SpellCard("���� ��-�� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 3, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("���� ��-�� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 3, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("����� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.Yes, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("����� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.Yes, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("����� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.Yes, SpellCard.ResetCard.No));
        CardManager.AllCards.Add(new SpellCard("����������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 1, SpellCard.TargetType.SELF, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));// ������ �� ������������ �����
        CardManager.AllCards.Add(new SpellCard("����������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.ARMOR, 1, SpellCard.TargetType.SELF, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));// ������ �� ������������ �����
        CardManager.AllCards.Add(new SpellCard("����� � ������������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.Yes, SpellCard.ResetCard.No));// ������ � �������������
        CardManager.AllCards.Add(new SpellCard("����� � ������������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 2, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.Yes, SpellCard.ResetCard.No));// ������ � �������������
        CardManager.AllCards.Add(new SpellCard("���������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 3, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));//������ �� ������������ �����
        CardManager.AllCards.Add(new SpellCard("���������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 3, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.Yes, SpellCard.Movement.No, SpellCard.ResetCard.No));//������ �� ������������ �����
        CardManager.AllCards.Add(new SpellCard("�������������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 4, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.Yes, SpellCard.ResetCard.No));//������������
        CardManager.AllCards.Add(new SpellCard("�������������", "Sprites/LogoCards/CHto-to", 1, SpellCard.SpellType.DAMAGE_TARGET, 4, SpellCard.TargetType.ENEMY_CARD_TARGET, SpellCard.CardDrow.No, SpellCard.Movement.Yes, SpellCard.ResetCard.No));//������������
    }
}
