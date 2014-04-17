using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace Quiz47
{
    public class Quiz47DAL
    {

        const Int64 userid = 1; //to be passed for multi contestant mode 
        const string filename = @"C:\KBL\Quiz47\Quiz47\Quiz47.sqlite";
        const string que_sql = "select * from questions where id = ";
        const string select_answer = "select * from answer where qno = ";
        const string select_all_answer = "select * from answer ";
        const string delete_answer = "delete from answer where qno = ";
        const string delete_all_answer = "delete from answer ";
        //const string insert_answer = "INSERT INTO answer(userid,qno,selected,answer) values(?,?,?,?)";
        //var conn = new SQLiteConnection("Data Source=" + filename + ";Version=3;");

        public static QuestionModel GetQuestionByQno(Int64 qno)
        {
            QuestionModel question = new QuestionModel();

            using (var cn = new SQLiteConnection("Data Source=" + filename + ";Version=3;"))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = que_sql + qno;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine("Field1: {0}", reader[0]);
                            question.qno = Convert.ToInt64(reader["id"]);
                            question.question = (string)reader["question"];
                            question.optA = (string)reader["optA"];
                            question.optB = (string)reader["optB"];
                            question.optC = (string)reader["optC"];
                            question.optD = (string)reader["optD"];
                            question.answer = (string)reader["answer"];
                        }
                    }
                }


                return question;
            }
        }

        public static void SetAnswer(AnswerModel ans)
        {

            //var insert_answer = new SQLiteCommand("INSERT INTO answer(userid,qno,selected,answer) values(@userid,@qno, @selected, @answer)" );

            var param_userid = new SQLiteParameter(DbType.Int64, userid);
            var param_qno = new SQLiteParameter(DbType.Int64, ans.qno);
            var param_selected = new SQLiteParameter(DbType.String) { Value = ans.selected };
            var param_answer = new SQLiteParameter(DbType.String) { Value = ans.answer };

            using (var cn = new SQLiteConnection("Data Source=" + filename + ";Version=3;"))
            {
                cn.Open();

                //check if the question has an answer set....
                bool AnsExist = false;
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = select_answer + ans.qno;
                    var reader = cmd.ExecuteReader();
                    AnsExist = reader.HasRows;

                }


                //execute update or insert deping accordingly
                if (AnsExist)
                {

                    using (var update_answer = new SQLiteCommand(@"UPDATE answer 
                                                               SET selected = ?  WHERE qno = ?", cn))
                    {


                        update_answer.Parameters.Add(param_selected);
                        update_answer.Parameters.Add(param_qno);


                        var affected = update_answer.ExecuteNonQuery();



                    }

                }
                else
                {
                    using (var insert_answer = new SQLiteCommand(@"INSERT INTO answer(userid,qno,selected,answer) 
                                                               VALUES(?,?,?,?)", cn))
                    {
                        insert_answer.Parameters.Add(param_userid);
                        insert_answer.Parameters.Add(param_qno);
                        insert_answer.Parameters.Add(param_selected);
                        insert_answer.Parameters.Add(param_answer);

                        var affected = insert_answer.ExecuteNonQuery();




                    }

                }

            }


        }

        public static void DeleteAnswerByQno(Int64 qno)
        {


            using (var cn = new SQLiteConnection("Data Source=" + filename + ";Version=3;"))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = delete_answer + qno;
                    cmd.ExecuteNonQuery();
                }



            }
        }


        public static void DeleteAllAnswer()
        {

            using (var cn = new SQLiteConnection("Data Source=" + filename + ";Version=3;"))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = delete_all_answer;
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static AnswerModel GetAnswerByQno(Int64 qno)
        {
            AnswerModel answer = new AnswerModel();

            using (var cn = new SQLiteConnection("Data Source=" + filename + ";Version=3;"))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = select_answer + qno;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine("Field1: {0}", reader[0]);
                            answer.qno = Convert.ToInt64(reader["qno"]);
                            answer.answer = Convert.ToString(reader["answer"]);
                            answer.selected = Convert.ToString(reader["selected"]);
                        }
                    }
                }


                return answer;
            }
        }

        public static List<AnswerModel> GetAllAnswer()
        {


            List<AnswerModel> answerList = new List<AnswerModel>();

            using (var cn = new SQLiteConnection("Data Source=" + filename + ";Version=3;"))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = select_all_answer;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AnswerModel answer = new AnswerModel();

                            answer.qno = Convert.ToInt64(reader["qno"]);
                            answer.answer = Convert.ToString(reader["answer"]);
                            answer.selected = Convert.ToString(reader["selected"]);

                            answerList.Add(answer);
                        }
                    }
                }


                return answerList;
            }




        }
    }

}
