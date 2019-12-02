using ClassLibraryVbNet;
using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

namespace ConsoleAppCore
{
    class Program
    {
        static void Main(string[] args)
        {
            BuscaPregunta();    
        }

        private static void BuscaPregunta()
        {
            TestClass tc = new TestClass();
            DataTable dtExcel = ExcelToDataTable("C:\\TestData\\BDQuestionProcuraduria.xlsx");
            string pregunta = "¿ Cual es la Capital de Colombia (sin tilde)?";  //"Esta es la pregunta";
            var row = tc.BuscaPregunta(pregunta, dtExcel);
            if (row != null)
            {
                Console.WriteLine(String.Format(" Pregunta: {0} respuesta: {1} ", row[0], row[1]));
            }
            else
            {
                Console.WriteLine(String.Format("Question: {0} was not found", pregunta));
            }
        }

        public static DataTable ExcelToDataTable(string filePath)
        {
            DataTable dtexcel = new DataTable();
            bool hasHeaders = false;
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn;
            if (filePath.Substring(filePath.LastIndexOf('.')).ToLower() == ".xlsx")
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
            else
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            //Looping Total Sheet of Xl File
            /*foreach (DataRow schemaRow in schemaTable.Rows)
            {
            }*/
            //Looping a first Sheet of Xl File
            DataRow schemaRow = schemaTable.Rows[0];
            string sheet = schemaRow["TABLE_NAME"].ToString();
            if (!sheet.EndsWith("_"))
            {
                string query = "SELECT  * FROM [" + sheet + "]";
                OleDbDataAdapter daexcel = new OleDbDataAdapter(query, conn);
                dtexcel.Locale = CultureInfo.CurrentCulture;
                daexcel.Fill(dtexcel);
            }

            conn.Close();
            return dtexcel;

        }
    }
}
