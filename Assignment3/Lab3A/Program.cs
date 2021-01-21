/*
  Class:  Program.cs
  Author: Zhiping Yu
  Date:   October 26, 2020
  Purpose: The class is the main class which is used to test the methods of other classes and implement some tasks 
           which requested by the user.
  I, Zhiping Yu, 000822513 certify 
  that this material is my original work.  
  No other person's work has been used without due acknowledgement.
 
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    class Program
    {
        /// <summary>
        /// This class is a test class, which reads the date from a data.txt file externally and 
        /// display the informatin which users required based on their input.
        /// </summary>
        
        
        static int count; // the actual length of the Media[]
        /// <summary>
        /// Read data from a file and use those data in the file to create a Media[]. In addition, check if reading data
        /// is successfully, if it is successfully, then display data based on the user's choice. Otherwise, place
        /// the exception message and exit the program.
        /// </summary>
        /// <param name="args">Not used</param>
        static void Main(string[] args)
        {
            Media[] media = ReadData(); // obtain a Media[] by reading the data
            if (media == null) // if Media[] is null, it means reading data failed
            {
                Console.WriteLine("Program is terminated due to exception. Click any key to close.");
                Console.ReadKey();
            }
            else // reading data is successfully
                ProcessUserInput(media);

        }
        /// <summary>
        /// Create a new Media[] and copy the objects in the original Media[]. Plus, providing the menu for user to make
        /// choices. if user's input is 1,2,3,4,or 5, the program will display the different data to user, and the loop will continue.
        /// However, if user enter 6, the program will exit directly.
        /// </summary>
        /// <param name="media">the original Media[]</param>
        private static void ProcessUserInput(Media[] media)
        {
            Media[] newMedia = new Media[count]; // create a new array based on the number of objects in Media[]
            for (int j = 0; j < count; j++)// copy objects
            {
                newMedia[j] = media[j];
            }
            DisplayMenu();
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) == false)
                {
                    Console.WriteLine("*** Invalid Choice - Try Again ***");
                }
                else
                {
                    Console.Clear();
                    if (choice == 1)
                    {
                        ListBooks(newMedia);

                    }
                    else if (choice == 2)
                    {

                        ListMovies(newMedia);
                    }
                    else if (choice == 3)
                    {

                        ListSongs(newMedia);
                    }
                    else if (choice == 4)
                    {

                        ListMedia(newMedia);
                    }
                    else if (choice == 5)
                    {

                        SearchMedia(newMedia);

                    }
                    else if (choice == 6)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter a number between 1 and 6 Please!");
                    }

                }
                Console.WriteLine("\n\nPress any key to continue......");
                Console.ReadKey();
                Console.Clear();
                DisplayMenu();
            }

        }
        /// <summary>
        /// Prompt to user to enter strings. If any type of media has the title including the string, display the objects
        /// in the new Media[]
        /// </summary>
        /// <param name="newMedia">new Media[]</param>

        private static void SearchMedia(Media[] newMedia)
        {
            Console.WriteLine("Enter a search string:                    ");
            string key = Console.ReadLine();
            Console.WriteLine("\n******************************************************************************************************************");
            bool result = false;
            foreach (Media m in newMedia)
            {
                if (m.Search(key) == true)
                {
                    result = true;
                    if (m is Book book)
                    {
                        Console.WriteLine($"Type     Title                                                          Year             Author               ");
                        Console.WriteLine(m);
                        book.Summary = book.Decrypt();
                        Console.WriteLine("\n"+ book.Summary);
                        
                    }
                    else if (m is Movie movie)
                    {
                        Console.WriteLine($"Type    Title                                                           Year            Director               ");
                        Console.WriteLine(m);
                        movie.Summary = movie.Decrypt();
                        Console.WriteLine("\n"+ movie.Summary);


                    }
                    else
                    {
                        Console.WriteLine("Type      Title                                                         Year            Author/Director/Album           " +
               "      Artist           ");
                        Console.WriteLine(m);


                    }
                    Console.WriteLine("********************************************************************************************************************\n");
                }

            }
            if (result == false)
            {
                Console.WriteLine("\nSorry, we cannot find anything with your title!\n");
            }

        }
        /// <summary>
        /// List all the objects in the new Media[]
        /// </summary>
        /// <param name="media">new Media[]</param>
        private static void ListMedia(Media[] media)
        {
            Console.WriteLine("\n***************************LIST ALL THE MEDIA***********************************" +
                "****************************\n");
            Console.WriteLine("Type      Title                                                         Year            Author/Director/Album           " +
                "      Artist           \n");
            foreach (Media m in media)
            {
                Console.WriteLine(m);
            }
        }
        /// <summary>
        /// List all the songs in the new Media[]
        /// </summary>
        /// <param name="media">new Media[]</param>
        private static void ListSongs(Media[] media)
        {
            Console.WriteLine("\n******************************************LIST ALL THE SONGS" +
                "*************************************************************\n");
            Console.WriteLine($"Type    Title                                                           Year            " +
                $"Album                                 Artist         \n");
            foreach (Media m in media)
            {
                if (m is Song song)
                {
                    Console.WriteLine(song);
                }
            }
        }
        /// <summary>
        /// List all the movies in the new Media[]
        /// </summary>
        /// <param name="media">new Media[]</param>
        private static void ListMovies(Media[] media)
        {
            Console.WriteLine("\n************************LIST ALL THE MOVIES*****************************\n");
            Console.WriteLine($"Type    Title                                                           Year            Director               \n");
            foreach (Media m in media)
            {
                if (m is Movie movie)
                {
                    Console.WriteLine(movie);
                }
            }
        }
        /// <summary>
        /// List all the books in the new Media[]
        /// </summary>
        /// <param name="media">new Media[]</param>
        private static void ListBooks(Media[] media)
        {
            Console.WriteLine("\n************************LIST ALL THE BOOKS*****************************" +
                "**************************\n");
            Console.WriteLine($"Type     Title                                                          Year             Author               \n");
            foreach (Media m in media)
            {
                if (m is Book book)
                {
                    Console.WriteLine(book);
                }
            }
        }
        /// <summary>
        /// Read the data from a data.txt outside and separate the data into different objects which makes up a 
        /// Media[]. If reading data fails, return null. Otherwise, return the Media[] to the main method
        /// </summary>
        /// <returns></returns>
        private static Media[] ReadData()
        {
            Media[] media = new Media[100]; // create an arry of length is 100
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream("Data.txt", FileMode.Open);
                sr = new StreamReader(fs);
                string content = sr.ReadToEnd(); // read the whole file and store it into variable content
                string[] seperator1 = { "-----" }; 
                string[] largeParts = content.Split(seperator1, StringSplitOptions.RemoveEmptyEntries);// use string "-----" to separate the content
                count = largeParts.Length - 1; // assign value to the length of new Movie[]
                for (int i = 0; i < largeParts.Length; i++)
                {
                    string[] smallParts = largeParts[i].Split('|'); // use char '|' to sepatate each smaller part
                    string type = smallParts[0];
                    if (type.Trim() == "BOOK")

                    {
                        SeperateBook(type, media, i, smallParts);
                    }
                    else if (type.Trim() == "MOVIE")
                   
                    {
                        SeperateMoive(type, media, i, smallParts);
                    }
                    else if (type.Trim() == "SONG")
                    {
                        SeperateSong(type, media, i, smallParts);

                    }
                }
            }
            catch (Exception ex) // if reading data falis, catch the exception and prevent program from crashing
            {
                Console.WriteLine($"Exception loading media from file due to {ex.Message}");
                return null;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
                if (sr != null)
                {
                    sr.Close();
                }
            }
            return media;
        }
        /// <summary>
        /// When the title is SONG, store seperated data into properties and create an object of Song. Then store it to
        /// the Media[]
        /// </summary>
        /// <param name="type">type of media</param>
        /// <param name="media">Media[]</param>
        /// <param name="i">index</param>
        /// <param name="smallParts">the part sepatated by char '|'</param>
        private static void SeperateSong(string type, Media[] media, int i, string[] smallParts)
        {
            string title = smallParts[1];
            if (int.TryParse(smallParts[2], out int year) == false)
            {
                Console.WriteLine("Failed to parse the year!");
            }
            string album = smallParts[3];
            string artist = smallParts[4];
            media[i] = new Song(type, title, year, album, artist);
        }
        /// <summary>
        /// When title is MOVIE and the data has been seperated by char '|", it is required to seperate director from 
        /// summary by string[] "\r\n". Then, we need to try to decrypt summary and encrypt it again. Finally, create
        /// an object of movie and store it into the Meida[]
        /// </summary>
        /// <param name="type">type of the media</param>
        /// <param name="media">Media[]</param>
        /// <param name="i">index</param>
        /// <param name="smallParts">data separated by char '|'</param>
        private static void SeperateMoive(string type, Media[] media, int i, string[] smallParts)
        {
            string title, creator;
            int year;
            string[] lastParts;
            AssignValues(smallParts, out title, out year, out lastParts, out creator);
            media[i] = new Movie(type, title, year, creator, "");
            string summary = TestAlgorithm(media, i, lastParts);
            media[i] = new Movie(type, title, year, creator, summary);


        }
        /// <summary>
        /// When title is BOOK and the data has been seperated by char '|", it is required to seperate author from 
        /// summary by string[] "\r\n". Then, we need to try to decrypt summary and encrypt it again. Finally, create
        /// an object of book and store it into the Meida[]
        /// </summary>
        /// <param name="type">type of the media</param>
        /// <param name="media">Media[]</param>
        /// <param name="i">index</param>
        /// <param name="smallParts">data separated by char '|'</param>
        private static void SeperateBook(string type, Media[] media, int i, string[] smallParts)
        {
            string title, creator;
            int year;
            string[] lastParts;
            AssignValues(smallParts, out title, out year, out lastParts, out creator);
            media[i] = new Book(type, title, year, creator, "");
            string summary = TestAlgorithm(media, i, lastParts);
            media[i] = new Book(type, title, year, creator, summary);

        }
        /// <summary>
        /// call encrypt() and decrypt() to verify the summary in the book or movie
        /// </summary>
        /// <param name="media">Media[]</param>
        /// <param name="i">index</param>
        /// <param name="lastParts">summary part</param>
        /// <returns></returns>
        private static string TestAlgorithm(Media[] media, int i, string[] lastParts)
        {
            string summary1 = "";
            for (int k = 1; k < lastParts.Length; k++)
            {
                summary1 += lastParts[k] + "\n";
            }
            string summary3 = "";
            if (media[i] is Book book1)
            {
                book1.Summary = summary1;
                string summary2 = book1.Decrypt();
                // Console.WriteLine(summary2); verify Decrypt()
                book1.Summary = summary2;
                summary3 = book1.Encrypt();
                // Console.Write(summary3); verify Encrypt()
            }

            return summary3;
        }
        /// <summary>
        /// Assign the properties for book or movie using the splited components
        /// </summary>
        /// <param name="smallParts"></param>
        /// <param name="title"></param>
        /// <param name="year"></param>
        /// <param name="lastParts"></param>
        /// <param name="author"></param>
        private static void AssignValues(string[] smallParts, out string title, out int year, out string[] lastParts, out string author)
        {
            title = smallParts[1];
            if (int.TryParse(smallParts[2], out year) == false)
            {
                Console.WriteLine("Failed to parse the year!");
            }
            string combination = smallParts[3]; // combined author with summary

            string[] seperator2 = { "\r\n" };
            lastParts = combination.Split(seperator2, StringSplitOptions.RemoveEmptyEntries);
            author = lastParts[0];
        }

        /// <summary>
        /// Display the menu to users in order to get input from them
        /// </summary>
        static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nZhiping's Media Collection");
            Console.WriteLine("**************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. List All Books");
            Console.WriteLine("2. List All Movies");
            Console.WriteLine("3. List All Songs");
            Console.WriteLine("4. List All Media");
            Console.WriteLine("5. Search All Media by Title\n\n");
            Console.WriteLine("6. Exit Program\n\n");
            Console.WriteLine("Enter choice:  ");
        }
    }
}



