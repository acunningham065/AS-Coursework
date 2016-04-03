using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Battles_Of_Middle_Earth
{
    [Serializable()]
    public class Player
    {
        //1. Add fields
        string _username = null;
        string _password = null;
        int _avatar = 0;
        int _score = 0;
        int _userHighscore = 0;
        double _handicap = 0;


        //2. Default Constructor
        public Player()
        {

        }


        //Overloaded Constructor
        public Player(string username, string userPassword, int userAvatar, double handicap)
        {
            _username = username;
            _password = userPassword;
            _avatar = userAvatar;
            _handicap = handicap;

        }//End overloaded constructor


        //3. Properties

        public string Username
        {
            get { return _username; }

            set { _username = value; }

        }//End Username Property


        public string Password
        {
            get { return _password; }

            set { _password = value; }

        }//End Password Property


        public int Avatar
        {
            get { return _avatar; }

            set { _avatar = value; }

        }//End Avatar Property


        public int Score
        {
            get { return _score; }

            set { _score = value; }

        }//End Score Property


        public int Highscore
        {
            get { return _userHighscore; }

            set { _userHighscore = value; }

        }//End Highscore Property


        public double Handicap
        {
            get { return _handicap; }

            set { _handicap = value; }

        }//End Handicap Property

        public void CheckTopScore(int newScore)
        {
            if (newScore > _userHighscore)
            {
                _userHighscore = newScore;
            }

        }//End CheckTopScore
    }
}
