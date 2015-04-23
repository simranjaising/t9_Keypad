using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isPredictiveModeOn = false; // flag for checking if Prediction Mode is On
        string combinationNumbers = "";
        static List<string> tempPredictedWords = new List<string>(); // List of Predicted words returned
        string currentWord = ""; // word on the text box
        static Model m1 = new Model(); // instance of the model
        Controller c = new Controller(m1); // instance of the controller
        static int count_1 = 0; // count of button 1
        static int count_2 = 0; // count of button 2
        static int count_3 = 0; // count of button 3
        static int count_4 = 0; // count of button 4
        static int count_5 = 0; // count of button 5
        static int count_6 = 0; // count of button 6
        static int count_7 = 0; // count of button 7
        static int count_8 = 0; // count of button 8
        static int count_9 = 0; // count of button 9
        static int count_0 = 0; // count of button 0
        static int count_backspace = 0; // count of back space button
        static int count_space = 0; // count of space button
        string keysPressed = ""; // string that contains the id of the button pressed

        /// <summary>
        /// This initializes the view and read the dictionary
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            //Console.WriteLine("Please enter the name of the file you want to use as a dictionary");
            string fileName;
            List<string> lines = new List<string>(); ;
            int counter = 0;
            //string line;

            // Read the file and display it line by line.
            string[] line = System.IO.File.ReadAllLines("english-words.txt");

            // populate dictionary
            m1.setDictionary(line);
        }

        /// <summary>
        /// This function handles the event of button click 1
        /// </summary>
        /// <param name="sender">Caller of the function</param>
        /// <param name="e">This contain information about the sender</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Text1.Text = this.Text1.Text + "1";
        }


        /// <summary>
        /// This handles the event of button click 2
        /// </summary>
        /// <param name="sender">Caller of the function</param>
        /// <param name="e">This contain information about the sender</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // checks if the predictive mode is On, if not
            if (isPredictiveModeOn == false)
            {
                // update the button counter
                MainWindow.count_2 = MainWindow.count_2 + 1;

                // update the timestamp of this click in the model
                c.updateTimeStamp(2, DateTime.Now);

                // check if this click has occured within 1s
                bool isLessThanDifference = m1.isLessThanDifference(2);

                // if it hasnt occured within 1s
                if (isLessThanDifference == false)
                {
                    // display 'a'
                    this.Text1.Text = this.Text1.Text + "a";
                    MainWindow.count_2 = 0;

                }
                else
                {
                    // if it has occured within 1s
                    if (isLessThanDifference == true)
                    {

                        // display 'b' if button 2 is clicked twice
                        if (count_2 == 1)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "b";

                        }
                        // display 'c' if button 2 is clicked thrice
                        if (count_2 == 2)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "c";

                        }
                        // display '2' if button 2 is clicked four times
                        if (count_2 == 3)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "2";

                        }
                        // display 'a' if button 2 is clicked five times
                        if (count_2 == 4)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "a";

                            MainWindow.count_2 = 0;
                        }
                    }
                }
            }
            // if Predictive mode is On
            else
            {

                count_0 = 0;

                // add 2 to the combination of keys presses
                keysPressed = keysPressed + "2";

                // check if this is a new word or an old word
                currentWord = c.getLastWordTyped(this.Text1.Text);

                // if it is a new word
                if (currentWord == "")
                {
                    // display an 'a'
                    this.Text1.Text = this.Text1.Text + "a";

                    // get predicted words
                    tempPredictedWords = m1.getWords(keysPressed);
                }
                else
                {
                    // display an 'a'
                    this.Text1.Text = this.Text1.Text + "a";

                    // get predicted words
                    tempPredictedWords = m1.getWords(keysPressed);
                    tempPredictedWords.Add(currentWord);

                    // if no predicted words are returned display ----
                    if (tempPredictedWords.Count == 0)
                    {
                        tempPredictedWords.Add(c.keysPressedHyphen(keysPressed));
                    }


                    string tempText = "";

                    // get array of words in the textbox
                    string[] words = getListOfWords();

                    // if one word in the textbox, show first predicted word
                    if (words.Length == 1)
                    {
                        this.Text1.Text = tempPredictedWords[0];
                    }

                    // if more than one word present then show all words,
                    // and first predicted word
                    if (words.Length > 2)
                    {

                        for (int i = 0; i < words.Length - 1; i++)
                        {
                            tempText = tempText + words[i] + " ";
                        }

                        this.Text1.Text = tempText + tempPredictedWords[0];

                    }
                }

            }
        }

        /// <summary>
        /// This handles the event of button click 3
        /// </summary>
        /// <param name="sender">Caller of the function</param>
        /// <param name="e">This contain information about the sender</param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (isPredictiveModeOn == false)
            {

                MainWindow.count_3 = MainWindow.count_3 + 1;


                c.updateTimeStamp(3, DateTime.Now);


                bool isLessThanDifference = m1.isLessThanDifference(3);


                if (isLessThanDifference == false)
                {

                    this.Text1.Text = this.Text1.Text + "d";
                    MainWindow.count_3 = 0;

                }
                else
                {
                    // if it has occured within 1s
                    if (isLessThanDifference == true)
                    {


                        if (count_3 == 1)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "e";

                        }

                        if (count_3 == 2)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "f";

                        }

                        if (count_3 == 3)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "3";

                        }

                        if (count_3 == 4)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "d";

                            MainWindow.count_3 = 0;
                        }
                    }
                }
            }
            else
            {
                count_0 = 0;
                keysPressed = keysPressed + "3";
                currentWord = c.getLastWordTyped(this.Text1.Text);
                if (currentWord == "")
                {
                    this.Text1.Text = this.Text1.Text + "d";
                    currentWord = c.getLastWordTyped(this.Text1.Text);

                    tempPredictedWords = m1.getWords(keysPressed);
                }
                else
                {
                    this.Text1.Text = this.Text1.Text + "d";
                    currentWord = c.getLastWordTyped(this.Text1.Text);
                    tempPredictedWords = m1.getWords(keysPressed);
                    tempPredictedWords.Add(currentWord);
                    if (tempPredictedWords.Count == 0)
                    {
                        tempPredictedWords.Add(c.keysPressedHyphen(keysPressed));
                    }
                    string tempText = "";
                    string[] words = getListOfWords();
                    if (words.Length == 1)
                    {
                        this.Text1.Text = tempPredictedWords[0];
                    }
                    if (words.Length == 2)
                    {
                        this.Text1.Text = words[0] + " " + tempPredictedWords[0];
                    }
                    if (words.Length > 2)
                    {

                        for (int i = 0; i < words.Length - 1; i++)
                        {
                            tempText = tempText + words[i] + " ";
                        }

                        this.Text1.Text = tempText + tempPredictedWords[0];

                    }
                }

            }

        }

        /// <summary>
        /// This handles the event of button click 4
        /// </summary>
        /// <param name="sender">Caller of the function</param>
        /// <param name="e">This contain information about the sender</param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (isPredictiveModeOn == false)
            {
                MainWindow.count_4 = MainWindow.count_4 + 1;
                c.updateTimeStamp(4, DateTime.Now);
                bool isLessThanDifference = m1.isLessThanDifference(4);
                if (isLessThanDifference == false)
                {
                    this.Text1.Text = this.Text1.Text + "g";
                    MainWindow.count_4 = 0;
                }
                else
                {
                    if (isLessThanDifference == true)
                    {

                        if (MainWindow.count_4 == 1)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "h";
                        }
                        if (MainWindow.count_4 == 2)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "i";
                        }
                        if (MainWindow.count_4 == 3)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "4";
                            // MainWindow.count_4 = 0;
                        }
                        if (MainWindow.count_4 == 4)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "g";
                            MainWindow.count_4 = 0;
                        }
                    }
                }
            }
            else
            {
                count_0 = 0;
                keysPressed = keysPressed + "4";
                currentWord = c.getLastWordTyped(this.Text1.Text);
                if (currentWord == "")
                {
                    this.Text1.Text = this.Text1.Text + "g";
                    currentWord = c.getLastWordTyped(this.Text1.Text);
                    tempPredictedWords = m1.getWords(keysPressed);
                }
                else
                {
                    this.Text1.Text = this.Text1.Text + "g";
                    currentWord = c.getLastWordTyped(this.Text1.Text);
                    tempPredictedWords = m1.getWords(keysPressed);
                    tempPredictedWords.Add(currentWord);
                    if (tempPredictedWords.Count == 0)
                    {
                        tempPredictedWords.Add(c.keysPressedHyphen(keysPressed));
                    }
                    string tempText = "";
                    string[] words = getListOfWords();
                    if (words.Length == 1)
                    {
                        this.Text1.Text = tempPredictedWords[0];
                    }
                    if (words.Length == 2)
                    {
                        this.Text1.Text = words[0] + " " + tempPredictedWords[0];
                    }
                    if (words.Length > 2)
                    {

                        for (int i = 0; i < words.Length - 1; i++)
                        {
                            tempText = tempText + words[i] + " ";
                        }

                        this.Text1.Text = tempText + tempPredictedWords[0];

                    }
                }

            }
        }

        /// <summary>
        /// This handles the event of button click 5
        /// </summary>
        /// <param name="sender">Caller of the function</param>
        /// <param name="e">This contain information about the sender</param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (isPredictiveModeOn == false)
            {
                MainWindow.count_5 = MainWindow.count_5 + 1;
                c.updateTimeStamp(5, DateTime.Now);
                bool isLessThanDifference = m1.isLessThanDifference(5);
                if (isLessThanDifference == false)
                {
                    this.Text1.Text = this.Text1.Text + "j";
                    MainWindow.count_5 = 0;
                }
                else
                {
                    if (isLessThanDifference == true)
                    {

                        if (MainWindow.count_5 == 1)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "k";
                        }
                        if (MainWindow.count_5 == 2)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "l";
                        }
                        if (MainWindow.count_5 == 3)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "5";
                            // MainWindow.count_5 = 0;
                        }
                        if (MainWindow.count_5 == 4)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "j";
                            MainWindow.count_5 = 0;
                        }
                    }
                }
            }
            else
            {
                count_0 = 0;
                keysPressed = keysPressed + "5";
                currentWord = c.getLastWordTyped(this.Text1.Text);
                if (currentWord == "")
                {
                    this.Text1.Text = this.Text1.Text + "j";
                    currentWord = c.getLastWordTyped(this.Text1.Text);
                    tempPredictedWords = m1.getWords(keysPressed);
                }
                else
                {
                    this.Text1.Text = this.Text1.Text + "j";
                    currentWord = c.getLastWordTyped(this.Text1.Text);
                    tempPredictedWords = m1.getWords(keysPressed);
                    tempPredictedWords.Add(currentWord);
                    if (tempPredictedWords.Count == 0)
                    {
                        tempPredictedWords.Add(c.keysPressedHyphen(keysPressed));
                    }
                    string tempText = "";
                    string[] words = getListOfWords();
                    if (words.Length == 1)
                    {
                        this.Text1.Text = tempPredictedWords[0];
                    }
                    if (words.Length == 2)
                    {
                        this.Text1.Text = words[0] + " " + tempPredictedWords[0];
                    }
                    if (words.Length > 2)
                    {

                        for (int i = 0; i < words.Length - 1; i++)
                        {
                            tempText = tempText + words[i] + " ";
                        }

                        this.Text1.Text = tempText + tempPredictedWords[0];

                    }
                }

            }
        }

        /// <summary>
        /// This handles the event of button click 6
        /// </summary>
        /// <param name="sender">Caller of the function</param>
        /// <param name="e">This contain information about the sender</param>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (isPredictiveModeOn == false)
            {
                MainWindow.count_6 = MainWindow.count_6 + 1;
                c.updateTimeStamp(6, DateTime.Now);
                bool isLessThanDifference = m1.isLessThanDifference(6);
                if (isLessThanDifference == false)
                {
                    this.Text1.Text = this.Text1.Text + "m";
                    MainWindow.count_6 = 0;
                }
                else
                {
                    if (isLessThanDifference == true)
                    {

                        if (MainWindow.count_6 == 1)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "n";
                        }
                        if (MainWindow.count_6 == 2)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "o";
                        }
                        if (MainWindow.count_6 == 3)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "6";
                            // MainWindow.count_6 = 0;
                        }
                        if (MainWindow.count_6 == 4)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "m";
                            MainWindow.count_6 = 0;
                        }
                    }
                }
            }
            else
            {
                count_0 = 0;
                keysPressed = keysPressed + "6";
                currentWord = c.getLastWordTyped(this.Text1.Text);
                if (currentWord == "")
                {
                    this.Text1.Text = this.Text1.Text + "m";
                    currentWord = c.getLastWordTyped(this.Text1.Text);
                    tempPredictedWords = m1.getWords(keysPressed);
                }
                else
                {
                    this.Text1.Text = this.Text1.Text + "m";
                    currentWord = c.getLastWordTyped(this.Text1.Text);
                    tempPredictedWords = m1.getWords(keysPressed);
                    tempPredictedWords.Add(currentWord);
                    if (tempPredictedWords.Count == 0)
                    {
                        tempPredictedWords.Add(c.keysPressedHyphen(keysPressed));
                    }
                    string tempText = "";
                    string[] words = getListOfWords();
                    if (words.Length == 1)
                    {
                        this.Text1.Text = tempPredictedWords[0];
                    }
                    if (words.Length == 2)
                    {
                        this.Text1.Text = words[0] + " " + tempPredictedWords[0];
                    }
                    if (words.Length > 2)
                    {

                        for (int i = 0; i < words.Length - 1; i++)
                        {
                            tempText = tempText + words[i] + " ";
                        }

                        this.Text1.Text = tempText + tempPredictedWords[0];

                    }
                }

            }
        }

        /// <summary>
        /// This handles the event of button click 7
        /// </summary>
        /// <param name="sender">Caller of the function</param>
        /// <param name="e">This contain information about the sender</param>
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (isPredictiveModeOn == false)
            {
                MainWindow.count_7 = MainWindow.count_7 + 1;
                c.updateTimeStamp(7, DateTime.Now);
                bool isLessThanDifference = m1.isLessThanDifference(7);
                if (isLessThanDifference == false)
                {
                    this.Text1.Text = this.Text1.Text + "p";
                    MainWindow.count_7 = 0;
                }
                else
                {
                    if (isLessThanDifference == true)
                    {
                        if (MainWindow.count_7 == 1)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "q";
                        }
                        if (MainWindow.count_7 == 2)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "r";
                        }
                        if (MainWindow.count_7 == 3)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "s";
                        }
                        if (MainWindow.count_7 == 4)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "7";
                            // MainWindow.count_7 = 0;
                        }
                        if (MainWindow.count_7 == 5)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "p";
                            MainWindow.count_7 = 0;
                        }
                    }
                }
            }
            else
            {
                count_0 = 0;
                keysPressed = keysPressed + "7";
                currentWord = c.getLastWordTyped(this.Text1.Text);
                if (currentWord == "")
                {
                    this.Text1.Text = this.Text1.Text + "p";
                    currentWord = c.getLastWordTyped(this.Text1.Text);
                    tempPredictedWords = m1.getWords(keysPressed);
                }
                else
                {
                    this.Text1.Text = this.Text1.Text + "q";
                    currentWord = c.getLastWordTyped(this.Text1.Text);
                    tempPredictedWords = m1.getWords(keysPressed);
                    tempPredictedWords.Add(currentWord);
                    if (tempPredictedWords.Count == 0)
                    {
                        tempPredictedWords.Add(c.keysPressedHyphen(keysPressed));
                    }
                    string tempText = "";
                    string[] words = getListOfWords();
                    if (words.Length == 1)
                    {
                        this.Text1.Text = tempPredictedWords[0];
                    }
                    if (words.Length == 2)
                    {
                        this.Text1.Text = words[0] + " " + tempPredictedWords[0];
                    }
                    if (words.Length > 2)
                    {

                        for (int i = 0; i < words.Length - 1; i++)
                        {
                            tempText = tempText + words[i] + " ";
                        }

                        this.Text1.Text = tempText + tempPredictedWords[0];

                    }
                }

            }
        }

        /// <summary>
        /// This handles the event of button click 8
        /// </summary>
        /// <param name="sender">Caller of the function</param>
        /// <param name="e">This contain information about the sender</param>
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (isPredictiveModeOn == false)
            {
                MainWindow.count_8 = MainWindow.count_8 + 1;
                c.updateTimeStamp(8, DateTime.Now);
                bool isLessThanDifference = m1.isLessThanDifference(8);
                if (isLessThanDifference == false)
                {
                    this.Text1.Text = this.Text1.Text + "t";
                    MainWindow.count_8 = 0;
                }
                else
                {
                    if (isLessThanDifference == true)
                    {
                        if (MainWindow.count_8 == 1)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "u";
                        }
                        if (MainWindow.count_8 == 2)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "v";
                        }
                        if (MainWindow.count_8 == 3)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "8";
                            //MainWindow.count_8 = 0;
                        }
                        if (MainWindow.count_8 == 4)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "t";
                            MainWindow.count_8 = 0;
                        }
                    }
                }
            }
            else
            {
                count_0 = 0;
                keysPressed = keysPressed + "8";
                currentWord = c.getLastWordTyped(this.Text1.Text);
                if (currentWord == "")
                {
                    this.Text1.Text = this.Text1.Text + "t";
                    currentWord = c.getLastWordTyped(this.Text1.Text);
                    tempPredictedWords = m1.getWords(keysPressed);
                }
                else
                {
                    this.Text1.Text = this.Text1.Text + "t";
                    currentWord = c.getLastWordTyped(this.Text1.Text);
                    tempPredictedWords = m1.getWords(keysPressed);
                    tempPredictedWords.Add(currentWord);
                    if (tempPredictedWords.Count == 0)
                    {
                        tempPredictedWords.Add(c.keysPressedHyphen(keysPressed));
                    }
                    string tempText = "";
                    string[] words = getListOfWords();
                    if (words.Length == 1)
                    {
                        this.Text1.Text = tempPredictedWords[0];
                    }
                    if (words.Length == 2)
                    {
                        this.Text1.Text = words[0] + " " + tempPredictedWords[0];
                    }
                    if (words.Length > 2)
                    {

                        for (int i = 0; i < words.Length - 1; i++)
                        {
                            tempText = tempText + words[i] + " ";
                        }

                        this.Text1.Text = tempText + tempPredictedWords[0];

                    }
                }

            }
        }

        /// <summary>
        /// This handles the event of button click 9
        /// </summary>
        /// <param name="sender">Caller of the function</param>
        /// <param name="e">This contain information about the sender</param>
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (isPredictiveModeOn == false)
            {
                MainWindow.count_9 = MainWindow.count_9 + 1;
                c.updateTimeStamp(9, DateTime.Now);
                bool isLessThanDifference = m1.isLessThanDifference(9);
                if (isLessThanDifference == false)
                {
                    this.Text1.Text = this.Text1.Text + "w";
                    MainWindow.count_9 = 0;
                }
                else
                {
                    if (isLessThanDifference == true)
                    {

                        if (MainWindow.count_9 == 1)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "x";
                        }
                        if (MainWindow.count_9 == 2)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "y";
                        }
                        if (MainWindow.count_9 == 3)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "z";
                        }
                        if (MainWindow.count_9 == 4)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "9";
                            //MainWindow.count_9 = 0;
                        }
                        if (MainWindow.count_9 == 5)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "w";
                            MainWindow.count_9 = 0;
                        }
                    }
                }
            }
            else
            {
                count_0 = 0;
                keysPressed = keysPressed + "9";
                currentWord = c.getLastWordTyped(this.Text1.Text);
                if (currentWord == "")
                {
                    this.Text1.Text = this.Text1.Text + "w";
                    currentWord = c.getLastWordTyped(this.Text1.Text);
                    tempPredictedWords = m1.getWords(keysPressed);
                }
                else
                {
                    this.Text1.Text = this.Text1.Text + "w";
                    currentWord = c.getLastWordTyped(this.Text1.Text);
                    tempPredictedWords = m1.getWords(keysPressed);
                    tempPredictedWords.Add(currentWord);

                    if (tempPredictedWords.Count == 0)
                    {
                        tempPredictedWords.Add(c.keysPressedHyphen(keysPressed));
                    }
                    string tempText = "";
                    string[] words = getListOfWords();
                    if (words.Length == 1)
                    {
                        this.Text1.Text = tempPredictedWords[0];
                    }
                    if (words.Length == 2)
                    {
                        this.Text1.Text = words[0] + " " + tempPredictedWords[0];
                    }
                    if (words.Length > 2)
                    {

                        for (int i = 0; i < words.Length - 1; i++)
                        {
                            tempText = tempText + words[i] + " ";
                        }

                        this.Text1.Text = tempText + tempPredictedWords[0];

                    }
                }

            }
        }

        /// <summary>
        /// This handles the event of backspace event
        /// </summary>
        /// <param name="sender">Caller of the function</param>
        /// <param name="e">This contain information about the sender</param>
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            // predictive mode is off, then remove one last char from text box
            if (isPredictiveModeOn == false)
            {
                if (this.Text1.Text.Length > 0)
                {
                    this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1);
                }
            }
            // if predictive mode is on
            else
            {
                // if in the middle of a word, remove one last char from the word
                if (keysPressed != "")
                {
                    keysPressed = keysPressed.Substring(0, (keysPressed.Length - 1));
                }

                if (keysPressed != "")
                {
                    // predict new words on the remaining key presses
                    tempPredictedWords = m1.getWords(keysPressed);
                    if (tempPredictedWords.Count == 0)
                    {
                        tempPredictedWords.Add(c.keysPressedHyphen(keysPressed));
                    }
                    string tempText = "";
                    string[] words = getListOfWords();
                    if (words.Length == 1)
                    {
                        this.Text1.Text = tempPredictedWords[0];
                    }
                    if (words.Length >= 2)
                    {

                        for (int i = 0; i < words.Length - 1; i++)
                        {
                            tempText = tempText + words[i] + " ";
                        }

                        this.Text1.Text = tempText + tempPredictedWords[0];

                    }
                }
                // if cursor is at the ending of a word, delete the entire word and space
                if (keysPressed == "")
                {
                    if (this.Text1.Text.Length > 0)
                    {
                        string textboxText = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1);
                        string[] words = textboxText.Split(' ');
                        int lenOfLastWord = words[words.Length - 1].Length;
                        this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - lenOfLastWord - 1);

                    }

                }
            }
        }

        /// <summary>
        /// This button handles the looping through predicted words,
        /// and printing 0 or ~
        /// </summary>
        /// <param name="sender">Caller of the function</param>
        /// <param name="e">This contain information about the sender</param>
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            // if predictive mode is off, then print 0 or ~, depending on the time
            if (isPredictiveModeOn == false)
            {
                MainWindow.count_0 = MainWindow.count_0 + 1;
                c.updateTimeStamp(0, DateTime.Now);
                bool isLessThanDifference = m1.isLessThanDifference(0);
                if (isLessThanDifference == false)
                {
                    this.Text1.Text = this.Text1.Text + "0";
                    MainWindow.count_0 = 0;
                }
                else
                {
                    if (isLessThanDifference == true)
                    {

                        if (MainWindow.count_0 == 1)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "~";
                            //MainWindow.count_0 = 0;
                        }
                        if (MainWindow.count_0 == 2)
                        {
                            this.Text1.Text = this.Text1.Text.Substring(0, this.Text1.Text.Length - 1) + "0";
                            MainWindow.count_0 = 0;
                        }
                    }
                }
            }
            // if predicitive mode is on, then display the 
            // predicted words, one by one
            else
            {
                string[] words = this.Text1.Text.Split(' ');
                string tempText = "";

                for (int i = 0; i < words.Length - 1; i++)
                {
                    tempText = tempText + words[i] + " ";
                }

                this.Text1.Text = tempText + getNextPredWord();
            }
        }

        /// <summary>
        /// This function return the predicted words, one at a time
        /// </summary>
        /// <returns>Returns the next predicted word</returns>
        public string getNextPredWord()
        {
            count_0 = count_0 + 1;
            int size = tempPredictedWords.Count;
            string word = "";
            if (count_0 <= (size))
            {
                word = tempPredictedWords[count_0 - 1];
                //count_0=count_0+1;
            }
            if (count_0 > size)
            {
                count_0 = 1;
                word = tempPredictedWords[0];
                //  count_0 = count_0 + 1;
            }

            return word;
        }

        /// <summary>
        /// Returns an array of words present on the text box
        /// </summary>
        /// <returns>Array of words present on the textbox</returns>
        public string[] getListOfWords()
        {
            return this.Text1.Text.Split(' ');
        }

        /// <summary>
        /// This function handles the event of button click space
        /// </summary>
        // <param name="sender">Caller of the function</param>
        /// <param name="e">This contain information about the sender</param>
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            this.Text1.Text = this.Text1.Text + " ";
            // re-initializes keypressed for new word
            keysPressed = "";
        }

        /// <summary>
        /// This function handles the event of checking a 
        /// check box
        /// </summary>
        // <param name="sender">Caller of the function</param>
        /// <param name="e">This contain information about the sender</param>
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (isPredictiveModeOn == false)
            {
                isPredictiveModeOn = true;
            }

        }

        /// <summary>
        /// This function handles the event of un-checking a 
        /// check box
        /// </summary>
        /// <param name="sender">Caller of the function</param>
        /// <param name="e">This contain information about the sender</param>
        private void CheckBox_unChecked(object sender, RoutedEventArgs e)
        {

            if (isPredictiveModeOn == true)
            {
                isPredictiveModeOn = false;
            }

        }

    }
}
