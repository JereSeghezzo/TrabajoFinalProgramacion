using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGem : Gems
{
  public override void Action()
  {
     Destroy(gameObject);
  }
 

}

