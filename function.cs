using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Appraisal.Controllers
{
    public static class QuestionnaireResponseGetFunction
    {
        [FunctionName("QuestionnaireResponseGetFunction")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "questionnaireresponse")]
            HttpRequest req,
            ILogger log)
        {
            try
            {
                string connectionString = Environment.GetEnvironmentVariable("Server=tcp:luckyrash.database.windows.net,1433;Initial Catalog=lucky;Persist Security Info=False;User ID=luckyrash;Password=pass@12345678;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                List<QuestionnaireResponse> questionnaireResponses = RetrieveQuestionnaireResponses(connectionString);

                return new OkObjectResult(questionnaireResponses);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        private static List<QuestionnaireResponse> RetrieveQuestionnaireResponses(string connectionString)
        {
            List<QuestionnaireResponse> questionnaireResponses = new List<QuestionnaireResponse>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM QuestionnaireResponse";
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    questionnaireResponses.Add(new QuestionnaireResponse
                    {
                        Id = reader.GetInt32(0),
                        EmployeeId = reader.GetInt32(1),
                        EmployeeName = reader.GetString(2),
                        Question1 = reader.GetInt32(3),
                        Question2 = reader.GetInt32(4),
                        Question3 = reader.GetInt32(5),
                        Question4 = reader.GetInt32(6),
                        Question5 = reader.GetInt32(7),
                        Question6 = reader.GetInt32(8),
                        Question7 = reader.GetInt32(9),
                        Question8 = reader.GetInt32(10),
                        Question9 = reader.GetInt32(11),
                        Question10 = reader.GetInt32(12),
                        TotalValue = reader.GetInt32(13)
                    });
                }

                reader.Close();
            }

            return questionnaireResponses;
        }
    }
}
