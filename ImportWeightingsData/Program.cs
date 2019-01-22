using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportWeightingsData
{
    class Program
    {
        static void Main(string[] args)
        {
            const int fromSort = 0;
            const int toSort = 1;
            const int method = 2;
            const int weighting1 = 3;
            const int weighting2 = 4;
            const int weighting3 = 5;
            const int weighting4 = 6;
            const int weighting5 = 7;
            const int weighting6 = 8;
            const int weighting7 = 9;
            const int weighting8 = 10;
            const int weighting9 = 11;
            const int weighting10 = 12;
            const int weighting11 = 13;
            const int weighting12 = 14;
            const int weighting13 = 15;
            const int weighting14 = 16;
            const int exception = 17;

            using (var stream = File.OpenText("valacdos.txt"))
            {
                var connection = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=Modulus;Integrated Security=True;");
                var insertWeightCommand = new SqlCommand(
                    "INSERT INTO Weightings (SortCodeFrom, SortCodeTo, Method, WeightingDigit1, WeightingDigit2, WeightingDigit3, WeightingDigit4, WeightingDigit5, WeightingDigit6, WeightingDigit7, WeightingDigit8, WeightingDigit9, WeightingDigit10, WeightingDigit11, WeightingDigit12, WeightingDigit13, WeightingDigit14, Exception) VALUES(@FromSort, @ToSort, @Method, @weighting1, @weighting2, @weighting3, @weighting4, @weighting5, @weighting6, @weighting7, @weighting8, @weighting9, @weighting10, @weighting11, @weighting12, @weighting13, @weighting14, @exception)",
                    connection) {CommandType = CommandType.Text};
                connection.Open();
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    var parts = line.Split(' ');
                    var partsWithoutBlanks = parts.Where(l => l != "").ToArray();
                    insertWeightCommand.Parameters.Clear();
                    insertWeightCommand.Parameters.AddWithValue("@FromSort", partsWithoutBlanks[fromSort]);
                    insertWeightCommand.Parameters.AddWithValue("@ToSort", partsWithoutBlanks[toSort]);
                    insertWeightCommand.Parameters.AddWithValue("@Method", partsWithoutBlanks[method]);
                    insertWeightCommand.Parameters.AddWithValue("@Weighting1", int.Parse(partsWithoutBlanks[weighting1]));
                    insertWeightCommand.Parameters.AddWithValue("@Weighting2", int.Parse(partsWithoutBlanks[weighting2]));
                    insertWeightCommand.Parameters.AddWithValue("@Weighting3", int.Parse(partsWithoutBlanks[weighting3]));
                    insertWeightCommand.Parameters.AddWithValue("@Weighting4", int.Parse(partsWithoutBlanks[weighting4]));
                    insertWeightCommand.Parameters.AddWithValue("@Weighting5", int.Parse(partsWithoutBlanks[weighting5]));
                    insertWeightCommand.Parameters.AddWithValue("@Weighting6", int.Parse(partsWithoutBlanks[weighting6]));
                    insertWeightCommand.Parameters.AddWithValue("@Weighting7", int.Parse(partsWithoutBlanks[weighting7]));
                    insertWeightCommand.Parameters.AddWithValue("@Weighting8", int.Parse(partsWithoutBlanks[weighting8]));
                    insertWeightCommand.Parameters.AddWithValue("@Weighting9", int.Parse(partsWithoutBlanks[weighting9]));
                    insertWeightCommand.Parameters.AddWithValue("@Weighting10", int.Parse(partsWithoutBlanks[weighting10]));
                    insertWeightCommand.Parameters.AddWithValue("@Weighting11", int.Parse(partsWithoutBlanks[weighting11]));
                    insertWeightCommand.Parameters.AddWithValue("@Weighting12", int.Parse(partsWithoutBlanks[weighting12]));
                    insertWeightCommand.Parameters.AddWithValue("@Weighting13", int.Parse(partsWithoutBlanks[weighting13]));
                    insertWeightCommand.Parameters.AddWithValue("@Weighting14", int.Parse(partsWithoutBlanks[weighting14]));
                    insertWeightCommand.Parameters.AddWithValue("@exception", exception >= partsWithoutBlanks.Length ? DBNull.Value : (object)partsWithoutBlanks[exception]);

                    insertWeightCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
