using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCharacterManagement;

public class PlataberuManagement : CharacterManager_n
{
    public override Plataberu character => ServerCommunication._EnemyCharacter;
}