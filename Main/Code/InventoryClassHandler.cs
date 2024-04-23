using Main.Libraries;
using System;
using System.Data.SQLite;

namespace Main.Code
{
    public class InventoryClassHandler
    {
        public void InsertItemToInventory(SQLiteHandler sQLiteHandler, Item item)
        {
            sQLiteHandler.connection.Open();
            string commandString = "INSERT INTO inventory () " +
                "VALUES ()";
            SQLiteCommand command = new SQLiteCommand(commandString, sQLiteHandler.connection);

            /*command.Parameters.AddWithValue("@FirstName", client.FirstName);
           
              */
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                sQLiteHandler.connection.Close();
            }
        }
    }
}
