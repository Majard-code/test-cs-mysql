using System;
using MySql.Data.MySqlClient;

namespace CsSQLT1
{
    class ConnectDBT1Class
    {
        public static string cs = "blablabla";
        public static bool ConnectDBT1(string sql)
        {
            MySqlConnection conn = new MySqlConnection(cs);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            try
            {
                Console.WriteLine("Открываем соединение...");
                conn.Open();
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            if(!reader.IsDBNull(1))
                            {
                                Console.WriteLine("{0} - {1}", reader.GetString(0), reader.GetString(1));
                            }
                            else
                            {
                                Console.WriteLine(reader.GetString(0) + " - без категории");
                            }
                        }
                    }
                    reader.Close();
                }

                Console.WriteLine("Операция успешно выполнена.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Возникла ошибка: " + e.Message);
                return false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}