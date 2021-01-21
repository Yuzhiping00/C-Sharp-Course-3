/*
  Class:  Book.cs
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
using System.Data.SqlTypes;
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
    class Book : Media,IEncryptable
    {
        /*Properties of Book class*/
        public string Type { get; set; }
        public string Author { get; set; } // author of the book
        public string Summary { get; set; } // book summary
        /// <summary>
        /// Constructor  initialize the properties of a book 
        /// </summary>
        /// <param name="type">type of media</param>
        /// <param name="title">title of a book</param>
        /// <param name="year">published year</param>
        /// <param name="author">author of a book</param>
        /// <param name="summary">book summary</param>
        public Book(string type, string title, int year, string author, string summary) : base(title, year)
        {
            Type = type;
            Author = author;
            Summary = summary;
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
                        value = value + key - 26 ;
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
                        value = value -key + 26;
                    }
                }else if (value >= 'a' && value <= 'z')
                    {
                        if (value > 'm')
                        {
                            value -= 13;
                        }
                        else
                        {
                            value = value-key + 26;
                        }
                    }
                summary[i] = (char)value;
            }
        
        return new string(summary);
        }
        /// <summary>
        /// Represent a book by displaying the properties of it
        /// </summary>
        /// <returns>representation of a book</returns>
        public override string ToString()
        {
            
            return $"{Type,-8}  {Title,-60}\t{Year,-8}\t{Author}";
        }

    }
}
