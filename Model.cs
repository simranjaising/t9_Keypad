using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lab2
{
    class Model
    {

        public double difference = 1; // time difference for non-predicitve mode
        public List<DateTime> key_1 = new List<DateTime>(); // list of time for key 1
        public List<DateTime> key_2 = new List<DateTime>(); // list of time for key 2
        public List<DateTime> key_3 = new List<DateTime>(); // list of time for key 3
        public List<DateTime> key_4 = new List<DateTime>(); // list of time for key 4
        public List<DateTime> key_5 = new List<DateTime>(); // list of time for key 5
        public List<DateTime> key_6 = new List<DateTime>(); // list of time for key 6
        public List<DateTime> key_7 = new List<DateTime>(); // list of time for key 7
        public List<DateTime> key_8 = new List<DateTime>(); // list of time for key 8
        public List<DateTime> key_9 = new List<DateTime>(); // list of time for key 9
        public List<DateTime> key_0 = new List<DateTime>(); // list of time for key 0

        // dictionary that stores a word as key and the combination of keys as value
        public Dictionary<string, string> dictionary = new Dictionary<string, string>();
        char[] alphabets = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        /// <summary>
        /// This function adds the time to the respective list
        /// </summary>
        /// <param name="list">The index of the list</param>
        /// <param name="d">The time</param>
        public void addTime(int list, DateTime d)
        {
            List<DateTime> temp = new List<DateTime>();
            //

            if (list == 1)
            {
                this.key_1.Add(d);
            }
            if (list == 2)
            {
                this.key_2.Add(d);
            }
            if (list == 3)
            {
                this.key_3.Add(d);
            }
            if (list == 4)
            {
                this.key_4.Add(d);
            }
            if (list == 5)
            {
                this.key_5.Add(d);
            }
            if (list == 6)
            {
                this.key_6.Add(d);
            }
            if (list == 7)
            {
                this.key_7.Add(d);
            }
            if (list == 8)
            {
                this.key_8.Add(d);
            }
            if (list == 9)
            {
                this.key_9.Add(d);
            }
            if (list == 0)
            {
                this.key_0.Add(d);
            }

        }

        /// <summary>
        /// Checks if the last button pressed timestamp 
        /// is less than 1s
        /// </summary>
        /// <param name="list">The index of the list to check</param>
        /// <returns>Returns if the last button press is less than 1s</returns>
        public bool isLessThanDifference(int list)
        {
            bool isLessThanDifference = false;
            List<DateTime> temp = new List<DateTime>();
            if (list == 1)
            {
                // key_1.Add(d);
                temp = this.key_1;
            }
            if (list == 2)
            {
                //key_2.Add(d);
                temp = this.key_2;
            }
            if (list == 3)
            {
                // key_3.Add(d);
                temp = this.key_3;
            }
            if (list == 4)
            {
                // key_4.Add(d);
                temp = this.key_4;
            }
            if (list == 5)
            {
                // key_5.Add(d);
                temp = this.key_5;
            }
            if (list == 6)
            {
                // key_6.Add(d);
                temp = this.key_6;
            }
            if (list == 7)
            {
                // key_7.Add(d);
                temp = this.key_7;
            }
            if (list == 8)
            {
                //key_8.Add(d);
                temp = this.key_8;
            }
            if (list == 9)
            {
                // key_9.Add(d);
                temp = this.key_9;
            }
            if (list == 0)
            {
                //key_0.Add(d);
                temp = this.key_0;
            }
            if (temp.Count >= 2)
            {
                DateTime newTime = temp[temp.Count - 1];
                DateTime oldTime = temp[temp.Count - 2];
                TimeSpan diff = newTime.Subtract(oldTime);
                //  Console.WriteLine(diff);
                if (diff.TotalSeconds <= difference)
                {
                    isLessThanDifference = true;
                }
                else
                {
                    if (diff.Seconds > difference)
                    {
                        isLessThanDifference = false;
                    }
                }
            }
            else
            {
                isLessThanDifference = false;
            }
            return isLessThanDifference;

        }

        /// <summary>
        /// Reads in the dictionary and stores it
        /// </summary>
        /// <param name="lines">array of words</param>
        public void setDictionary(string[] lines)
        {
            // for every word in the array
            foreach (string line in lines)
            {
                // get chars of that word
                char[] charOfWords = line.ToCharArray();
                string key = "";
                // for every char append the key number associated to a 
                // string key
                foreach (char c in charOfWords)
                {
                    int indexOfChar = 0;
                    if (c == 'a' || c == 'b' || c == 'c')
                    {
                        indexOfChar = 2;
                    }
                    if (c == 'd' || c == 'e' || c == 'f')
                    {
                        indexOfChar = 3;
                    }
                    if (c == 'g' || c == 'h' || c == 'i')
                    {
                        indexOfChar = 4;
                    }
                    if (c == 'j' || c == 'k' || c == 'l')
                    {
                        indexOfChar = 5;
                    }
                    if (c == 'm' || c == 'n' || c == 'o')
                    {
                        indexOfChar = 6;
                    }
                    if (c == 'p' || c == 'q' || c == 'r' || c == 's')
                    {
                        indexOfChar = 7;
                    }
                    if (c == 't' || c == 'u' || c == 'v')
                    {
                        indexOfChar = 8;
                    }
                    if (c == 'w' || c == 'x' || c == 'y' || c == 'z')
                    {
                        indexOfChar = 9;
                    }

                    key = key + indexOfChar.ToString();
                }

                // add the word as the value and key as key
                dictionary.Add(line, key);

            }
        }

        /// <summary>
        /// Returns a list of predicted words
        /// </summary>
        /// <param name="combinationNumbers">The combination of keys</param>
        /// <returns>Returns a list of predicted words</returns>
        public List<string> getWords(string combinationNumbers)
        {
            List<string> predictedWords = new List<string>();
            List<string> tempPredictedWords = new List<string>();
            
            // Queries the dictionary for words with value
            // equal to the combination of keys
            var equalWords = from element in dictionary
                             where element.Value.Equals(combinationNumbers)
                             select element.Key;

            tempPredictedWords.AddRange(equalWords);

            if (tempPredictedWords.Count == 0)
            {
                // Queries the dictionary for words with value
                // which start with the combination of keys
                var words = from element in dictionary
                            where element.Value.StartsWith(combinationNumbers)
                            select element.Key;
                tempPredictedWords.AddRange(words);
            }

            int sizeOfPrefix = combinationNumbers.Length;
            int maxSizeOfWord = this.getSizeOfWord(sizeOfPrefix);

            // get words only <= to the max size of the 
            // word specified
            for (int i = sizeOfPrefix; i <= maxSizeOfWord; i++)
            {
                foreach (string word in tempPredictedWords)
                {
                    //foreach (string w in word)
                    //{

                    if (word.Length >= i)
                    {
                        predictedWords.Add(word);
                    }
                    //}

                }
            }
            //var sorted = from s in predictedWords
            //             orderby s.Length ascending
            //             select s;
            List<string> predictedWords1 = tempPredictedWords;
            //foreach (var word in sorted)
            //{
            //    predictedWords1.Add(word);
            //}
            // take the top 15 predicted words
            predictedWords1 = predictedWords1.Take<string>(15).ToList<string>();
            return predictedWords1;
        }

        /// <summary>
        /// Returns the size of words to be picked
        /// </summary>
        /// <param name="sizeOfPrefix">Size of the prefix</param>
        /// <returns>Returns the max size of the word</returns>
        public int getSizeOfWord(int sizeOfPrefix)
        {
            int sizeOfWordMin = 0;
            int sizeOfWordMax = 0;
            if (sizeOfPrefix == 1)
            {
                sizeOfWordMin = 1;
                sizeOfWordMax = 3;
            }
            if (sizeOfPrefix == 2)
            {
                sizeOfWordMin = 2;
                sizeOfWordMax = 5;
            }
            if (sizeOfPrefix == 3)
            {
                sizeOfWordMin = 3;
                sizeOfWordMax = 9;
            }
            if (sizeOfPrefix == 4)
            {
                sizeOfWordMin = 4;
                sizeOfWordMax = 10;
            }
            if (sizeOfPrefix == 5)
            {
                sizeOfWordMin = 5;
                sizeOfWordMax = 11;
            }

            return sizeOfWordMax;

        }

    }

}
