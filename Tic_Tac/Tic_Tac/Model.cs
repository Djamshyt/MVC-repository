using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Tic_Tac
{
    public class Modal : INotifyPropertyChanged
    {

        public enum CurrentPlayer
        {
            X = 1,
            O
        }

        private int turn = 1;
        public CurrentPlayer currentPlayer = CurrentPlayer.X;
        private bool hasWon = false;
        public bool HasWon
        {
            get { return hasWon; }
            set { hasWon = value; NotifyPropertyChanged("HasWon"); }
        }

        private Dictionary<string, int> board = new Dictionary<string, int>()
            {
                {"TopXLeft",0 },
                {"TopXMiddle",0 },
                {"TopXRight",0 },
                {"CenterXLeft",0 },
                {"CenterXMiddle",0 },
                {"CenterXRight",0 },
                {"BottomXLeft",0 },
                {"BottomXMiddle",0 },
                {"BottomXRight",0 }
            };

        public void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private bool CheckIfWon(string buttonName)
        {
            if (WonInRow(buttonName))
            {
                return true;
            }
            else if (WonInColumn(buttonName))
            {
                return true;
            }
            else if (WonInDiagonal(buttonName))
            {
                return true;
            }
            else
                return false;
            
        }

        private bool WonInRow(string name)
        {
            string row = name.Substring(0, name.IndexOf('X') - 1);

            foreach (var element in board)
            {
                string keyName = element.Key;
                string rowOfElement = keyName.Substring(0, keyName.IndexOf('X') - 1);

                if (rowOfElement == row)
                {
                    if (element.Value != (int)currentPlayer)
                        return false;
                }
            }

            return true;
        }

        private bool WonInColumn(string name)
        {
            string column = name.Substring(name.IndexOf('X') + 1);

            foreach (var element in board)
            {
                string keyName = element.Key;
                string columnOfElement = keyName.Substring(keyName.IndexOf('X') + 1);

                if (columnOfElement == column)
                {
                    if (element.Value != (int)currentPlayer)
                        return false;
                }
            }

            return true;
        }

        private bool WonInDiagonal(string name)
        {
            if (name == "TopXLeft" || name == "CenterXMiddle" || name == "BottomXRight")
            {
                if (board["CenterXMiddle"] == (int)currentPlayer && board["BottomXRight"] == (int)currentPlayer && board["TopXLeft"] == (int)currentPlayer)
                {
                    return true;
                }
                else
                    return false;
            }
            if (name == "TopXRight" || name == "CenterXMiddle" || name == "BottomXLeft")
            {
                if (board["CenterXMiddle"] == (int)currentPlayer && board["BottomXLeft"] == (int)currentPlayer && board["TopXRight"] == (int)currentPlayer)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private void UpdateDictionary(string buttonName)
        {
            string tileName = buttonName;

            board[tileName] = (int)currentPlayer;
        }

        public void UpdateBoard(string buttonName)
        {
            UpdateDictionary(buttonName);

            if (turn >= 5)
            {
                if (CheckIfWon(buttonName))
                {
                    HasWon = true;
                }
            }

            turn++;

            if (currentPlayer == CurrentPlayer.X)
                currentPlayer = CurrentPlayer.O;

            else if (currentPlayer == CurrentPlayer.O)
                currentPlayer = CurrentPlayer.X;
        }
    }
}
