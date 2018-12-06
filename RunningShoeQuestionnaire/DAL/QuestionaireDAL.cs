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

        const string SQL_AddQuestionaire = @"INSERT INTO questionaire VALUES (@Terrain, @FootShape, @Design, @Color, @Cost, @Popularity, @BottomShape, @Name)";
        const string SQL_GetLatestQuestionaire = @"SELECT TOP 1 * FROM questionaire ORDER BY questionaireID DESC";

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
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Questionaire GetLatestQuestionaire()
        {
            Questionaire latestQuestionaire = new Questionaire();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = SQL_GetLatestQuestionaire;
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        latestQuestionaire.Terrain = Convert.ToString(reader["Terrain"]);
                        latestQuestionaire.FootShape = Convert.ToString(reader["FootShape"]);
                        latestQuestionaire.Design = Convert.ToString(reader["Design"]);
                        latestQuestionaire.Color = Convert.ToString(reader["Color"]);
                        latestQuestionaire.Cost = Convert.ToString(reader["Cost"]);
                        latestQuestionaire.Popularity = Convert.ToString(reader["Popularity"]);
                        latestQuestionaire.BottomShape = Convert.ToString(reader["BottomShape"]);
                        latestQuestionaire.Name = Convert.ToString(reader["Name"]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return latestQuestionaire;
        }
    }
}
