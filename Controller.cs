using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    /// <summary>
    /// This class communicates to the model any changes in the view
    /// </summary>
    class Controller
    {
        // instance of model passed by View
        Model m;

        /// <summary>
        /// This constructor initialises the model
        /// </summary>
        /// <param name="m"></param>
        public Controller(Model m)
        {
            this.m = m;
        }

        /// <summary>
        /// Urges the model to update the timestamp
        /// </summary>
        /// <param name="listNo">The index of the list </param>
        /// <param name="timestamp">Timestamp to be added</param>
        public void updateTimeStamp(int listNo, DateTime timestamp)
        {
            m.addTime(listNo, timestamp);
            //return isLessThanDifference;
        }

        /// <summary>
        /// Gets the last word in the text box
        /// </summary>
        /// <param name="sentence">Text in the text box</param>
        /// <returns>Last word</returns>
        public string getLastWordTyped(string sentence)
        {
            string[] words = sentence.Split(' ');
            return words[words.Length - 1];
        }

        /// <summary>
        /// If no predictive words can be found, returns -
        /// </summary>
        /// <param name="keysPressed">String of combination numbers</param>
        /// <returns>String with hyphens</returns>
        public string keysPressedHyphen(string keysPressed)
        {
            int lenghtOfKeysPresses = keysPressed.Length;
            string hyphenString = "";
            for (int i = 0; i < lenghtOfKeysPresses; i++)
            {
                hyphenString = hyphenString + "-";
            }
            return hyphenString;
        }

    }

}