﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitialTrainingLibrary.Interfaces.chess;

namespace InitialTrainingLibrary.Domi.Game.Board.Figures
{
   public class Horse : ChessFigures
    {
       public Horse(FigureKind figureKind) : base(figureKind)
       {
       }
       public Horse() { }
    }
}