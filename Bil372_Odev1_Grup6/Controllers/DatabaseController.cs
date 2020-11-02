using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace Bil372_Odev1_Grup6.Controllers
{

    public class DatabaseController : Controller
    {
<<<<<<< HEAD
=======
       public DatabaseController()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Uygulama"].ConnectionString);
>>>>>>> f2337aed3bb4ca14dfbd667f08aa187df5b328ac

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IMECE"].ConnectionString);
        
        public DatabaseController(string s)
        {
            con.Open();

            var cmd = new SqlCommand();
            cmd.Connection = con;

          

            cmd.CommandText = "DROP TABLE IF EXISTS PRODUCT";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = @"CREATE TABLE PRODUCT(
                M_SYSCODE int identity(1,1) NOT NULL PRIMARY KEY,
                M_CODE VARCHAR(15) NOT NULL UNIQUE,
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
                        MAXVAL FLOAT,
                        primary key(MINVAL,MAXVAL),
                        FOREIGN KEY(M_SYSCODE) REFERENCES PRODUCT(M_SYSCODE),
                        FOREIGN KEY(FEATURE_ID) REFERENCES FEATURES(FEATURE_ID)
                         )";
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table PRODUCT_FEATURES created");

           
            cmd.CommandText = "DROP TABLE IF EXISTS COUNTRY";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE COUNTRY(
                          Country_Code  CHAR(3) PRIMARY KEY NOT NULL,
                          Country_Name  VARCHAR(50)
                         )";

            cmd.ExecuteNonQuery();

            Console.WriteLine("Table COUNTRY created");
           
            cmd.CommandText = "DROP TABLE IF EXISTS COUNTRY_CITY";
            cmd.ExecuteNonQuery();
           
            cmd.CommandText = @"CREATE TABLE COUNTRY_CITY(
                            Country_Code CHAR(3),
                            CityID INT,
                            City_Name VARCHAR(100),
                            primary key (CityID),
                            FOREIGN KEY(Country_Code) REFERENCES COUNTRY(Country_Code)
                         )";

            cmd.ExecuteNonQuery();

            cmd.CommandText = "DROP TABLE IF EXISTS MANUFACTURERS";
            cmd.ExecuteNonQuery();
           

            cmd.CommandText = @"CREATE TABLE MANUFACTURERS(
                MANUFACTURER_ID  int identity(1,1) NOT NULL PRIMARY KEY,
                MANUFACTURER_NAME  VARCHAR(200),
                MANUFACTURER_ADDRESS VARCHAR(200),
                CITY INTEGER,
                Country_Code CHAR(3),
                FOREIGN KEY(CITY) REFERENCES COUNTRY_CITY(CityID),
                FOREIGN KEY(Country_Code) REFERENCES COUNTRY(Country_Code)
                         )";

            cmd.ExecuteNonQuery();
            Console.WriteLine("Table MANUFACTURERS created");


            cmd.CommandText = "DROP TABLE IF EXISTS PRODUCT_BRANDS";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = @"CREATE TABLE PRODUCT_BRANDS(
                       MANUFACTURER_ID INTEGER,
                       M_SYSCODE INTEGER,
                       BRAND_BARCODE CHAR(13) PRIMARY KEY,
                       BRAND_NAME VARCHAR(100),
                       FOREIGN KEY(MANUFACTURER_ID) REFERENCES MANUFACTURERS(MANUFACTURER_ID),
                       FOREIGN KEY(M_SYSCODE) REFERENCES PRODUCT(M_SYSCODE)
                         )";
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
                    ORG_TYPE BINARY CHECK (ORG_TYPE<=2),
                    primary key(ORG_ID, PARENT_ORG)
                         )";
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table ORGANISATIONS created");


            cmd.CommandText = "DROP TABLE IF EXISTS BRAND_ORGS";
            cmd.ExecuteNonQuery();

           
            cmd.CommandText = @"CREATE TABLE BRAND_ORGS(
                        LOT_ID int identity(1,1) PRIMARY KEY,
                        ORG_ID INTEGER,
                        BRAND_BARCODE CHAR(13),
                        QUANTITY FLOAT,
                        INNN FLOAT,
                        OUTTTT FLOAT,
                        FOREIGN KEY(ORG_ID) REFERENCES ORGANISATIONS(ORG_ID),
                        FOREIGN KEY(BRAND_BARCODE) REFERENCES PRODUCT_BRANDS(BRAND_BARCODE)
                         )";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "SELECT QUANTITY = isnull(INNN,0) + isnull(OUTTTT,0) FROM BRAND_ORGS";
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
                        FlowDate DATE,
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
                            BRAND_BARCODE CHAR(13),
                            M_SYSCODE INT,
                            ALTERNATIVE_BRAND_BARCODE CHAR(13),
                            ALTERNATIVE_M_SYSCODE INT
                         )";

            cmd.ExecuteNonQuery();

            Console.WriteLine("Table ALTERNATIVE_BRANDS created");


        }
        public DatabaseController()
        {
            con.Open();

            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO COUNTRY_CITY(Country_Code) SELECT Country_Code FROM COUNTRY";
            cmd.ExecuteNonQuery();

            Console.WriteLine("Table COUNTRY_CITY created");

            cmd.CommandText = "INSERT INTO PRODUCT(M_CODE,M_NAME, M_SHORTNAME, M_PARENTCODE, M_ABSTRACT, M_CATEGORY, IS_ACTIVE) " +
                "VALUES (123,'ESYA','ESY', 000, CAST('1' AS VARBINARY), 'ESYA', CAST('1' AS VARBINARY))";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO PRODUCT(M_CODE,M_NAME, M_SHORTNAME, M_PARENTCODE, M_ABSTRACT, M_CATEGORY, IS_ACTIVE) " +
                "VALUES (1231,'GIYECEK','GIY', 123, CAST('1' AS VARBINARY), 'GIYIM', CAST('1' AS VARBINARY))";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO PRODUCT(M_CODE,M_NAME, M_SHORTNAME, M_PARENTCODE, M_ABSTRACT, M_CATEGORY, IS_ACTIVE) " +
                "VALUES (12311,'UST GIYIM','USTGIY', 1231, CAST('1' AS VARBINARY), 'GIYIM', CAST('1' AS VARBINARY))";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO PRODUCT(M_CODE,M_NAME, M_SHORTNAME, M_PARENTCODE, M_ABSTRACT, M_CATEGORY, IS_ACTIVE) " +
                "VALUES ('123111','KIRAVAT','KIR', 12311 , CAST('1' AS VARBINARY), 'GIYIM', CAST('1' AS VARBINARY))";
            cmd.ExecuteNonQuery();


            cmd.CommandText = "INSERT INTO FEATURES(FEATURE_NAME)" +
                "VALUES ('AGIRLIK')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO FEATURES(FEATURE_NAME)" +
                "VALUES ('BOY')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO FEATURES(FEATURE_NAME)" +
               "VALUES ('GENISLIK')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO FEATURES(FEATURE_NAME)" +
               "VALUES ('NEM')";
            cmd.ExecuteNonQuery();


            cmd.CommandText = "INSERT INTO PRODUCT_FEATURES(M_SYSCODE, FEATURE_ID, MINVAL,MAXVAL)" +
                "VALUES (4,1,30,30)";
            cmd.ExecuteNonQuery();
         

        }

        public string getProduct()
        {
            string s = "";
            string sql = "SELECT * FROM PRODUCT";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                s += rdr.GetInt32(0) + " " + rdr.GetString(1) + " " + rdr.GetString(2) + " " +
                    rdr.GetString(3) + " " + rdr.GetString(4) + " " + rdr.GetSqlBinary(5) + " " + rdr.GetString(6) + " "
                    + rdr.GetSqlBinary(7);
                System.Diagnostics.Debug.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", rdr.GetInt32(0), rdr.GetString(1),
                    rdr.GetString(2),
                    rdr.GetString(3), rdr.GetString(4),
                       rdr.GetSqlBinary(5), rdr.GetString(6), rdr.GetSqlBinary(7));
            }
            return s;
        }
        public string getFeatures()
        {
            string s = "";
            string sql = "SELECT * FROM FEATURES";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                s += rdr.GetInt32(0) + " " + rdr.GetString(1);
                System.Diagnostics.Debug.WriteLine("{0} {1}", rdr.GetInt32(0), rdr.GetString(1));
            }
            return s;
        }
        public string getFeatureProducts()
        {
            List<Int32> list = new List<Int32>();
            string s = "";
            string sql = "SELECT * FROM PRODUCT_FEATURES";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                s += rdr.GetInt32(0) + " " + rdr.GetInt32(1) + " " + rdr.GetFloat(2) + " " +
                    rdr.GetFloat(3);
                System.Diagnostics.Debug.WriteLine("{0} {1} {2} {3}", rdr.GetInt32(0), rdr.GetString(1),
                    rdr.GetString(2),
                    rdr.GetString(3));
            }
            return s;
        }
        public string getCountry()
        {
            string s = "";
            string sql = "SELECT * FROM COUNTRY";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                s += rdr.GetString(0) + " " + rdr.GetString(1);
                System.Diagnostics.Debug.WriteLine("{0} {1} ", rdr.GetString(0),
                    rdr.GetString(1));
            }
            return s;
        }
        public string getCountryCity()
        {
            string s = "";
            string sql = "SELECT * FROM COUNTRY_CITY";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                s += rdr.GetString(0) + " " + rdr.GetInt32(1) + " " + rdr.GetString(2);
                System.Diagnostics.Debug.WriteLine("{0} {1} {2} ", rdr.GetString(0),
                    rdr.GetString(1), rdr.GetString(2));
            }
            return s;
        }
        public string getManufacturers()
        {
            string s = "";
            string sql = "SELECT * FROM MANUFACTURERS";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                s += rdr.GetInt32(0) + " " + rdr.GetString(1) + " " + rdr.GetString(2) + " " +
                    rdr.GetInt32(3) + " " + rdr.GetString(4);
                System.Diagnostics.Debug.WriteLine("{0} {1} {2} {3} {4}", rdr.GetInt32(0), rdr.GetString(1),
                    rdr.GetString(2),
                    rdr.GetInt32(3), rdr.GetString(4));
            }
            return s;
        }
        public string getProductBrands()
        {
            List<Int32> list = new List<Int32>();
            string s = "";
            string sql = "SELECT * FROM PRODUCT_BRANDS";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                s += rdr.GetInt32(0) + " " + rdr.GetInt32(1) + " " + rdr.GetString(2) + " " +
                    rdr.GetString(3);
                System.Diagnostics.Debug.WriteLine("{0} {1} {2} {3}", rdr.GetInt32(0), rdr.GetInt32(1),
                    rdr.GetString(2),
                    rdr.GetString(3));
            }
            return s;
        }
        public string getOrganisations()
        {
            List<Int32> list = new List<Int32>();
            string s = "";
            string sql = "SELECT * FROM ORGANISATIONS";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(rdr.GetInt32(0));
                s += rdr.GetInt32(0) + " " + rdr.GetString(1) + " " + rdr.GetInt32(2) + " " +
                    rdr.GetSqlBinary(3) + " " + rdr.GetString(4) + " " + rdr.GetInt32(5) + " " + rdr.GetSqlBinary(6);
                System.Diagnostics.Debug.WriteLine("{0} {1} {2} {3} {4} {5} {6}", rdr.GetInt32(0), rdr.GetString(1),
                    rdr.GetInt32(2),
                    rdr.GetSqlBinary(3), rdr.GetString(4),
                       rdr.GetInt32(5), rdr.GetSqlBinary(6));
            }
            return s;
        }
        public string getBrandOrgs()
        {
            string s = "";
            string sql = "SELECT * FROM BRAND_ORGS";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                s += rdr.GetInt32(0) + " " + rdr.GetInt32(1) + " " + rdr.GetInt32(2) + " " +
                    rdr.GetFloat(3) + " " + rdr.GetFloat(4) + " " + rdr.GetFloat(5);
                System.Diagnostics.Debug.WriteLine("{0} {1} {2} {3} {4} {5}", rdr.GetInt32(0), rdr.GetInt32(1),
                    rdr.GetInt32(2),
                    rdr.GetFloat(3), rdr.GetFloat(4),
                       rdr.GetFloat(5));
            }
            return s;
        }
        public string getFlow()
        {
            string s = "";
            string sql = "SELECT * FROM FLOW";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                s += rdr.GetInt32(0) + " " + rdr.GetInt32(1) + " " + rdr.GetInt32(2) + " " +
                    rdr.GetInt32(3) + " " + rdr.GetInt32(4) + " " + rdr.GetInt32(5) + " " + rdr.GetInt32(6) + " "
                    + rdr.GetSqlDateTime(7);
                System.Diagnostics.Debug.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", rdr.GetInt32(0), rdr.GetInt32(1),
                    rdr.GetInt32(2),
                    rdr.GetInt32(3), rdr.GetInt32(4),
                       rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetSqlDateTime(7));
            }
            return s;
        }
        public string getAlternativeBrands()
        {
            string s = "";
            string sql = "SELECT * FROM ALTERNATIVE_BRANDS";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                s += rdr.GetInt32(0) + " " + rdr.GetInt32(1);
                System.Diagnostics.Debug.WriteLine("{0} {1}", rdr.GetInt32(0), rdr.GetInt32(1));
            }
            return s;
        }
        public void insertProduct(string code, string name, string shortname, int parentcode,bool isAbstract, string category, bool isActive){
            string s = "INSERT INTO PRODUCT(M_CODE, M_NAME, M_SHORTNAME, M_PARENTCODE, M_ABSTRACT, M_CATEGORY, IS_ACTIVE) " +
                "VALUES (" + code + "," + name + "," + shortname + "," + parentcode + "," +
                isAbstract + "," + category + "," + isActive + ")";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertFeatures(string featureName)
        {
            string s = "INSERT INTO FEATURES(FEATURE_NAME) " +
                "VALUES (" + featureName + ")";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertProductFeatures(int syscode, int featureid, float minval, float maxval)
        {
            string s = "INSERT INTO PRODUCT_FEATURES(M_SYSCODE, FEATURE_ID, MINVAL, MAXVAL) " +
                "VALUES (" + syscode + "," + featureid + "," + minval + "," + maxval + ")";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertCountry(string countryCode, string countryName)
        {
            string s = "INSERT INTO COUNTRY(Country_Code, Country_Name) " +
                "VALUES (" + countryCode + "," + countryName + ")";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertCountryCity(string countryCode, int cityid, string cityName)
        {
            string s = "INSERT INTO COUNTRY_CITY(Country_Code, CityID,City_Name) " +
                "VALUES (" + countryCode + "," + cityid + "," + cityName + ")";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertManufacturers(string manufacturerName, string address, int city, string countryCode)
        {
            string s = "INSERT INTO MANUFACTURERS(MANUFACTURER_NAME, MANUFACTURER_ADDRESS, CITY, Country_Code) " +
                "VALUES (" + manufacturerName + "," + address + "," + city + "," + countryCode + ")";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertProductBrands(int manufacturerid, int syscode, string brandBarcode, string brandName)
        {
            string s = "INSERT INTO PRODUCT_BRANDS(MANUFACTURER_ID, M_SYSCODE, BRAND_BARCODE, BRAND_NAME) " +
                "VALUES (" + manufacturerid + "," + syscode + "," + brandBarcode + "," + brandName + ")";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertOrganisations(int orgid, string name, int parentOrg, bool isAbstract, string address, int orgType)
        {
            string s = "INSERT INTO ORGANISATIONS(ORG_ID, ORG_NAME, PARENT_ORG, ORG_ABSTRACT, ORG_ADDRESS, ORG_CITY, ORG_TYPE) " +
                "VALUES (" + orgid + "," + name + "," + parentOrg + "," + isAbstract + "," +
                address + "," + Convert.ToInt32(orgType) + ")";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertBrandOrgs(int orgid, int brandBarcode, float quantity, float innn, float outttt)
        {
            string s = "INSERT INTO BRAND_ORGS(ORG_ID, BRAND_BARCODE, QUANTITY, INNN, OUTTTT) " +
                "VALUES (" + orgid + "," + brandBarcode + "," + quantity + "," + innn + "," +
                outttt + ")";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertAlternativeBrands(int brandBarcode, int syscode, float altBrandBarcode, float altSysCode)
        {
            string s = "INSERT INTO ALTERNATIVE_BRANDS(BRAND_BARCODE, M_SYSCODE, ALTERNATIVE_BRAND_BARCODE, ALTERNATIVE_M_SYSCODE) " +
                "VALUES (" + brandBarcode + "," + syscode + "," + altBrandBarcode + "," + altSysCode + ")";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateProduct(int syscode, string code, string name, string shortname, int parentcode, bool isAbstract, string category, bool isActive)
        {
            string s = "UPDATE PRODUCT SET M_CODE = " + code + "," + " M_NAME =" + name + "," + " M_SHORTNAME = " + shortname + ","
                    + " M_PARENTCODE =" + parentcode + "," + " M_ABSTRACT= " + isAbstract + "," + " M_CATEGORY = " + category
                    + "," + " IS_ACTIVE = " + isActive +
                    " WHERE M_SYSCODE=" + syscode;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateFeatures(int featureid, string name)
        {
            string s = "UPDATE FEATURES SET FEATURE_NAME = " + name +
                    " WHERE FEATURE_ID=" + featureid;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateProductFeatures(int syscode, int featureid, float minval, float maxval)
        {
            string s = "UPDATE PRODUCT_FEATURES SET MINVAL = " + minval + "," + " MAXVAL =" + maxval +
                    " WHERE M_SYSCODE=" + syscode + "AND FEATURE_ID = " + featureid;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateCountry(string countryCode, string countryName)
        {
            string s = "UPDATE COUNTRY SET Country_Name =" + countryName +
                    " WHERE Country_Code=" + countryCode;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateCountryCity(string countryCode, int cityid, string cityName)
        {
            string s = "UPDATE COUNTRY_CITY SET City_Name = " + cityName +
                    " WHERE Country_Code=" + countryCode + " AND CityID=" + cityid;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateManufacturers(int manufacturerid, int city, string countryCode, string name, string address)
        {
            string s = "UPDATE MANUFACTURERS SET MANUFACTURER_NAME = " + name + "," + " MANUFACTURER_ADDRESS =" + address
                   + " WHERE MANUFACTURER_ID=" + manufacturerid + " AND CITY = " + city + " AND Counrty_Code = " + countryCode;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateProductBrands(int manufacturerid, int syscode, string brandBarcode, string brandname)
        {
            string s = "UPDATE PRODUCT_BRANDS SET BRAND_NAME =" + brandname +
                    " WHERE M_SYSCODE=" + syscode + " AND MANUFACTURER_ID = " + manufacturerid + " AND BRAND_BARCODE = " + brandBarcode; ;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateOrganisations(int orgid, string orgName, int parentOrg, bool isAbstract, string address, int city, int orgType)
        {
            string s = "UPDATE ORGANISATIONS SET ORG_NAME = " + orgName + "," + " ORG_ABSTRACT =" + isAbstract + "," + " ORG_ADDRESS = " + address + ","
                    + " ORG_CITY =" + city + "," + " ORG_TYPE = " +
                    " WHERE ORG_ID=" + orgid + " AND PARENT_ORG = " + parentOrg;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateBrandOrgs(int lotid, int orgid, string brandBarcode, float innn, float outttt)
        {
            string s = "UPDATE BRAND_ORGS SET INNN = " + innn + "," + " OUTTTT =" + outttt + "," + " QUANTITY = " + (innn + outttt) +
                    " WHERE LOT_ID=" + lotid + " AND ORG_ID = " + orgid + " AND BRAND_BARCODE = " + brandBarcode;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateAlternativeBrands(string brandBarcode, int syscode, string altBrandBarcode, int altSysCode)
        {
            string s = "UPDATE ALTERNATIVE_BRANDS SET BRAND_BARCODE = " + brandBarcode + " , M_SYSCODE =" + syscode + " , ALTERNATIVE_BRAND_BARCODE = " + altBrandBarcode +
                    " , ALTERNATIVE_M_SYSCODE=" + altSysCode;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void deleteFromProduct(int syscode)
        {
            string s = "DELETE FROM PRODUCT WHERE M_SYSCODE =" + syscode;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void deleteFromFeatures(int featureid)
        {
            string s = "DELETE FROM FEATURES WHERE FEATURE_ID =" + featureid;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void deleteFromProductFeatures(int syscode, int featureid)
        {
            string s = "DELETE FROM FEATURES WHERE FEATURE_ID =" + featureid + " AND M_SYSCODE = " + syscode;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void deleteFromCountry(string countryCode)
        {
            string s = "DELETE FROM COUNTRY WHERE Country_Code =" + countryCode;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void deleteFromCountryCity(string countryCode, int cityid)
        {
            string s = "DELETE FROM COUNTRY_CITY WHERE Country_Code =" + countryCode + " AND CityID = " + cityid;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void deleteFromManufacturers(int manufacturerid)
        {
            string s = "DELETE FROM MANUFACTURERS WHERE MANUFACTURER_ID =" + manufacturerid;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void deleteFromProductBrands(int manufacturerid, int syscode, string brandBarcode)
        {
            string s = "DELETE FROM PRODUCT_BRANDS WHERE MANUFACTURER_ID =" + manufacturerid + " AND M_SYSCODE=" + syscode +
                " AND BRAND_BARCODE = " + brandBarcode;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }


    }
         

}