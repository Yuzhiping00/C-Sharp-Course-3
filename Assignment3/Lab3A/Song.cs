/*
  Class:  Movie.cs
  Author: Zhiping Yu
  Date:   October 26, 2020
  Purpose: The class can be used to create objects based on its construcor and call its methods to complete some 
            certain tasks.
  I, Zhiping Yu, 000822513 certify 
  that this material is my original work.  
  No other person's work has been used without due acknowledgement.
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    /// <summary>
    ///  This is class is a subclass of Movie class.It inherits Search() directly from Media class. In addition, it overrides the 
    ///  ToString() by adding its own properties.
    /// </summary>
    class Song : Media
    {
        /*Properties of a song*/
        public string Type { get; set; }
        public string Album { get; set; } // which album of this song in
        public string Artist { get; set; } // who created this song
        /// <summary>
        /// Constructor  initialize the properties of a song
        /// </summary>
        /// <param name="type">type of media</param>
        /// <param name="title">title of the song</param>
        /// <param name="year">released year</param>
        /// <param name="album">wlbum name</param>
        /// <param name="artist">artist name</param>
        public Song(string type, string title, int year, string album, string artist) : base(title, year)
        {
           Type = type;
           Album = album;
           Artist = artist;
        }
        /// <summary>
        /// Represent an object of a song by displaying its properties
        /// </summary>
        /// <returns>representation of a song</returns>
        public override string ToString()
        {
            // return $"{Title,-35}{Year,-10}{Album,-30}{Artist}";
            return $"{Type,-8}  {Title,-60}\t{Year,-8}\t{Album,-38}{Artist}";
        }
    }
}
