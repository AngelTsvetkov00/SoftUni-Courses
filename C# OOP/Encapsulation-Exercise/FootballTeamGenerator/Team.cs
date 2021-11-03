using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string _name;
        private List<Player> _players;

        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                else
                {
                    _name = value;
                } 
            }
        }

        public List<Player> Players 
        { 
            get => _players; 
            set => _players=value;
        }

        public int TeamRating
        {
            get { return CalculateTeamRating(); }
        }

        private int CalculateTeamRating()
        {
            if (this.Players.Any())
            {
                return (int)Math.Round(this.Players.Average(p => p.SkillLevel));
            }
            else
            {
                return 0;
            }
        }


        public void AddPlayer(Player player)
        {
            if(!this.Players.Any(p => p.Name == player.Name))
            {
                this.Players.Add(player);
            }
        }

        public void RemovePlayer(Player player)
        {
            Player playerToRemove = this.Players.FirstOrDefault(p => p.Name == player.Name);
            this.Players.Remove(playerToRemove);
        }
    }
}
