using System;
using System.Collections.Generic;
using System.Text;

namespace NbaApp.Common.Entities
{
    public class Team
    {
        /* Primary Key */
        public Guid ID { get; set; } = Guid.NewGuid();

        /* Properties */
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Conference { get; set; }
        public string Divisions { get; set; }
        public int FoundedYear { get; set; }
        public List<Player> Players { get; set; }
        public string Arena { get; set; }
        public string Location { get; set; }
        public string Coach { get; set; }


        //        Conference Eastern
        //Division Atlantic
        //Founded	1946
        //History Boston Celtics
        //1946–present[1][2]
        //Arena   TD Garden
        //Location Boston, Massachusetts
        //Team colors Green, gold, black, brown, white[3][4][5]

        //Main sponsor General Electric[6]
        //President   Rich Gotham
        //General manager Danny Ainge
        //Head coach  Brad Stevens
        //Ownership Boston Basketball Partners
        //(Wyc Grousbeck, CEO/Governor)[7]
        //        Affiliation(s)  Maine Red Claws
        //        Championships	17 (1957, 1959, 1960, 1961, 1962, 1963, 1964, 1965, 1966, 1968, 1969, 1974, 1976, 1981, 1984, 1986, 2008)
        //Conference titles	21 (1957, 1958, 1959, 1960, 1961, 1962, 1963, 1964, 1965, 1966, 1968, 1969, 1974, 1976, 1981, 1984, 1985, 1986, 1987, 2008, 2010)
        //Division titles	22 (1972, 1973, 1974, 1975, 1976, 1980, 1981, 1982, 1984, 1985, 1986, 1987, 1988, 1991, 1992, 2005, 2008, 2009, 2010, 2011, 2012, 2017)
        //Retired numbers	22 (00, 1, 2, 3, 6, 10, 14, 15, 16, 17, 18, 19, 21, 22, 23, 24, 25, 31, 32, 33, 34, 35, LOSCY)
        //Website www.nba.com/celtics


        /* Auto-Implemented Properties */

        /* Constructors */
        public Team()
        {

        }


        /* Methods */
    }
}
