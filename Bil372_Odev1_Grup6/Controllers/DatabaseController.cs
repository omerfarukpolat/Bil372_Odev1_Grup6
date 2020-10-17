using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Bil372_Odev1_Grup6.Controllers
{
    public class DatabaseController : Controller
    {
       public DatabaseController()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IMECE"].ConnectionString);

            con.Open();

            var cmd = new SqlCommand();
            cmd.Connection = con;


            cmd.CommandText = "DROP TABLE IF EXISTS PRODUCT";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE PRODUCT(
                M_SYSCODE int identity(1,1) NOT NULL PRIMARY KEY,
                M_CODE  VARCHAR(15),
                M_NAME  VARCHAR(25),
                M_SHORTNAME  VARCHAR(10),
                M_PARENTCODE  VARCHAR(15),
                M_ABSTRACT  BINARY,
                M_CATEGORY  VARCHAR(12),
                IS_ACTIVE  BINARY 
                         )";
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table PRODUCT created");


            cmd.CommandText = "DROP TABLE IF EXISTS FEATURES";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE FEATURES(
                FEATURE_ID  int identity(1,1) NOT NULL PRIMARY KEY,
                FEATURE_NAME  VARCHAR(200)
                         )";

            cmd.ExecuteNonQuery();

            Console.WriteLine("Table FEATURES created");


            cmd.CommandText = "DROP TABLE IF EXISTS PRODUCT_FEATURES";
            cmd.ExecuteNonQuery();

  
            cmd.CommandText = @"CREATE TABLE PRODUCT_FEATURES(
                        M_SYSCODE INTEGER,
                        FEATURE_ID INTEGER,
                        MINVAL FLOAT,
                        MAXVAL FLOAT
                         )";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO PRODUCT_FEATURES(M_SYSCODE) SELECT M_SYSCODE FROM PRODUCT";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO PRODUCT_FEATURES(FEATURE_ID) SELECT FEATURE_ID FROM FEATURES";
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table PRODUCT_FEATURES created");


            cmd.CommandText = "DROP TABLE IF EXISTS MANUFACTURERS";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE MANUFACTURERS(
                MANUFACTURER_ID  int identity(1,1) NOT NULL PRIMARY KEY,
                MANUFACTURER_NAME  VARCHAR(200),
                MANUFACTURER_ADDRESS VARCHAR(200),
                CITY INTEGER,
                COUNTRY INTEGER
                         )";

            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO MANUFACTURERS(COUNTRY) SELECT Country_Code FROM COUNTRY ";
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table MANUFACTURERS created");


            cmd.CommandText = "DROP TABLE IF EXISTS PRODUCT_BRANDS";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE PRODUCT_BRANDS(
                       MANUFACTURER_ID INTEGER,
                       M_SYSCODE INTEGER,
                       BRAND_BARCODE CHAR(13),
                       BRAND_NAME VARCHAR(100),
                       primary key(MANUFACTURER_ID, M_SYSCODE)
                         )";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO PRODUCT_BRANDS(MANUFACTURER_ID) SELECT MANUFACTURER_ID FROM MANUFACTURERS";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO PRODUCT_BRANDS(M_SYSCODE) SELECT M_SYSCODE FROM PRODUCT";
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table PRODUCT_BRANDS created");


            cmd.CommandText = "DROP TABLE IF EXISTS ORGANISATIONS";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE ORGANISATIONS(
                    ORG_ID  INTEGER,
                    ORG_NAME VARCHAR(100),
                    PARENT_ORG INTEGER,
                    ORG_ABSTRACT  BINARY ,
                    ORG_ADDRESS  VARCHAR(200),
                    ORG_CITY  INTEGER,
                    ORG_DISTRICT  VARCHAR(50),
                    primary key(ORG_ID, PARENT_ORG)
                         )";
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table ORGANISATIONS created");

            cmd.CommandText = "DROP TABLE IF EXISTS BRAND_ORGS";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE BRAND_ORGS(
                        LOT_ID int identity(1,1),
                        ORG_ID INTEGER,
                        BRAND_BARCODE INTEGER,
                        QUANTITY FLOAT,
                        INNN FLOAT,
                        OUTTTT FLOAT
                        primary key(LOT_ID, ORG_ID, BRAND_BARCODE)
                         )";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "SELECT QUANTITY = isnull(INNN,0) + isnull(OUTTTT,0) FROM BRAND_ORGS";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO BRAND_ORGS(ORG_ID) SELECT ORG_ID FROM ORGANISATIONS";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO BRAND_ORGS(BRAND_BARCODE) SELECT BRAND_BARCODE FROM PRODUCT_BRANDS";
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table BRAND_ORGS created");

            cmd.CommandText = "DROP TABLE IF EXISTS FLOW";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE FLOW(
                        Source_LOT_ID INT,
                        Source_ORG_ID INT, 
                        Target_LOT_ID INT, 
                        Target_ORG_ID INT, 
                        BRAND_BARCODE INT,
                        QUANTITY INT,
                        FlowDate VARCHAR(8),
                        primary key( Source_LOT_ID,
                                    Source_ORG_ID, 
                                    Target_LOT_ID, 
                                    Target_ORG_ID, 
                                    BRAND_BARCODE,
                                     QUANTITY, FlowDate)
                         )";


            cmd.ExecuteNonQuery();
            Console.WriteLine("Table FLOW created");


            cmd.CommandText = "DROP TABLE IF EXISTS ALTERNATIVE_BRANDS";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE ALTERNATIVE_BRANDS(
                            BRAND_BARCODE INT,
                            ALTERNATIVE_BRAND_BARCODE INT
                         )";

            cmd.ExecuteNonQuery();

            Console.WriteLine("Table ALTERNATIVE_BRANDS created");



            cmd.CommandText = "DROP TABLE IF EXISTS COUNTRY";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE COUNTRY(
                          Country_Code  CHAR(3),
                          Country_Name  VARCHAR(50)
                         )";

            cmd.ExecuteNonQuery();

            Console.WriteLine("Table COUNTRY created");




            cmd.CommandText = "DROP TABLE IF EXISTS COUNTRY_CITY";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE COUNTRY_CITY(
                            Country_Code INT,
                            CityID INT,
                            City_Name VARCHAR(100),
                            primary key (Country_Code, City_Name)
                         )";

            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO COUNTRY_CITY(Country_Code) SELECT Country_Code FROM COUNTRY";
            cmd.ExecuteNonQuery();

            Console.WriteLine("Table COUNTRY_CITY created");


        }

    }
}