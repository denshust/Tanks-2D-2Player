using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TanksSelecktor : MonoBehaviour
{
    public Image tankImage;
    public Sprite[] sprites;
    private int tankIndex;
    private void Start()
    {
        tankImage.sprite = sprites[tankIndex];
    }
    public void ChangeTank(int direction)
    {
        tankIndex += direction;
        if (tankIndex < 0)
        {
            tankIndex = sprites.Length-1;
        }
        tankIndex %= sprites.Length;
        tankImage.sprite = sprites[tankIndex];
    }


}
