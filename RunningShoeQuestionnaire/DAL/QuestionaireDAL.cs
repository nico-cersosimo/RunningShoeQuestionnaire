using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RunningShoeQuestionaire.Models;
using System.Data.SqlClient;

namespace RunningShoeQuestionaire.DAL
{
    public class QuestionaireDAL : IQuestionaireDAL
    {
        private string ConnString;

        public QuestionaireDAL(string connString)
        {
            ConnString = connString;
        }

        const string SQL_AddQuestionaire = @"INSERT INTO questionaire VALUES (@Terrain, @FootShape, @Design, @Color, @Cost, @Popularity, @BottomShape, @Name); SELECT MAX(questionaireID) FROM questionaire";
        const string SQL_GetQuestionaireByID = @"SELECT * FROM questionaire WHERE questionaireID = @questionaireID";

        public void AddQuestionaire(Questionaire questionaire)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = SQL_AddQuestionaire;
                    cmd.Parameters.AddWithValue("@Terrain", questionaire.Terrain);
                    cmd.Parameters.AddWithValue("@FootShape", questionaire.FootShape);
                    cmd.Parameters.AddWithValue("@Design", questionaire.Design);
                    cmd.Parameters.AddWithValue("@Color", questionaire.Color);
                    cmd.Parameters.AddWithValue("@Cost", questionaire.Cost);
                    cmd.Parameters.AddWithValue("@Popularity", questionaire.Popularity);
                    cmd.Parameters.AddWithValue("@BottomShape", questionaire.BottomShape);
                    cmd.Parameters.AddWithValue("@Name", questionaire.Name);


                    cmd.Connection = conn;
                    questionaire.QuestionaireID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Questionaire GetQuestionaireByID(int questionaireID)
        {
            Questionaire questionaire = new Questionaire();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = SQL_GetQuestionaireByID;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@questionaireID", questionaireID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        questionaire.Terrain = Convert.ToString(reader["Terrain"]);
                        questionaire.FootShape = Convert.ToString(reader["FootShape"]);
                        questionaire.Design = Convert.ToString(reader["Design"]);
                        questionaire.Color = Convert.ToString(reader["Color"]);
                        questionaire.Cost = Convert.ToString(reader["Cost"]);
                        questionaire.Popularity = Convert.ToString(reader["Popularity"]);
                        questionaire.BottomShape = Convert.ToString(reader["BottomShape"]);
                        questionaire.Name = Convert.ToString(reader["Name"]);
                        questionaire.QuestionaireID = Convert.ToInt32(reader["questionaireID"]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return questionaire;
        }
    }
}
