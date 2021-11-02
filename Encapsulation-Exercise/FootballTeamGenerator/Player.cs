using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string _name;
        private int _endurance, _sprint, _dribble, _passing, _shooting;

        //endurance, sprint, dribble, passing, and shooting.
        //Each stat can be an integer in the range [0..100].
        //The overall skill level of a player is calculated as the average of his stats
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        { 
            get => _name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }
                else
                {
                    _name = value;
                }
            }
        }

        private int Endurance
        { 
            get => _endurance;
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("Endurance should be between 0 and 100.");
                }
                else
                {
                    _endurance = value;
                }
            }
        }

        private int Sprint 
        { 
            get => _sprint;
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("Sprint should be between 0 and 100.");
                }
                else
                {
                    _sprint = value;
                }
            }
        }

        private int Dribble
        {
            get => _dribble;
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("Dribble should be between 0 and 100.");
                }
                else
                {
                    _dribble = value;
                }
            }
        }

        private int Passing 
        {
            get => _passing;
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("Passing should be between 0 and 100.");
                }
                else
                {
                    _passing = value;
                }
            }
        }

        private int Shooting
        {
            get => _shooting;
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("Shooting should be between 0 and 100.");
                }
                else
                {
                    _shooting = value;
                }
            }
        }

        public int SkillLevel { get { return CalcSkillLevel(); } }

        private int CalcSkillLevel()
        {
            return (int)Math.Round((this.Endurance + this.Dribble + this.Passing + this.Shooting + this.Sprint) / (double)5);
        }
    }
}
