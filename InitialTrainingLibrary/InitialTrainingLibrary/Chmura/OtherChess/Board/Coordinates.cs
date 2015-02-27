﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using InitialTrainingLibrary.Interfaces.chess;

namespace InitialTrainingLibrary.Chmura.OtherChess.Board
{
    public class Coordinates :ICoordinates
    {
        protected int x ;
        protected int y;
        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }
    }
}
