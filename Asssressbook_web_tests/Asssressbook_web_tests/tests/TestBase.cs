using System;
using System.Text;
using NUnit.Framework;


namespace Addressbook_web_tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHEKS = true; // отключаемая проверка, которая выполняется после каждого теста, и проверяет, что данные в пользовательском интерфейсе согласуются с тем, что получено из базы данных.



        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {

            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append((char)rnd.Next(28, 127) + (char)rnd.Next(21, 27)); //для генерации строк без ', для проверки бага оставил тест соответствующий
                                                                                  // builder.Append(Convert.ToChar(32+Convert.ToInt32(rnd.NextDouble()*65)));
            }
            return builder.ToString();
        }


    }
}