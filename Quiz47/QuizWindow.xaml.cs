using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Quiz47
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {

        const Int64 noq = 2; //no of quiz questions

        List<AnswerModel> answerList = new List<AnswerModel>();
        QuestionModel question = new QuestionModel();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        private int time = 30 * 60 ;
        private int iqno = 0;

        public QuizWindow()
        {

            InitializeComponent();
            Quiz47DAL.DeleteAllAnswer();    //clear answers table...
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1); //(h,m,s)
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
               timer.Text = string.Format("00:{0}:{1}", time/60, time%60);
            }

            else
            {
                dispatcherTimer.Stop();
                previous.IsEnabled = false;
                next.IsEnabled = false;
                Submit.IsEnabled = false;
            }

        }

        private void next_Click_1(object sender, RoutedEventArgs e)
        {


            if (iqno > 0)
            {
                //submit the answer
                AnswerModel ans = new AnswerModel();
                ans.answer = question.answer;
                ans.qno = question.qno;
                string selected = string.Empty;

                if (opta.IsChecked == true) selected = "A";
                if (optb.IsChecked == true) selected = "B";
                if (optc.IsChecked == true) selected = "C";
                if (optd.IsChecked == true) selected = "D";
                //var checkedButton = option.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked);

                ans.selected = selected;

                ///save ans
                ///
               Quiz47DAL.SetAnswer(ans);
                //answerList.Add(ans);


            }
            
            if (iqno < 100)
            {
                iqno++;
                question = Quiz47DAL.GetQuestionByQno(iqno);
                txtquestion.Text = question.question;
                opta.Content = question.optA;
                optb.Content = question.optB;
                optc.Content = question.optC;
                optd.Content = question.optD;
                qno.Content = question.qno;

            }
        }

        private void previous_Click_1(object sender, RoutedEventArgs e)
        {

            if (iqno > 1)
            {

                iqno--;
                question = Quiz47DAL.GetQuestionByQno(iqno);
                txtquestion.Text = question.question;
                opta.Content = question.optA;
                optb.Content = question.optB;
                optc.Content = question.optC;
                optd.Content = question.optD;
                qno.Content = question.qno;
            }
        }

        private void Submit_Click_1(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            previous.IsEnabled = false;
            next.IsEnabled = false;
            Submit.IsEnabled = false;

            SummaryViewModel summary = GetSummary();

            txttotalquestion.Text = String.Format("TOTAL QUIZ QUESTION: {0} ", noq);
            txttotalanswered.Text = String.Format("TOTAL ANSWERED: {0} ",summary.totalQuestion) ;
            txttotalcorrect.Text = String.Format("TOTAL CORRECT: {0} ",summary.totalCorrect);
            txttotalwrong.Text = String.Format("TOTAL WRONG: {0} ",summary.totalWrong);
            txtpercentage.Text = String.Format("PERCENTAGE OVERALL: {0} % ",summary.percentage);


        }

     private SummaryViewModel GetSummary()
        {
            SummaryViewModel summary = new SummaryViewModel();

            List<AnswerModel> answers = Quiz47DAL.GetAllAnswer();

            foreach (AnswerModel ans in answers)
            {
                summary.totalQuestion++;
                if (ans.selected == ans.answer ) summary.totalCorrect++;

            }

         //calculate percentage
            summary.totalWrong = summary.totalQuestion - summary.totalCorrect;

            
             decimal percentage = (decimal) ((decimal)summary.totalCorrect / (decimal) noq) * 100  ;
             summary.percentage = percentage;

            return summary;

        }

    }
}
