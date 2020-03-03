Imports MySql.Data.MySqlClient ' if using mysql
Imports System.Data.SqlClient ' if using mssql
Imports System.Data ' This one is for SqlDataType
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
    Private Sub CreateTable()
        'For mySQL
        Using myCn = New MySqlConnection("Server=myServerAddress;Database=CIS230;Uid=myUsername;Pwd=myPassword;")
            myCn.Open()
            Using myCmd = myCn.CreateCommand()

                myCmd.CommandText = ""
            End Using
        End Using

        'For MsSql
        Using cn = New SqlConnection("Server=localhost\SQLExpress;database=CIS230;Trusted_Connection=True;")
            cn.Open()
            Using cmd = cn.CreateCommand()
                cmd.CommandText = "Create table FortuneCookieSales (ID bigint Primary KEY, 
CustomerName varchar(75) NOT NULL,PhoneNumber varchar(14),Email varchar(50), Cost money NOT NULL, [Count] int NOT NULL)"
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Private Sub FirstRun()
        'For mySQL
        Using myCn = New MySqlConnection("Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;")
            myCn.Open()
            Using myCmd = myCn.CreateCommand()
                'Use a database you already have for mysql.
                myCmd.CommandText = "CREATE DATABASE CIS230"
                myCmd.ExecuteNonQuery()
            End Using
        End Using

        'For MsSql
        Using cn = New SqlConnection("Server=localhost\SQLExpress;database=master;Trusted_Connection=True;")
            cn.Open()
            Using cmd = cn.CreateCommand()
                cmd.CommandText = "CREATE DATABASE CIS230  
                                    ON   
                                    ( NAME = CIS230_dat,  
                                        FILENAME = 'C:\Databases\CIS230.mdf',  
                                        SIZE = 10,  
                                        MAXSIZE = 50,  
                                        FILEGROWTH = 5 )  
                                    LOG ON  
                                    ( NAME = CIS230_log,  
                                        FILENAME = 'C:\Databases\CIS230.ldf',  
                                        SIZE = 5MB,  
                                        MAXSIZE = 25MB,  
                                        FILEGROWTH = 5MB );"
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class
