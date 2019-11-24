using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BattleshipGame
{
    public enum OccupationType
    {
        [Description("o")]
        Empty,

        [Description("B")]
        Battleship,

        [Description("C")]
        Cruiser,

        [Description("D")]
        Destroyer,

        [Description("S")]
        Submarine,

        [Description("A")]
        Carrier,

        [Description("X")]
        Hit,

        [Description("M")]
        Miss
    }

    public enum OrientationType
    {
        Horizontal,
        Vertical
    }

    public enum ShotResult
    {
        Miss,
        Hit
    }
}
