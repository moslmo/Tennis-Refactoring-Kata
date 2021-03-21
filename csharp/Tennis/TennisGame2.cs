namespace Tennis
{
  public class Player
    {
        private readonly int _initialScore;

        public Player(string name, int point)
        {
             Name = name;
            _initialScore = point;
         }

        public string Name { get; }

        public int Point { get; set; }

 

        public void Score()
        {
          Point += _initialScore + 1;
        }

    }

public class TennisGame2 : ITennisGame
{

        private readonly Player _player1;
        private readonly Player _player2;
        public static string[] Points = { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame2(string player1Name, string player2Name)
        {
            _player1 = new Player(player1Name, 0);
            _player2 = new Player(player2Name, 0);
        }

        public string GetScore()
        {

            if (PlayerHasWon())
                  return "Win for " + PlayerWhoWon();

           
           if (IsGameFinished())
            {
              return !PointsAreOdd() ? "Deuce" : "Advantage " + PlayerWhoWon();
            }

            
             return !PointsAreOdd()? Points[_player1.Point] + "-All"
                : Points[_player1.Point] + "-" + Points[_player2.Point];
        }

 

        public void WonPoint(string player)
        {

            if (player == "player1")
            {
                _player1.Score();
            }

            else

            {
               _player2.Score();
                
            }

        }

 

        private bool IsGameFinished()
        {
           return _player1.Point > 3 || _player2.Point > 3;
        }

 

        private bool PlayerHasWon()
        {
          return IsGameFinished() && (_player1.Point - _player2.Point >= 2 || _player2.Point - _player1.Point >= 2);
        }

 

        private bool PointsAreOdd() 
        {

         return _player1.Point != _player2.Point;

        }

        private string PlayerWhoWon()
        {
          return _player1.Point > _player2.Point ? _player1.Name : _player2.Name;

        }

    }

}

