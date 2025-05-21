using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
public class RaiseEvents : MonoBehaviourPun
{
    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }
    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    }
    private void NetworkingClient_EventReceived(EventData obj)
    {
        /*---血量---*/
        if (obj.Code == 0)
        {
            object[] datas = (object[])obj.CustomData;
            //試試看寫Player tag陣列的那個去找有沒有這個人再去改值
            float WoodcurrentHealth = (float)datas[0];
            float WindcurrentHealth = (float)datas[1];
            float WatercurrentHealth = (float)datas[2];
            float GoldcurrentHealth = (float)datas[3];
            float RockcurrentHealth = (float)datas[4];
            float FirecurrentHealth = (float)datas[5];

            PlayerLife_Controll.WoodcurrentHealth = WoodcurrentHealth;
            PlayerLife_Controll.WindcurrentHealth = WindcurrentHealth;
            PlayerLife_Controll.WatercurrentHealth = WatercurrentHealth;
            PlayerLife_Controll.GoldcurrentHealth = GoldcurrentHealth;
            PlayerLife_Controll.RockcurrentHealth = RockcurrentHealth;
            PlayerLife_Controll.FirecurrentHealth = FirecurrentHealth;
        }
        if (obj.Code == 1)
        {
            object[] datas = (object[])obj.CustomData;
            float WoodcurrentHealth = (float)datas[0];
            float WindcurrentHealth = (float)datas[1];
            float WatercurrentHealth = (float)datas[2];
            float GoldcurrentHealth = (float)datas[3];
            float RockcurrentHealth = (float)datas[4];
            float FirecurrentHealth = (float)datas[5];

            PlayerLife_Controll.WoodcurrentHealth = WoodcurrentHealth;
            PlayerLife_Controll.WindcurrentHealth = WindcurrentHealth;
            PlayerLife_Controll.WatercurrentHealth = WatercurrentHealth;
            PlayerLife_Controll.GoldcurrentHealth = GoldcurrentHealth;
            PlayerLife_Controll.RockcurrentHealth = RockcurrentHealth;
            PlayerLife_Controll.FirecurrentHealth = FirecurrentHealth;
        }

        /*---防禦力---*/
        if (obj.Code == 2)
        {
            object[] datas = (object[])obj.CustomData;
            float DefenseUpNum = (float)datas[0];
            bullet_move.damage = DefenseUpNum;
        }
        if (obj.Code == 3)
        {
            object[] datas = (object[])obj.CustomData;
            float Defense = (float)datas[0];
            bullet_move.damage = Defense;
        }
        if (obj.Code == 4)
        {
            object[] datas = (object[])obj.CustomData;
            float Defense = (float)datas[0];
            bullet_move.damage = Defense;
        }

        /*---攻擊力---*/
        if (obj.Code == 5)
        {
            object[] datas = (object[])obj.CustomData;
            float AttackUpNum = (float)datas[0];
            Bullet_Player.damage = AttackUpNum;
        }
        if (obj.Code == 6)
        {
            object[] datas = (object[])obj.CustomData;
            float AttackDownNum = (float)datas[0];
            Bullet_Player.damage = AttackDownNum;
        }
        if (obj.Code == 7)
        {
            object[] datas = (object[])obj.CustomData;
            float Attack = (float)datas[0];
            Bullet_Player.damage = Attack;
        }

        /*---攻速---*/
        if (obj.Code == 8)
        {
            object[] datas = (object[])obj.CustomData;
            float AttackSpeedUpNum = (float)datas[0];
            Player_Game.atk_speed = AttackSpeedUpNum;
        }
        if (obj.Code == 9)
        {
            object[] datas = (object[])obj.CustomData;
            float AttackSpeedDownNum = (float)datas[0];
            Player_Game.atk_speed = AttackSpeedDownNum;
        }
        if (obj.Code == 10)
        {
            object[] datas = (object[])obj.CustomData;
            float AttackSpeed = (float)datas[0];
            Player_Game.atk_speed = AttackSpeed;
        }

        /*---跑速---*/
        if (obj.Code == 11)
        {
            object[] datas = (object[])obj.CustomData;
            float SpeedUpNum = (float)datas[0];
            joycon.speed = SpeedUpNum;
        }
        if (obj.Code == 12)
        {
            object[] datas = (object[])obj.CustomData;
            float SpeedDownNum = (float)datas[0];
            joycon.speed = SpeedDownNum;
        }
        if (obj.Code == 13)
        {
            object[] datas = (object[])obj.CustomData;
            float PlayerSpeed = (float)datas[0];
            joycon.speed = PlayerSpeed;
        }
        /*木技能*/
        if (obj.Code == 14)
        {
            object[] datas = (object[])obj.CustomData;
            float WoodcurrentHealth = (float)datas[0];
            float WindcurrentHealth = (float)datas[1];
            float WatercurrentHealth = (float)datas[2];
            float GoldcurrentHealth = (float)datas[3];
            float RockcurrentHealth = (float)datas[4];
            float FirecurrentHealth = (float)datas[5];

            PlayerLife_Controll.WoodcurrentHealth = WoodcurrentHealth;
            PlayerLife_Controll.WindcurrentHealth = WindcurrentHealth;
            PlayerLife_Controll.WatercurrentHealth = WatercurrentHealth;
            PlayerLife_Controll.GoldcurrentHealth = GoldcurrentHealth;
            PlayerLife_Controll.RockcurrentHealth = RockcurrentHealth;
            PlayerLife_Controll.FirecurrentHealth = FirecurrentHealth;
        }
        /*BOSS子彈傷害*/
        if (obj.Code == 15)
        {
            object[] datas = (object[])obj.CustomData;
            float WoodcurrentHealth = (float)datas[0];
            float WatercurrentHealth = (float)datas[1];
            float WindcurrentHealth = (float)datas[2];
            float RockcurrentHealth = (float)datas[3];
            float GoldcurrentHealth = (float)datas[4];
            float FirecurrentHealth = (float)datas[5];

            PlayerLife_Controll.WoodcurrentHealth = WoodcurrentHealth;
            PlayerLife_Controll.WindcurrentHealth = WindcurrentHealth;
            PlayerLife_Controll.WatercurrentHealth = WatercurrentHealth;
            PlayerLife_Controll.GoldcurrentHealth = GoldcurrentHealth;
            PlayerLife_Controll.RockcurrentHealth = RockcurrentHealth;
            PlayerLife_Controll.FirecurrentHealth = FirecurrentHealth;
        }
        /*風技能*/
        if (obj.Code == 16)
        {
            object[] datas = (object[])obj.CustomData;
            bool windskill = (bool)datas[0];
            Player_Game.WindSkillOpen = windskill;
        }
        if (obj.Code == 17)
        {
            object[] datas = (object[])obj.CustomData;
            bool windskill = (bool)datas[0];
            Player_Game.WindSkillOpen = windskill;
        }
        /*按鈕*/
        if (obj.Code == 18)
        {
            object[] datas = (object[])obj.CustomData;
            int countWood = (int)datas[0];
            MenuController.countWood = countWood;
        }
        /*子彈位置同步*/
        if (obj.Code == 20)
        {
            object[] datas = (object[])obj.CustomData;
            int randomNum = (int)datas[0];
            bullet.FinalNum = randomNum;
        }
        /*刪除金幣*/
        if (obj.Code == 21)
        {
            object[] datas = (object[])obj.CustomData;
            bool Delete_Coin = (bool)datas[0];
            Player_Game.Delete_Coin = Delete_Coin;
        }
        /*同步金幣動畫*/
        if (obj.Code == 22)
        {
            object[] datas = (object[])obj.CustomData;
            int Coin_Num = (int)datas[0];
            bool isClickCoin = (bool)datas[1];
            Player_Game.Coin = Coin_Num;
            Player_Game.isClickCoin = isClickCoin;
        }
        /*火技能*/
        if (obj.Code == 23)
        {
            object[] datas = (object[])obj.CustomData;
            float WoodcurrentHealth = (float)datas[0];
            float WindcurrentHealth = (float)datas[1];
            float WatercurrentHealth = (float)datas[2];
            float GoldcurrentHealth = (float)datas[3];
            float RockcurrentHealth = (float)datas[4];
            float FirecurrentHealth = (float)datas[5];
            float BosscurrentHealth = (float)datas[6];

            PlayerLife_Controll.WoodcurrentHealth = WoodcurrentHealth;
            PlayerLife_Controll.WindcurrentHealth = WindcurrentHealth;
            PlayerLife_Controll.WatercurrentHealth = WatercurrentHealth;
            PlayerLife_Controll.GoldcurrentHealth = GoldcurrentHealth;
            PlayerLife_Controll.RockcurrentHealth = RockcurrentHealth;
            PlayerLife_Controll.FirecurrentHealth = FirecurrentHealth;
            healthBar.BosscurrentHealth = BosscurrentHealth;
        }
        if (obj.Code == 24)
        {
            object[] datas = (object[])obj.CustomData;
            float WoodcurrentHealth = (float)datas[0];
            float WindcurrentHealth = (float)datas[1];
            float WatercurrentHealth = (float)datas[2];
            float GoldcurrentHealth = (float)datas[3];
            float RockcurrentHealth = (float)datas[4];
            float FirecurrentHealth = (float)datas[5];
            float BosscurrentHealth = (float)datas[6];

            PlayerLife_Controll.WoodcurrentHealth = WoodcurrentHealth;
            PlayerLife_Controll.WindcurrentHealth = WindcurrentHealth;
            PlayerLife_Controll.WatercurrentHealth = WatercurrentHealth;
            PlayerLife_Controll.GoldcurrentHealth = GoldcurrentHealth;
            PlayerLife_Controll.RockcurrentHealth = RockcurrentHealth;
            PlayerLife_Controll.FirecurrentHealth = FirecurrentHealth;
            healthBar.BosscurrentHealth = BosscurrentHealth;
        }
        /*普攻同步*/
        if (obj.Code == 25)
        {
            object[] datas = (object[])obj.CustomData;
            float BosscurrentHealth = (float)datas[0];
            healthBar.BosscurrentHealth = BosscurrentHealth;
        }
        /*風技能傷害同步*/
        if (obj.Code == 26)
        {
            object[] datas = (object[])obj.CustomData;
            float WoodcurrentHealth = (float)datas[0];
            float WatercurrentHealth = (float)datas[1];
            float GoldcurrentHealth = (float)datas[2];
            float RockcurrentHealth = (float)datas[3];
            float FirecurrentHealth = (float)datas[4];
            float BosscurrentHealth = (float)datas[5];
            PlayerLife_Controll.WoodcurrentHealth = WoodcurrentHealth;
            PlayerLife_Controll.WatercurrentHealth = WatercurrentHealth;
            PlayerLife_Controll.GoldcurrentHealth = GoldcurrentHealth;
            PlayerLife_Controll.RockcurrentHealth = RockcurrentHealth;
            PlayerLife_Controll.FirecurrentHealth = FirecurrentHealth;
            healthBar.BosscurrentHealth = BosscurrentHealth;
        }
        /*水技能傷害同步*/
        if (obj.Code == 27)
        {
            object[] datas = (object[])obj.CustomData;
            float WoodcurrentHealth = (float)datas[0];
            float WindcurrentHealth = (float)datas[1];
            float GoldcurrentHealth = (float)datas[2];
            float RockcurrentHealth = (float)datas[3];
            float FirecurrentHealth = (float)datas[4];
            float BosscurrentHealth = (float)datas[5];
            PlayerLife_Controll.WoodcurrentHealth = WoodcurrentHealth;
            PlayerLife_Controll.WindcurrentHealth = WindcurrentHealth;
            PlayerLife_Controll.GoldcurrentHealth = GoldcurrentHealth;
            PlayerLife_Controll.RockcurrentHealth = RockcurrentHealth;
            PlayerLife_Controll.FirecurrentHealth = FirecurrentHealth;
            healthBar.BosscurrentHealth = BosscurrentHealth;
            
        }
        /*沼澤傷害同步*/
        if (obj.Code == 28)
        {
            object[] datas = (object[])obj.CustomData;
            float WoodcurrentHealth = (float)datas[0];
            float WindcurrentHealth = (float)datas[1];
            float WatercurrentHealth = (float)datas[2];
            float GoldcurrentHealth = (float)datas[3];
            float RockcurrentHealth = (float)datas[4];
            float FirecurrentHealth = (float)datas[5];

            PlayerLife_Controll.WoodcurrentHealth = WoodcurrentHealth;
            PlayerLife_Controll.WindcurrentHealth = WindcurrentHealth;
            PlayerLife_Controll.WatercurrentHealth = WatercurrentHealth;
            PlayerLife_Controll.GoldcurrentHealth = GoldcurrentHealth;
            PlayerLife_Controll.RockcurrentHealth = RockcurrentHealth;
            PlayerLife_Controll.FirecurrentHealth = FirecurrentHealth;
        }
    }
}
