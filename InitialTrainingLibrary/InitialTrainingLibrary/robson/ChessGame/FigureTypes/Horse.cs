﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitialTrainingLibrary.Interfaces.chess;
using InitialTrainingLibrary.robson.ChessGame;

namespace InitialTrainingLibrary.robson.ChessGame.FigureTypes
{
    public class Horse : ChessBoardFigure
    {
        public Horse(int x, int y, FigureColor color)
        {
            this.figureColor = color;
            this.figurePosition = new ChessBoardFieldCoordinates(x, y);
            this.figureType = FigureKind.Horse;
        }
    }
}