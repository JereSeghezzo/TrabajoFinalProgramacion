using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGem : Gems
{
public override void Action()
  {
    player.ColorToBlue();
    Destroy(gameObject);
  }
}
