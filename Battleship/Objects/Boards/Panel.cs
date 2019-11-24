using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using BattleshipGame.Extensions;

namespace BattleshipGame.Objects.Boards
{
    public class Panel
    {
        // Panel has the coordinate and the occupation type

        public Coordinates Coordinates { get; set; }
        public OccupationType OccupationType { get; set; }

        public Panel (int row,int column)
        {
            Coordinates = new Coordinates(row, column);
            OccupationType = OccupationType.Empty;
        }

        public string StatusDescription
        {
            get
            {
                return OccupationType.GetAttributeOfType<DescriptionAttribute>().Description;
            }
        }

        public OccupationType Status
        {
            get
            {
                return OccupationType;
            }
        }


        public bool IsOccupied
        {
            get
            {
                return OccupationType == OccupationType.Battleship
                    || OccupationType == OccupationType.Destroyer
                    || OccupationType == OccupationType.Cruiser
                    || OccupationType == OccupationType.Submarine
                    || OccupationType == OccupationType.Carrier;
            }
        }

    }
}
