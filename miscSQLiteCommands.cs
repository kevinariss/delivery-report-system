﻿using System.Data.SQLite;
using System.Data;
using System;

namespace Controls
{
    public abstract class miscSQLiteCommands
    {
        private SQLiteConnection dbConnection;
        private SQLiteCommand sqliteCommand;
        private DataTable queryTableResult;

        protected object executeScalar(string sqlStatement)
        {
            try
            {
                connectTodb();
                sqliteCommand = new SQLiteCommand(sqlStatement, dbConnection);
                return sqliteCommand.ExecuteScalar();
            }
            catch
            {
                throw;
            }
            finally
            {
                disconnectFromdb();
            }
        }
        protected SQLiteDataReader executeArrayReader(string sqlStatement)
        {
            try
            {
                connectTodb();
                sqliteCommand = new SQLiteCommand(sqlStatement, dbConnection);
                return sqliteCommand.ExecuteReader();
            }
            catch
            {
                throw;
            }
            finally
            {
                disconnectFromdb();
            }
        }
        protected DataTable executeTableReader(string sqlStatement)
        {
            try
            {
                connectTodb();
                queryTableResult = new DataTable();
                sqliteCommand = new SQLiteCommand(sqlStatement, dbConnection);
                queryTableResult.Load(sqliteCommand.ExecuteReader());
                return queryTableResult;
            }
            catch
            {
                throw;
            }
            finally
            {
                disconnectFromdb();
            }
        }
        protected void executeNonQuery(string sqlStatement)
        {
            try
            {
                connectTodb();
                sqliteCommand = new SQLiteCommand(sqlStatement, dbConnection);
                sqliteCommand.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                disconnectFromdb();
            }
        }
        protected void executeImageWrite(string sqlStatement, byte[] imageData)
        {
            try
            {
                connectTodb();
                sqliteCommand = new SQLiteCommand(sqlStatement, dbConnection);
                sqliteCommand.Parameters.Add("@img", DbType.Binary, imageData.Length);
                sqliteCommand.Parameters["@img"].Value = imageData;
                sqliteCommand.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                disconnectFromdb();
            }
        }
        private void connectTodb()
        {
            try
            {
                dbConnection = sqliteConnection();
                dbConnection.Open();
            }
            catch
            {
                throw;
            }
        }
        private void disconnectFromdb() 
        {
            try
            {
                dbConnection.Close();
                dbConnection = null;
            }
            catch
            {
                throw;
            }
        }
        private SQLiteConnection sqliteConnection()
        {
            return new SQLiteConnection(@"Data Source=D:\Projects\Delivery Report System\Database\SystemDB.db");
        }
    }
}
 