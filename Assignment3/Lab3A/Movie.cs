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
    ///  This is class is a subclass of Movie class and it implements IEncryptable interface.Thus, it has to implement
    ///  Encrypt() and Decrypt() methods. It inherits Search() directly from Media class. In addition, it overrides the 
    ///  ToString() by adding its own properties.
    /// </summary>
    class Movie : Media, IEncryptable
    {
        /*Properties of a movie object*/
       public string Type { get; set; } 
        public string Director { get; set; } // director of the movie
        public string Summary { get; set; } // summary of the movie 
        /// <summary>
        /// Constructor  Initialize the properties of the Movie ojects 
        /// </summary>
        /// <param name="type">type of media</param>
        /// <param name="title">title of the movie</param>
        /// <param name="year">released year</param>
        /// <param name="director">director of the movie</param>
        /// <param name="summary">movie's summary</param>
        public Movie(string type, string title, int year,string director, string summary) : base(title, year)
        {
            Director = director;
            Summary = summary;
            Type = type;
        }
        /// <summary>
        /// Use Rot13 encryption algorithm to return encrypted data
        /// </summary>
        /// <returns>Encrypted Strings</returns>
        public string Encrypt()
        {
            char[] summary = Summary.ToCharArray();
            int key = 13;
            for (int i = 0; i < summary.Length; i++)
            {
                int value = (int)summary[i];
                if (value >= 'A' && value <= 'Z')
                {
                    if (value > 'M')
                    {
                        value = value + key - 26;
                    }
                    else
                    {
                        value += 13;
                    }
                }
                else if (value >= 'a' && value <= 'z')
                {
                    if (value > 'm')
                    {
                        value = value + key - 26;
                    }
                    else
                    {
                        value += 13;
                    }
                }
                summary[i] = (char)value;
            }

            return new string(summary);
        }
        /// <summary>
        /// Use Rot13 decryption algorithm to return decrypted data
        /// </summary>
        /// <returns>Decrypted Strings</returns>

        public string Decrypt()
        {
            char[] summary = Summary.ToCharArray();

            int key = 13;

            for (int i = 0; i < summary.Length; i++)
            {
                int value = (int)summary[i];
                if (value >= 'A' && value <= 'Z')
                {
                    if (value > 'M')
                    {
                        value -= 13;
                    }
                    else
                    {
                        value = value - key + 26;
                    }
                }
                else if (value >= 'a' && value <= 'z')
                {
                    if (value > 'm')
                    {
                        value -= 13;
                    }
                    else
                    {
                        value = value - key + 26;
                    }
                }
                summary[i] = (char)value;
            }

            return new string(summary);
        }
        /// <summary>
        /// Represent an object of a movie by displaying its properties
        /// </summary>
        /// <returns>representation of a movie</returns>
        public override string ToString()
        {
           
            return $"{Type,-8}  {Title,-60}\t{Year,-8}\t{Director}";
        }
       
    }
}
