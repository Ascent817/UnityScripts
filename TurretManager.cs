using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
public class TurretManager : MonoBehaviour
{

    public TurretHandler th;
    public Text turretName;
    public Text turretSlot;

    public GameObject basicTurret;
    public GameObject commonTurret;
    public GameObject commonTurret1;
    public GameObject commonTurret2;
    public GameObject commonTurret3;
    public GameObject blueTurret;
    public GameObject blueTurret1;
    public GameObject blueTurret2;

    public Texture2D thumbTex;

    public int Coins;
    public Text coinText;

    GameObject current;

    void Start()
    {
        Coins = 10;

        
    }

    public void ChangeSlotTurret()
    {
        if (turretName.text == "Basic Turret: It's basic")
        {
            ChangeTurret(basicTurret);

            /* WARNING: ONLY FOR DEVELOPMENT. UNEXPECTED RESULST MAY OCCUR IF NOT USED WITH CAUTION.
            SaveThumbnail(basicTurret);
            SaveThumbnail(commonTurret);
            SaveThumbnail(commonTurret1);
            SaveThumbnail(commonTurret2);
            SaveThumbnail(commonTurret3);
            SaveThumbnail(blueTurret);
            SaveThumbnail(blueTurret1);
            SaveThumbnail(blueTurret2);
            */
        }
        if (turretName.text == "Common Turret: Higher reload")
        {
            ChangeTurret(commonTurret);
        }
        if (turretName.text == "Common Turret: Dual shot")
        {
            ChangeTurret(commonTurret1);
        }
        if (turretName.text == "Common Turret: 2 way!")
        {
            ChangeTurret(commonTurret2);
        }
        if (turretName.text == "Common Turret: Extra Range")
        {
            ChangeTurret(commonTurret3);
        }
        if (turretName.text == "Rare Turret: Big Boom!")
        {
            ChangeTurret(blueTurret);
        }
        if (turretName.text == "Rare Turret: 4 in 1 Deal")
        {
            ChangeTurret(blueTurret1);
        }
        if (turretName.text == "Rare Turret: Triple shot")
        {
            ChangeTurret(blueTurret2);
        }
    }

    private void Update()
    {
        coinText.text = Coins.ToString();
    }

    void ChangeTurret(GameObject givenTurret)
    {
        th.QueryTurret(turretSlot.text, out current);
        
        if (givenTurret != current)
        {
            
            if (Coins - givenTurret.GetComponent<Turret>().cost > -1)
            {
                th.ChangeTurret(givenTurret, turretSlot.text, out current);
                Coins = Coins - givenTurret.GetComponent<Turret>().cost;
                Coins = Coins + current.GetComponent<Turret>().cost;
            }

        }
        else
        {

        }
        coinText.text = Coins.ToString();
    }

    //To be used ONLY FOR DEVELOPMENT, will break
    /*
    void SaveThumbnail(GameObject turret)
    {
        //Grabs Thumbnails and downloads them
        thumbTex = AssetPreview.GetAssetPreview(turret);
        byte[] bytes = thumbTex.EncodeToPNG();
        var dirPath = Application.dataPath + "/../SaveImages/";
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        File.WriteAllBytes(dirPath + turret.name + ".png", bytes);
    }
    */

}
