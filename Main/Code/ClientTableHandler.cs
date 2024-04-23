using Main.Libraries;
using System;
using System.Data.SQLite;

namespace Main.Code
{
    public class ClientTableHandler
    {
        public static void InsertClientToClients(SQLiteHandler sQLiteHandler, Client client)
        {
            sQLiteHandler.connection.Open();
            string commandString = "INSERT INTO clients (FirstName, " +
                "LastName, Phone, Email, Address) " +
                "VALUES (@FirstName, @LastName, @Phone, @Email, @Address)";
            SQLiteCommand command = new SQLiteCommand(commandString, sQLiteHandler.connection);

            command.Parameters.AddWithValue("@FirstName", client.FirstName);
            command.Parameters.AddWithValue("@LastName", client.LastName);
            command.Parameters.AddWithValue("@Phone", client.Phone);
            command.Parameters.AddWithValue("@Email", client.Email);
            command.Parameters.AddWithValue("@Address", client.Address);

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
        public static void UpdateClientFromClients(SQLiteHandler sQLiteHandler, Client newClient)
        {
            sQLiteHandler.connection.Open();
            string commandString = "UPDATE clients SET FirstName=@FirstName, " +
                "LastName=@LastName, Phone=@Phone, Email=@Email, Address=@Address WHERE ID=@ID";

            SQLiteCommand command = new SQLiteCommand(commandString, sQLiteHandler.connection);
            command.Parameters.AddWithValue("@ID", newClient.id);
            command.Parameters.AddWithValue("@FirstName", newClient.FirstName);
            command.Parameters.AddWithValue("@LastName", newClient.LastName);
            command.Parameters.AddWithValue("@Phone", newClient.Phone);
            command.Parameters.AddWithValue("@Email", newClient.Email);
            command.Parameters.AddWithValue("@Address", newClient.Address);
            try
            {
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally { sQLiteHandler.connection.Close(); }

        }
        public static void DeleteClientFromClients(SQLiteHandler sQLiteHandler, int id)
        {
            sQLiteHandler.connection.Open();
            string commandString = "DELETE FROM clients WHERE ID=@ID";
            SQLiteCommand command = new SQLiteCommand(commandString, sQLiteHandler.connection);
            command.Parameters.AddWithValue("@ID", id);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally { sQLiteHandler.connection.Close(); }
        }

    }
}
