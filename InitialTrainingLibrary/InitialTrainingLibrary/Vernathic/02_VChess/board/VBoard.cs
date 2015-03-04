﻿using InitialTrainingLibrary.Interfaces.chess;
using System;

namespace InitialTrainingLibrary.Vernathic._02_Chess
{
    public abstract class VBoard : IBoard
    {
        public IBoardField[,] GetFields()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return "Vernathic";
        }
    }
}