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
using System.Threading;
using System.Diagnostics;



namespace Gradel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // quiz variables
        List<int> userAnswer = new List<int>() {0, 0, 0, 0, 0};
        int buttonTag;
        List<int> correctAnswer = new List<int> () {1, 4, 3, 1, 1};
        int percentage;
        int score;
        bool btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10 = false;
        Stopwatch stopwatch = new Stopwatch();

        // creates new instance of a page
        Login_Page loginPage = new Login_Page();
        Instruction_Page instructionPage = new Instruction_Page();
        Question_Page questionPage = new Question_Page();
        ExitPage exitPage = new ExitPage();

        Question1 question1 = new Question1();
        Question2 question2 = new Question2();
        Question3 question3 = new Question3();
        Question4 question4 = new Question4();
        Question5 question5 = new Question5();
        Question6 question6 = new Question6();
        Question7 question7 = new Question7();
        Question8 question8 = new Question8();
        Question9 question9 = new Question9();
        Question10 question10 = new Question10();


        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = loginPage;
            Start_Quiz.Visibility = Visibility.Hidden;
            gotoGrid.Visibility = Visibility.Hidden;
            optionBtns_Grid.Visibility = Visibility.Hidden;
            ExitBtn.Visibility = Visibility.Hidden;
            Percentage.Visibility = Visibility.Hidden;
            CongratsText.Visibility = Visibility.Hidden;
            TimeTaken.Visibility = Visibility.Hidden;
            CorrectAnswer.Visibility = Visibility.Hidden;
            
            
        }

        
        //this sets the question to be displayed to the current selected question number
        private void goto_Btn1_Clicked(object sender, RoutedEventArgs e)
        {
            QuizFrame.Content = question1;
            selectQuestion(1);
            is_Clicked(1);
        }

        private void goto_Btn2_Clicked(object sender, RoutedEventArgs e)
        {
            QuizFrame.Content = question2;
            selectQuestion(2);
            is_Clicked(2);
        }

        private void goto_Btn3_Clicked(object sender, RoutedEventArgs e)
        {
            QuizFrame.Content = question3;
            selectQuestion(3);
            is_Clicked(3);
        }

        private void goto_Btn4_Clicked(object sender, RoutedEventArgs e)
        {
            QuizFrame.Content = question4;
            selectQuestion(4);
            is_Clicked(4);
        }

        private void goto_Btn5_Clicked(object sender, RoutedEventArgs e)
        {
            QuizFrame.Content = question5;
            selectQuestion(5);
            is_Clicked(5);
        }

        private void goto_Btn6_Clicked(object sender, RoutedEventArgs e)
        {
            QuizFrame.Content = question6;
            selectQuestion(6);
            is_Clicked(6);
        }

        private void goto_Btn7_Clicked(object sender, RoutedEventArgs e)
        {
            QuizFrame.Content = question7;
            selectQuestion(7);
            is_Clicked(7);
        }

        private void goto_Btn8_Clicked(object sender, RoutedEventArgs e)
        {
            QuizFrame.Content = question8;
            selectQuestion(8);
            is_Clicked(8);
        }

        private void goto_Btn9_Clicked(object sender, RoutedEventArgs e)
        {
            QuizFrame.Content = question9;
            selectQuestion(9);
            is_Clicked(9);
        }

        private void goto_Btn10_Clicked(object sender, RoutedEventArgs e)
        {
            QuizFrame.Content = question10;
            selectQuestion(10);
            is_Clicked(10);
        }

        //changes page view to the question page
        private void Start_Quiz_Clicked(object sender, RoutedEventArgs e)
        {
            stopwatch.Start();
            selectQuestion(1);
            QuizFrame.Content = question1;
            MainFrame.Content = questionPage; //sets view to question page
            Start_Quiz.Visibility = Visibility.Hidden;
            gotoGrid.Visibility = Visibility.Visible;
            optionBtns_Grid.Visibility = Visibility.Visible;
                        
        }


        //checks if the option button clicked is the correct answer, assigns a score value of 1 and then displays the next question
        private void optionA_CheckAnswer(object sender, RoutedEventArgs e)
        {
            var senderObject = (Button)sender;
            buttonTag = Convert.ToInt32(senderObject.Tag);
            selectAnswer();
            checkAnswer();
        }

        private void optionB_CheckAnswer(object sender, RoutedEventArgs e)
        {
            var senderObject = (Button)sender;
            buttonTag = Convert.ToInt32(senderObject.Tag);
            selectAnswer();
            checkAnswer();
        }

        private void optionC_CheckAnswer(object sender, RoutedEventArgs e)
        {
            var senderObject = (Button)sender;
            buttonTag = Convert.ToInt32(senderObject.Tag);
            selectAnswer();
            checkAnswer();
        }

        private void optionD_CheckAnswer(object sender, RoutedEventArgs e)
        {
            var senderObject = (Button)sender;
            buttonTag = Convert.ToInt32(senderObject.Tag);
            selectAnswer();
            checkAnswer();
        }


        private void ExitBtn_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SubmitBtn_Clicked(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            percentage = (int)Math.Round((double)(score * 100) / 5);

            gotoGrid.Visibility = Visibility.Hidden;
            optionBtns_Grid.Visibility = Visibility.Hidden;
            QuizFrame.Visibility = Visibility.Hidden;
            Question_Num.Visibility = Visibility.Hidden;
            Question_Text.Visibility = Visibility.Hidden;
            MainFrame.Content = exitPage;
            ExitBtn.Visibility = Visibility.Visible;
            Percentage.Visibility = Visibility.Hidden;
            CongratsText.Visibility = Visibility.Visible;
            TimeTaken.Visibility = Visibility.Visible;
            CorrectAnswer.Visibility = Visibility.Visible;

            if(percentage >= 70)
            {
                CongratsText.Text = "PASSED";
            }
            else
            {
                CongratsText.Text = "FAILED";
            }
            CorrectAnswer.Text = "You answered " + score + " correctly";
            Percentage.Text = "Percentage score: " + percentage + "%";
            TimeTaken.Text = "Time:      hh:mm:ss \n\t" + stopwatch.Elapsed.ToString();
            
        }


        //changes page view to instruction page
        private void Login_Btn_Clicked(object sender, RoutedEventArgs e)
        {
            if (Username_textBox.Text == "root" && Password_box.Password == "toor")
            {
                MainFrame.Content = instructionPage; //sets view to instruction page
                Login_btn.Visibility = Visibility.Hidden;
                Start_Quiz.Visibility = Visibility.Visible;
                Username_textBox.Visibility = Visibility.Hidden;
                Password_box.Visibility = Visibility.Hidden;
            }
            else
            {
                Username_textBox.Text = "Incorrect username or password";
            }
            
        }

        //
        private void selectQuestion(int qnum)
        {
            switch (qnum)
            {
                case 1:
                    Question_Num.Content = "Question 1";
                    Question_Text.Content = "Heathrow Airport is an airport based in?";

                    OptionA.Content = "(A)   London";
                    OptionB.Content = "(B)   Paris";
                    OptionC.Content = "(C)  Germany";
                    OptionD.Content = "(D)   China";

                    break;

                case 2:
                    Question_Num.Content = "Question 2";
                    Question_Text.Content = "In which of the following countries can Mount Kilimanjaro be found?";

                    OptionA.Content = "(A)  Gabon";
                    OptionB.Content = "(B)  Uganda";
                    OptionC.Content = "(C)  Gambia";
                    OptionD.Content = "(D)  Tanzania";

                    break;

                case 3:
                    Question_Num.Content = "Question 3";
                    Question_Text.Content = "The acronym N.S.E. stands for?";

                    OptionA.Content = "(A)  Nigerian Society for Education";
                    OptionB.Content = "(B)  National Security Enforcement";
                    OptionC.Content = "(C)  Nigerian Stock Exchange";
                    OptionD.Content = "(D)  National Societal Eradication";

                    break;

                case 4:
                    Question_Num.Content = "Question 4";
                    Question_Text.Content = "One byte is equivalent to";

                    OptionA.Content = "(A)  8 bit";
                    OptionB.Content = "(B)  16 bit";
                    OptionC.Content = "(C)  32 bit";
                    OptionD.Content = "(D)  64 bit";

                    break;

                case 5:
                    Question_Num.Content = "Question 5";
                    Question_Text.Content = "Choose the word most nearly opposite in meaning to - heed";

                    OptionA.Content = "(A)  Ignore";
                    OptionB.Content = "(B)  Express";
                    OptionC.Content = "(C)  Converse";
                    OptionD.Content = "(D)  Attend";

                    break;

                case 6:
                    Question_Num.Content = "Question 6";
                    Question_Text.Content = "The average weight of a class of 24 students is 36 years. \nWhen the weight of the teacher is also included, the average weightincreases by 1kg. \nWhat is the weight of the teacher?";

                    OptionA.Content = "(A)  37kgs";
                    OptionB.Content = "(B)  45kgs";
                    OptionC.Content = "(C)  61kgs";
                    OptionD.Content = "(D)  72kgs";

                    break;

                case 7:
                    Question_Num.Content = "Question 7";
                    Question_Text.Content = "Instruction: \nSelect the answer which fits best with the group.\nNile, Amazon, Rhine";

                    OptionA.Content = "(A)  Baltic";
                    OptionB.Content = "(B)  Michigan";
                    OptionC.Content = "(C)  Danube";
                    OptionD.Content = "(D)  Victoria";

                    break;

                case 8:
                    Question_Num.Content = "Question 8";
                    Question_Text.Content = "Chapter is to book as color is to -------";

                    OptionA.Content = "(A)  Hue";
                    OptionB.Content = "(B)  Artist";
                    OptionC.Content = "(C)  Palette";
                    OptionD.Content = "(D)  Spectrum";

                    break;

                case 9:
                    Question_Num.Content = "Question 9";
                    Question_Text.Content = "Word processing, spreadsheet, and photo-editing are examples of: ";

                    OptionA.Content = "(A)  Application software";
                    OptionB.Content = "(B)  System software";
                    OptionC.Content = "(C)  Operating system software";
                    OptionD.Content = "(D)  Platform software";

                    break;

                case 10:
                    Question_Num.Content = "Question 10";
                    Question_Text.Content = "The set of instructions that tells the computer what to do is";

                    OptionA.Content = "(A)  Softcopy";
                    OptionB.Content = "(B)  Software";
                    OptionC.Content = "(C)  Hardware";
                    OptionD.Content = "(D)  Hardcopy";

                    break;
            }
        }


        private void is_Clicked(int num)
        {
            switch (num)
            {
                case 1:
                    btn1 = true; btn2 = false; btn3 = false; btn4 = false; btn5 = false; btn6 = false; btn7 = false; btn8 = false; btn9 = false; btn10 = false;
                    break;
                case 2:
                    btn2 = true; btn1 = false; btn3 = false; btn4 = false; btn5 = false; btn6 = false; btn7 = false; btn8 = false; btn9 = false; btn10 = false;
                    break;
                case 3:
                    btn3 = true; btn1 = false; btn2 = false; btn4 = false; btn5 = false; btn6 = false; btn7 = false; btn8 = false; btn9 = false; btn10 = false;
                    break;
                case 4:
                    btn4 = true; btn1 = false; btn2 = false; btn3 = false; btn5 = false; btn6 = false; btn7 = false; btn8 = false; btn9 = false; btn10 = false;
                    break;
                case 5:
                    btn5 = true; btn1 = false; btn2 = false; btn3 = false; btn4 = false; btn6 = false; btn7 = false; btn8 = false; btn9 = false; btn10 = false;
                    break;
                case 6:
                    btn1 = true; btn1 = false; btn2 = false; btn3 = false; btn4 = false; btn5 = false; btn7 = false; btn8 = false; btn9 = false; btn10 = false;
                    break;
                case 7:
                    btn1 = true; btn1 = false; btn2 = false; btn3 = false; btn4 = false; btn5 = false; btn6 = false; btn8 = false; btn9 = false; btn10 = false;
                    break;
                case 8:
                    btn1 = true; btn1 = false; btn2 = false; btn3 = false; btn4 = false; btn5 = false; btn6 = false; btn7 = false; btn9 = false; btn10 = false;
                    break;
                case 9:
                    btn1 = true; btn1 = false; btn2 = false; btn3 = false; btn4 = false; btn5 = false; btn6 = false; btn7 = false; btn8 = false; btn10 = false;
                    break;
                case 10:
                    btn1 = true; btn1 = false; btn2 = false; btn3 = false; btn4 = false; btn5 = false; btn6 = false; btn7 = false; btn8 = false; btn9 = false;
                    break;
            
            }
        }

        private void selectAnswer()
        {
            if (btn1 == true)
            {
                userAnswer.RemoveAt(0);
                userAnswer.Insert(0, buttonTag);
            }
            if (btn2 == true)
            {
                userAnswer.RemoveAt(1);
                userAnswer.Insert(1, buttonTag);
            }
            if (btn3 == true)
            {
                userAnswer.RemoveAt(2);
                userAnswer.Insert(2, buttonTag);
            }
            if (btn4 == true)
            {
                userAnswer.RemoveAt(3);
                userAnswer.Insert(3, buttonTag);
            }
            if (btn5 == true)
            {
                userAnswer.RemoveAt(4);
                userAnswer.Insert(4, buttonTag);
            }
            if (btn6 == true)
            {
                if (userAnswer[5] == 0)
                {
                    userAnswer.RemoveAt(5);
                    userAnswer.Insert(5, buttonTag);
                } 
                else if (userAnswer[5] != 0)
                {
                    userAnswer.RemoveAt(5);
                    userAnswer.Insert(5, buttonTag);
                }
            }
            if (btn7 == true)
            {
                userAnswer.RemoveAt(6);
                userAnswer.Insert(6, buttonTag);
            }
            if (btn8 == true)
            {
                userAnswer.RemoveAt(7);
                userAnswer.Insert(7, buttonTag);
            }
            if (btn9 == true)
            {
                userAnswer.RemoveAt(8);
                userAnswer.Insert(8, buttonTag);
            }
            if (btn10 == true)
            {
                userAnswer.RemoveAt(9);
                userAnswer.Insert(9, buttonTag);
            }
        }

        private void checkAnswer()
        {
            if (userAnswer[0] == correctAnswer[0])
            {
                score += 1;
            }
            if (userAnswer[1] == correctAnswer[1])
            {
                score += 1;
            }
            if (userAnswer[2] == correctAnswer[2])
            {
                score += 1;
            }
            if (userAnswer[3] == correctAnswer[3])
            {
                score += 1;
            }
            if (userAnswer[4] == correctAnswer[4])
            {
                score += 1;
            }
            //if (userAnswer[5] == correctAnswer[5])
            //{
            //    score++;
            //}
            //if (userAnswer[6] == correctAnswer[6])
            //{
            //    score++;
            //}
            //if (userAnswer[7] == correctAnswer[7])
            //{
            //    score++;
            //}
            //if (userAnswer[8] == correctAnswer[8])
            //{
            //    score++;
            //}
            //if (userAnswer[9] == correctAnswer[9])
            //{
            //    score++;
            //}
        }

    }
}
