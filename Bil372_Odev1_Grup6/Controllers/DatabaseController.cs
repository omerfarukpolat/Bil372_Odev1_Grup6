using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Management;
using System.Web.Mvc;
using Bil372_Odev1_Grup6.Models;
namespace Bil372_Odev1_Grup6.Controllers
{

    public class DatabaseController : Controller
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IMECE"].ConnectionString);

        public DatabaseController(char a)
        {
            con.Open();

            var cmd = new SqlCommand();
            cmd.Connection = con;


            cmd.CommandText = "DROP TABLE IF EXISTS ALTERNATIVE_BRANDS";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DROP TABLE IF EXISTS FLOW";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DROP TABLE IF EXISTS BRAND_ORGS";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DROP TABLE IF EXISTS ORGANISATIONS";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DROP TABLE IF EXISTS PRODUCT_BRANDS";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DROP TABLE IF EXISTS MANUFACTURERS";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DROP TABLE IF EXISTS COUNTRY_CITY";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DROP TABLE IF EXISTS COUNTRY";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DROP TABLE IF EXISTS PRODUCT_FEATURES";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DROP TABLE IF EXISTS FEATURES";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DROP TABLE IF EXISTS PRODUCT";
            cmd.ExecuteNonQuery();
        }
        public DatabaseController(int a)
        {
            con.Open();

            var cmd = new SqlCommand();
            cmd.Connection = con;



            cmd.CommandText = @"CREATE TABLE PRODUCT(
                M_SYSCODE int identity(1,1) NOT NULL PRIMARY KEY,
                M_CODE VARCHAR(15) NOT NULL UNIQUE,
                M_NAME  VARCHAR(25),
                M_SHORTNAME  VARCHAR(10),
                M_PARENTCODE  VARCHAR(15),
                M_ABSTRACT  BIT,
                M_CATEGORY  VARCHAR(12),
                IS_ACTIVE  BIT 
                         )";

            cmd.ExecuteNonQuery();
            Console.WriteLine("Table PRODUCT created");

            cmd.CommandText = @"CREATE TABLE FEATURES(
                FEATURE_ID  int identity(1,1) NOT NULL PRIMARY KEY,
                FEATURE_NAME  VARCHAR(200)
                         )";

            cmd.ExecuteNonQuery();

            Console.WriteLine("Table FEATURES created");



            cmd.CommandText = @"CREATE TABLE PRODUCT_FEATURES(
                        M_SYSCODE INTEGER,
                        FEATURE_ID INTEGER,
                        MINVAL FLOAT,
                        MAXVAL FLOAT,
                        primary key(MINVAL,MAXVAL),
                        FOREIGN KEY(M_SYSCODE) REFERENCES PRODUCT(M_SYSCODE) ON DELETE CASCADE,
                        FOREIGN KEY(FEATURE_ID) REFERENCES FEATURES(FEATURE_ID)
                         )";
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table PRODUCT_FEATURES created");


            cmd.CommandText = @"CREATE TABLE COUNTRY(
                          Country_Code  CHAR(3) PRIMARY KEY NOT NULL,
                          Country_Name  VARCHAR(50)
                         )";

            cmd.ExecuteNonQuery();

            Console.WriteLine("Table COUNTRY created");


            cmd.CommandText = @"CREATE TABLE COUNTRY_CITY(
                            Country_Code CHAR(3),
                            CityID INT identity(1,1) NOT NULL PRIMARY KEY,
                            City_Name VARCHAR(100),
                            FOREIGN KEY(Country_Code) REFERENCES COUNTRY(Country_Code) ON DELETE CASCADE
                         )";

            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO COUNTRY(Country_Code , Country_Name) " +
                            "VALUES('DEU','Almanya')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO COUNTRY(Country_Code , Country_Name) " +
                              "VALUES('USA','Amerika')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO COUNTRY(Country_Code , Country_Name) " +
                              "VALUES('DNK','Danimarka')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO COUNTRY(Country_Code , Country_Name) " +
                              "VALUES('FRA','Fransa')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO COUNTRY(Country_Code , Country_Name) " +
                               "VALUES('TUR','Türkiye')";
            cmd.ExecuteNonQuery();

            //Ýnsert CountryCity
            cmd.CommandText = "INSERT INTO COUNTRY_CITY(Country_Code , City_Name) " +
                               "VALUES('DEU','Berlin')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO COUNTRY_CITY(Country_Code , City_Name) " +
                               "VALUES('DEU','Münih')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO COUNTRY_CITY(Country_Code , City_Name) " +
                               "VALUES('USA','New York')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO COUNTRY_CITY(Country_Code , City_Name) " +
                               "VALUES('USA','Boston')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO COUNTRY_CITY(Country_Code , City_Name) " +
                               "VALUES('DNK','Kopenhag')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO COUNTRY_CITY(Country_Code , City_Name) " +
                               "VALUES('DNK','Odense')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO COUNTRY_CITY(Country_Code , City_Name) " +
                               "VALUES('FRA','Paris')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO COUNTRY_CITY(Country_Code , City_Name) " +
                               "VALUES('FRA','Nice')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO COUNTRY_CITY(Country_Code , City_Name) " +
                               "VALUES('TUR','Ankara')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO COUNTRY_CITY(Country_Code , City_Name) " +
                               "VALUES('TUR','Ýstanbul')";
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


            cmd.CommandText = @"CREATE TABLE PRODUCT_BRANDS(
                       MANUFACTURER_ID INTEGER,
                       M_SYSCODE INTEGER,
                       BRAND_BARCODE CHAR(13) PRIMARY KEY,
                       BRAND_NAME VARCHAR(100),
                       FOREIGN KEY(MANUFACTURER_ID) REFERENCES MANUFACTURERS(MANUFACTURER_ID) ON DELETE CASCADE,
                       FOREIGN KEY(M_SYSCODE) REFERENCES PRODUCT(M_SYSCODE)
                         )";
            cmd.ExecuteNonQuery();

            Console.WriteLine("Table PRODUCT_BRANDS created");



            cmd.CommandText = @"CREATE TABLE ORGANISATIONS(
                    ORG_ID INTEGER identity(1,1) PRIMARY KEY,
                    ORG_NAME VARCHAR(100),
                    PARENT_ORG INTEGER,
                    ORG_ABSTRACT  BIT ,
                    ORG_ADDRESS  VARCHAR(200),
                    ORG_CITY  INTEGER,
                    ORG_DISTRICT VARCHAR(50),
                    ORG_TYPE INT CHECK (ORG_TYPE<=2),
                         )";
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table ORGANISATIONS created");



            cmd.CommandText = @"CREATE TABLE BRAND_ORGS(
                        LOT_ID int identity(1,1) PRIMARY KEY,
                        ORG_ID INTEGER,
                        BRAND_BARCODE CHAR(13),
                        UNIT FLOAT,
                        BASEPRICE FLOAT,
                        QUANTITY FLOAT,
                        INNN FLOAT,
                        OUTTTT FLOAT,
                        FOREIGN KEY(ORG_ID) REFERENCES ORGANISATIONS(ORG_ID) ON DELETE CASCADE,
                        FOREIGN KEY(BRAND_BARCODE) REFERENCES PRODUCT_BRANDS(BRAND_BARCODE)
                         )";
            cmd.ExecuteNonQuery();

            Console.WriteLine("Table BRAND_ORGS created");


            cmd.CommandText = @"CREATE TABLE FLOW(
                        Source_LOT_ID INT,
                        Source_ORG_ID INT, 
                        Target_LOT_ID INT, 
                        Target_ORG_ID INT, 
                        BRAND_BARCODE INT,
                        QUANTITY FLOAT,
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


            cmd.CommandText = @"CREATE TABLE ALTERNATIVE_BRANDS(
                            BRAND_BARCODE CHAR(13),
                            M_SYSCODE INT NOT NULL,
                            ALTERNATIVE_BRAND_BARCODE CHAR(13),
                            ALTERNATIVE_M_SYSCODE INT
                            FOREIGN KEY(BRAND_BARCODE) REFERENCES PRODUCT_BRANDS(BRAND_BARCODE),
                            FOREIGN KEY(BRAND_BARCODE) REFERENCES PRODUCT_BRANDS(BRAND_BARCODE),
                            FOREIGN KEY(M_SYSCODE) REFERENCES PRODUCT(M_SYSCODE),
                            FOREIGN KEY(M_SYSCODE) REFERENCES PRODUCT(M_SYSCODE)
                         )";

            cmd.ExecuteNonQuery();

            Console.WriteLine("Table ALTERNATIVE_BRANDS created");


        }
        public DatabaseController(String s)
        {
            con.Open();

            var cmd = new SqlCommand();
            cmd.Connection = con;





            //cmd.CommandText = "INSERT INTO PRODUCT(M_CODE,M_NAME, M_SHORTNAME, M_PARENTCODE, M_ABSTRACT, M_CATEGORY, IS_ACTIVE) " +
            //    "VALUES ('123','ESYA','ESY', '000', CAST('1' AS VARBINARY), 'ESYA', CAST('1' AS VARBINARY))";
            //cmd.ExecuteNonQuery();
            //cmd.CommandText = "INSERT INTO PRODUCT(M_CODE,M_NAME, M_SHORTNAME, M_PARENTCODE, M_ABSTRACT, M_CATEGORY, IS_ACTIVE) " +
            //    "VALUES ('1231','GIYECEK','GIY', '123', CAST('1' AS VARBINARY), 'GIYIM', CAST('1' AS VARBINARY))";
            //cmd.ExecuteNonQuery();
            //cmd.CommandText = "INSERT INTO PRODUCT(M_CODE,M_NAME, M_SHORTNAME, M_PARENTCODE, M_ABSTRACT, M_CATEGORY, IS_ACTIVE) " +
            //"VALUES ('12311','UST GIYIM','USTGIY', '1231', CAST('1' AS VARBINARY), 'GIYIM', CAST('1' AS VARBINARY))";
            //cmd.ExecuteNonQuery();
            //cmd.CommandText = "INSERT INTO PRODUCT(M_CODE,M_NAME, M_SHORTNAME, M_PARENTCODE, M_ABSTRACT, M_CATEGORY, IS_ACTIVE) " +
            //    "VALUES ('123111','KIRAVAT','KIR', '12311' , CAST('1' AS VARBINARY), 'GIYIM', CAST('1' AS VARBINARY))";
            //cmd.ExecuteNonQuery();


            //cmd.CommandText = "INSERT INTO FEATURES(FEATURE_NAME)" +
            //    "VALUES ('AGIRLIK')";
            //cmd.ExecuteNonQuery();
            //cmd.CommandText = "INSERT INTO FEATURES(FEATURE_NAME)" +
            //    "VALUES ('BOY')";
            //cmd.ExecuteNonQuery();
            //cmd.CommandText = "INSERT INTO FEATURES(FEATURE_NAME)" +
            //   "VALUES ('GENISLIK')";
            //cmd.ExecuteNonQuery();
            //cmd.CommandText = "INSERT INTO FEATURES(FEATURE_NAME)" +
            //   "VALUES ('NEM')";
            //cmd.ExecuteNonQuery();


            //cmd.CommandText = "INSERT INTO PRODUCT_FEATURES(M_SYSCODE, FEATURE_ID, MINVAL,MAXVAL)" +
            //    "VALUES (4,1,30,30)";
            //cmd.ExecuteNonQuery();


        }

        public List<PRODUCT> getProduct()
        {
            List<PRODUCT> listProduct = new List<PRODUCT>();
            string sql = "SELECT * FROM PRODUCT";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                PRODUCT p = new PRODUCT();
                p.M_SYSCODE = rdr.GetInt32(0);
                p.M_CODE = rdr.GetString(1);
                p.M_NAME = rdr.GetString(2);
                p.M_SHORTNAME = rdr.GetString(3);
                p.M_PARENTCODE = rdr.GetString(4);
                p.M_ABSTRACT = rdr.GetBoolean(5);
                p.M_CATEGORY = rdr.GetString(6);
                p.IS_ACTIVE = rdr.GetBoolean(7);
                listProduct.Add(p);

            }
            return listProduct;
        }
        public List<FEATURES> getFeatures()
        {
            List<FEATURES> features = new List<FEATURES>();
            string sql = "SELECT * FROM FEATURES";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                FEATURES f = new FEATURES();
                f.FEATURE_ID = rdr.GetInt32(0);
                f.FEATURE_NAME = rdr.GetString(1);
                features.Add(f);
            }
            return features;
        }
        public List<PRODUCT_FEATURES> getFeatureProducts()
        {
            List<PRODUCT_FEATURES> productFeatures = new List<PRODUCT_FEATURES>();
            string sql = "SELECT * FROM PRODUCT_FEATURES";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                PRODUCT_FEATURES pf = new PRODUCT_FEATURES();
                pf.M_SYSCODE = rdr.GetInt32(0);
                pf.FEATURE_ID = rdr.GetInt32(1);
                pf.MINVAL = (float)rdr.GetDouble(2);
                pf.MAXVAL = (float)rdr.GetDouble(3);
                productFeatures.Add(pf);

            }
            return productFeatures;
        }
        public List<COUNTRY> getCountry()
        {
            List<COUNTRY> countries = new List<COUNTRY>();
            string sql = "SELECT * FROM COUNTRY";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                COUNTRY c = new COUNTRY();
                c.Country_Code = rdr.GetString(0);
                c.Country_Name = rdr.GetString(1);
                countries.Add(c);
            }
            return countries;
        }
        public List<COUNTRY_CITY> getCountryCity()
        {
            List<COUNTRY_CITY> cities = new List<COUNTRY_CITY>();
            string sql = "SELECT * FROM COUNTRY_CITY";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                COUNTRY_CITY cc = new COUNTRY_CITY();
                cc.Country_Code = rdr.GetString(0);
                cc.CityID = rdr.GetInt32(1);
                cities.Add(cc);
            }
            return cities;
        }
        public List<MANUFACTURERS> getManufacturers()
        {
            List<MANUFACTURERS> manufacturers = new List<MANUFACTURERS>();
            string sql = "SELECT * FROM MANUFACTURERS";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                MANUFACTURERS m = new MANUFACTURERS();
                m.MANUFACTURER_ID = rdr.GetInt32(0);
                m.MANUFACTURER_NAME = rdr.GetString(1);
                m.MANUFACTURER_ADDRESS = rdr.GetString(2);
                m.CITY = rdr.GetInt32(3);
                m.Country_Code = rdr.GetString(4);

                manufacturers.Add(m);
            }
            return manufacturers;
        }
        public List<PRODUCT_BRANDS> getProductBrands()
        {
            List<PRODUCT_BRANDS> productBrands = new List<PRODUCT_BRANDS>();
            string sql = "SELECT * FROM PRODUCT_BRANDS";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                PRODUCT_BRANDS pb = new PRODUCT_BRANDS();
                pb.MANUFACTURER_ID = rdr.GetInt32(0);
                pb.M_SYSCODE = rdr.GetInt32(1);
                pb.BRAND_BARCODE = rdr.GetString(2);
                pb.BRAND_NAME = rdr.GetString(3);
                productBrands.Add(pb);
            }
            return productBrands;
        }
        public List<ORGANISATIONS> getOrganisations()
        {
            List<ORGANISATIONS> list = new List<ORGANISATIONS>();
            string sql = "SELECT * FROM ORGANISATIONS";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                ORGANISATIONS item = new ORGANISATIONS();
                item.ORG_ID = rdr.GetInt32(0);
                item.ORG_NAME = rdr.GetString(1);
                item.PARENT_ORG = rdr.GetInt32(2);
                item.ORG_ABSTRACT = rdr.GetBoolean(3);
                item.ORG_ADDRESS = rdr.GetString(4);
                item.ORG_CITY = rdr.GetInt32(5);
                item.ORG_DISTRICT = rdr.GetString(6);
                item.ORG_TYPE = rdr.GetInt32(7);
                list.Add(item);
            }
            return list;
        }
        public List<BRAND_ORGS> getBrandOrgs()
        {
            List<BRAND_ORGS> list = new List<BRAND_ORGS>();
            string sql = "SELECT * FROM BRAND_ORGS";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                BRAND_ORGS item = new BRAND_ORGS();
                item.LOT_ID = rdr.GetInt32(0);
                item.ORG_ID = rdr.GetInt32(1);
                item.BRAND_BARCODE = rdr.GetString(2);
                item.UNIT = (float)rdr.GetDouble(3);
                item.BASEPRICE = (float)rdr.GetDouble(4);
                item.QUANTITY = (float)rdr.GetDouble(5);
                item.INNN = (float)rdr.GetDouble(6);
                item.OUTTTT = (float)rdr.GetDouble(7);
                list.Add(item);
            }
            return list;
        }
        public List<FLOW> getFlow()
        {
            List<FLOW> list = new List<FLOW>();
            string sql = "SELECT * FROM FLOW";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                FLOW item = new FLOW();
                item.Source_LOT_ID = rdr.GetInt32(0);
                item.Source_ORG_ID = rdr.GetInt32(1);
                item.Target_LOT_ID = rdr.GetInt32(2);
                item.Target_ORG_ID = rdr.GetInt32(3);
                item.BRAND_BARCODE = rdr.GetInt32(4);
                item.QUANTITY = (float)rdr.GetDouble(5);
                item.FlowDate = rdr.GetDateTime(6);
                list.Add(item);
            }
            return list;
        }
        public List<ALTERNATIVE_BRANDS> getAlternativeBrands()
        {
            List<ALTERNATIVE_BRANDS> list = new List<ALTERNATIVE_BRANDS>();
            string sql = "SELECT * FROM ALTERNATIVE_BRANDS";
            using var asd = new SqlCommand(sql, con);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                ALTERNATIVE_BRANDS item = new ALTERNATIVE_BRANDS();
                item.BRAND_BARCODE = rdr.GetString(0);
                item.M_SYSCODE = rdr.GetInt32(1);
                item.ALTERNATIVE_BRAND_BARCODE = rdr.GetString(2);
                item.ALTERNATIVE_M_SYSCODE = rdr.GetInt32(3);
                list.Add(item);
            }
            return list;
        }
        public void insertProduct(string code, string name, string shortname, string parentcode, bool isAbstract, string category, bool isActive)
        {
            string s = "INSERT INTO PRODUCT(M_CODE, M_NAME, M_SHORTNAME, M_PARENTCODE, M_ABSTRACT, M_CATEGORY, IS_ACTIVE) " +
                "VALUES (@code,@name,@shortname,@parentcode,@isAbstract,@category,@isActive)";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@code", code);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@shortname", shortname);
            cmd.Parameters.AddWithValue("@parentcode", parentcode);
            cmd.Parameters.AddWithValue("@isAbstract", isAbstract);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.Parameters.AddWithValue("@isActive", isActive);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertFeatures(string featureName)
        {
            string s = "INSERT INTO FEATURES(FEATURE_NAME) " +
                "VALUES (@featureName)";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@featureName", featureName);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertProductFeatures(int syscode, int featureid, float minval, float maxval)
        {
            string s = "INSERT INTO PRODUCT_FEATURES(M_SYSCODE, FEATURE_ID, MINVAL, MAXVAL) " +
                "VALUES (@syscode,@featureid,@minval,@maxval)";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@syscode", syscode);
            cmd.Parameters.AddWithValue("@featureid", featureid);
            cmd.Parameters.AddWithValue("@minval", minval);
            cmd.Parameters.AddWithValue("@maxval", maxval);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertCountry(string countryCode, string countryName)
        {
            string s = "INSERT INTO COUNTRY(Country_Code, Country_Name) " +
                "VALUES(@countryCode,@countryName)";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@countryCode", countryCode);
            cmd.Parameters.AddWithValue("@countryName", countryName);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertCountryCity(string countryCode, string cityName)
        {
            string s = "INSERT INTO COUNTRY_CITY(Country_Code,City_Name) " +
                "VALUES (@countryCode,@cityName)";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@countryCode", countryCode);
            cmd.Parameters.AddWithValue("@cityName", cityName);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertManufacturers(string manufacturerName, string address, int city, string countryCode)
        {
            string s = "INSERT INTO MANUFACTURERS(MANUFACTURER_NAME, MANUFACTURER_ADDRESS, CITY, Country_Code) " +
                "VALUES (@manufacturerName,@address,@city,@countryCode)";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@manufacturerName", manufacturerName);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@countryCode", countryCode);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertProductBrands(int manufacturerid, int syscode, string brandBarcode, string brandName)
        {
            string s = "INSERT INTO PRODUCT_BRANDS(MANUFACTURER_ID, M_SYSCODE, BRAND_BARCODE, BRAND_NAME) " +
                "VALUES (@manufacturerid,@syscode,@brandBarcode,@brandName)";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@manufacturerid", manufacturerid);
            cmd.Parameters.AddWithValue("@syscode", syscode);
            cmd.Parameters.AddWithValue("@brandBarcode", brandBarcode);
            cmd.Parameters.AddWithValue("@brandName", brandName);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertOrganisations(string name, int parentOrg, bool isAbstract, string address, int cityid, string district, int orgType)
        {
            string s = "INSERT INTO ORGANISATIONS(ORG_NAME, PARENT_ORG, ORG_ABSTRACT, ORG_ADDRESS, ORG_CITY, ORG_DISTRICT, ORG_TYPE) " +
                "VALUES (@name,@parentOrg,@isAbstract,@address,@cityid,@district, @orgType)";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@parentOrg", parentOrg);
            cmd.Parameters.AddWithValue("@isAbstract", isAbstract);
            cmd.Parameters.AddWithValue("@cityid", cityid);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@district", district);
            cmd.Parameters.AddWithValue("@orgType", Convert.ToInt32(orgType));
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertBrandOrgs(int orgid, string brandBarcode, float unit, float baseprice, float quantity, float innn, float outttt)
        {
            string s = "INSERT INTO BRAND_ORGS(ORG_ID, BRAND_BARCODE, UNIT, BASEPRICE, QUANTITY, INNN, OUTTTT) " +
                "VALUES (@orgid,@brandBarcode,@unit, @baseprice,@quantity,@innn,@outttt)";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@orgid", orgid);
            cmd.Parameters.AddWithValue("@unit", unit);
            cmd.Parameters.AddWithValue("@baseprice", baseprice);
            cmd.Parameters.AddWithValue("@brandBarcode", brandBarcode);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@innn", innn);
            cmd.Parameters.AddWithValue("@outttt", outttt);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void insertAlternativeBrands(string brandBarcode, int syscode, float altBrandBarcode, float altSysCode)
        {
            string s = "INSERT INTO ALTERNATIVE_BRANDS(BRAND_BARCODE, M_SYSCODE, ALTERNATIVE_BRAND_BARCODE, ALTERNATIVE_M_SYSCODE) " +
                "VALUES (@brandBarcode,@syscode,@altBrandBarcode,@altSysCode )";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@brandBarcode", brandBarcode);
            cmd.Parameters.AddWithValue("@syscode", syscode);
            cmd.Parameters.AddWithValue("@altBrandBarcode", altBrandBarcode);
            cmd.Parameters.AddWithValue("@altSysCode", altSysCode);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }

        public void insertINFlow(int sourceorgid, string brandBarcode, float quantity, DateTime flowDate)
        {
            int lotId;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            string sql = "SELECT LOT_ID FROM BRAND_ORGS WHERE ORG_ID = @sourceorgid AND BRAND_BARCODE = @brandBarcode";

            using var asd = new SqlCommand(sql, con);
            asd.Parameters.AddWithValue("@sourceorgid", sourceorgid);
            asd.Parameters.AddWithValue("@quantity", quantity);
            asd.Parameters.AddWithValue("@brandBarcode", brandBarcode);
            asd.Parameters.AddWithValue("@flowDate", flowDate);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                lotId = rdr.GetInt32(0);
                asd.Parameters.AddWithValue("@lotId", lotId);
            }
            rdr.Close();
            string s = "INSERT INTO FLOW(Source_LOT_ID, Source_ORG_ID, Target_LOT_ID, Target_ORG_ID, BRAND_BARCODE,QUANTITY,FlowDate) " +
                "VALUES (@lotId,@sourceorgid,@lotId,@sourceorgid,@brandBarcode,@quantity,@flowDate)";

            asd.CommandText = s;
            asd.ExecuteNonQuery();
        }
        public void insertOUTFlow(int sourceorgid, int targetOrgId, string brandBarcode, float quantity, DateTime flowDate)
        {
            int lotId;
            int targetlotId;
            var cmd = new SqlCommand();
            cmd.Connection = con;
            string sql = "SELECT LOT_ID FROM BRAND_ORGS WHERE ORG_ID = @sourceorgid AND BRAND_BARCODE = @brandBarcode";
            using var asd = new SqlCommand(sql, con);

            string sql2 = "SELECT LOT_ID FROM BRAND_ORGS WHERE ORG_ID = @targetOrgId AND BRAND_BARCODE = @brandBarcode";
            using var asd2 = new SqlCommand(sql2, con);
            asd2.Parameters.AddWithValue("@sourceorgid", sourceorgid);
            asd.Parameters.AddWithValue("@sourceorgid", sourceorgid);
            asd2.Parameters.AddWithValue("@targetOrgId", targetOrgId);
            asd2.Parameters.AddWithValue("@quantity", quantity);
            asd2.Parameters.AddWithValue("@brandBarcode", brandBarcode);
            asd.Parameters.AddWithValue("@brandBarcode", brandBarcode);
            asd2.Parameters.AddWithValue("@flowDate", flowDate);
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                lotId = rdr.GetInt32(0);
                asd2.Parameters.AddWithValue("@lotId", lotId);
            }
            rdr.Close();

            using SqlDataReader rdr2 = asd2.ExecuteReader();
            while (rdr2.Read())
            {
                targetlotId = rdr2.GetInt32(0);
                asd2.Parameters.AddWithValue("@targetlotId", targetlotId);
            }
            rdr2.Close();


            string s = "INSERT INTO FLOW(Source_LOT_ID, Source_ORG_ID, Target_LOT_ID, Target_ORG_ID, BRAND_BARCODE,QUANTITY,FlowDate) " +
                "VALUES (@lotId,@sourceorgid,@targetlotId,@targetOrgId,@brandBarcode,@quantity,@flowDate)";


            asd2.CommandText = s;
            asd2.ExecuteNonQuery();
        }
        public void updateProduct(int syscode, string code, string name, string shortname, string parentcode, bool isAbstract, string category, bool isActive)
        {
            string s = "UPDATE PRODUCT SET M_CODE =@code , M_NAME =@name , M_SHORTNAME = @shortname ," +
                " M_PARENTCODE = @parentcode , M_ABSTRACT= @isAbstract , M_CATEGORY = @category , IS_ACTIVE = @isActive WHERE M_SYSCODE= @syscode";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@syscode", syscode);
            cmd.Parameters.AddWithValue("@code", code);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@shortname", shortname);
            cmd.Parameters.AddWithValue("@parentcode", parentcode);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.Parameters.AddWithValue("@isActive", isActive);
            cmd.Parameters.AddWithValue("@isAbstract", isAbstract);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateFeatures(int featureid, string name)
        {
            string s = "UPDATE FEATURES SET FEATURE_NAME = @name WHERE FEATURE_ID= @featureid";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@featureid", featureid);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateProductFeatures(int syscode, int featureid, float minval, float maxval)
        {
            string s = "UPDATE PRODUCT_FEATURES SET MINVAL =@minval , MAXVAL = @maxval" +
                " WHERE M_SYSCODE= @syscode AND FEATURE_ID =@featureid ";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@syscode", syscode);
            cmd.Parameters.AddWithValue("@featureid", featureid);
            cmd.Parameters.AddWithValue("@minval", minval);
            cmd.Parameters.AddWithValue("@maxval", maxval);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateCountry(string countryCode, string countryName)
        {
            string s = "UPDATE COUNTRY SET Country_Name =@countryName" +
                    " WHERE Country_Code=@countryCode";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@countryCode", countryCode);
            cmd.Parameters.AddWithValue("@countryName", countryName);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateCountryCity(string countryCode, string cityName)
        {
            string s = "UPDATE COUNTRY_CITY SET City_Name =@cityname WHERE Country_Code=@countryCode AND";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@countryCode", countryCode);
            cmd.Parameters.AddWithValue("@cityName", cityName);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateManufacturers(int manufacturerid, int city, string countryCode, string name, string address)
        {
            string s = "UPDATE MANUFACTURERS SET MANUFACTURER_NAME =@name , MANUFACTURER_ADDRESS = @address " +
                "WHERE MANUFACTURER_ID= @manufacturerid AND CITY = @city AND Country_Code = @countryCode";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@manufacturerid", manufacturerid);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@countryCode", countryCode);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateProductBrands(int manufacturerid, int syscode, string brandBarcode, string brandName)
        {
            string s = "UPDATE PRODUCT_BRANDS SET BRAND_NAME =@brandName" +
                    " WHERE M_SYSCODE=@syscode AND MANUFACTURER_ID =@manufacturerid AND BRAND_BARCODE =@brandBarcode";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@manufacturerid", manufacturerid);
            cmd.Parameters.AddWithValue("@syscode", syscode);
            cmd.Parameters.AddWithValue("@brandBarcode", brandBarcode);
            cmd.Parameters.AddWithValue("@brandName", brandName);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateOrganisations(int orgid, string orgName, int parentOrg, bool isAbstract, string address, int city, string district, int orgType)
        {
            string s = "UPDATE ORGANISATIONS SET ORG_NAME =@orgname , ORG_ABSTRACT = @isAbstract , ORG_ADDRESS = @address" +
                ", ORG_CITY = @city , ORG_DISTRICT = @district , ORG_TYPE = @orgType " +
                    " WHERE ORG_ID=@orgid AND PARENT_ORG = @parentOrg";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@orgid", orgid);
            cmd.Parameters.AddWithValue("@district", district);
            cmd.Parameters.AddWithValue("@orgName", orgName);
            cmd.Parameters.AddWithValue("@parentOrg", parentOrg);
            cmd.Parameters.AddWithValue("@isAbstract", isAbstract);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@orgType", orgType);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateBrandOrgs(int lotid, int orgid, string brandBarcode, float unit, float baseprice, float innn, float outttt)
        {
            string s = "UPDATE BRAND_ORGS SET INNN = @innn , OUTTTT = @outttt, UNIT = @unit, BASEPRICE = @baseprice ," +
                    " QUANTITY = " + (innn + outttt) +
                    " WHERE LOT_ID=@lotid AND ORG_ID =@orgid AND BRAND_BARCODE =@brandBarcode";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@orgid", orgid);
            cmd.Parameters.AddWithValue("@lotid", lotid);
            cmd.Parameters.AddWithValue("@brandBarcode", brandBarcode);
            cmd.Parameters.AddWithValue("@unit", unit);
            cmd.Parameters.AddWithValue("@baseprice", baseprice);
            cmd.Parameters.AddWithValue("@innn", innn);
            cmd.Parameters.AddWithValue("@outttt", outttt);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void updateAlternativeBrands(string brandBarcode, int syscode, string altBrandBarcode, int altSysCode)
        {
            string s = "UPDATE ALTERNATIVE_BRANDS SET BRAND_BARCODE =@brandBarcode, M_SYSCODE =@syscode," +
                " ALTERNATIVE_BRAND_BARCODE =@altBrandBarcode  , ALTERNATIVE_M_SYSCODE=@altSysCode";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@brandBarcode", brandBarcode);
            cmd.Parameters.AddWithValue("@syscode", syscode);
            cmd.Parameters.AddWithValue("@altBrandBarcode", altBrandBarcode);
            cmd.Parameters.AddWithValue("@altSysCode", altSysCode);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void deleteFromProduct(int syscode, int deleteStyle)
        {

            var cmd = new SqlCommand();
            cmd.Connection = con;
            if (deleteStyle == 1)
            {
                cmd.Parameters.AddWithValue("@syscode", syscode);
                string s2 = "UPDATE PRODUCT SET M_PARENTCODE = (SELECT M_PARENTCODE FROM PRODUCT WHERE M_SYSCODE = @syscode) WHERE M_PARENTCODE =(SELECT M_CODE FROM PRODUCT WHERE M_SYSCODE = @syscode)";
                cmd.CommandText = s2;
                cmd.ExecuteNonQuery();
                string s = "DELETE FROM PRODUCT WHERE M_SYSCODE =@syscode";
                cmd.CommandText = s;
                cmd.ExecuteNonQuery();
            }
            else
            {
                string sql = "SELECT * FROM PRODUCT WHERE M_PARENTCODE = (SELECT M_CODE FROM PRODUCT WHERE M_SYSCODE = @syscode)";
                using var asd = new SqlCommand(sql, con);
                asd.Parameters.AddWithValue("@syscode", syscode);
                cmd.Parameters.AddWithValue("@syscode", syscode);
                using SqlDataReader rdr = asd.ExecuteReader();
                while (rdr.Read())
                {
                    int childSysCode = rdr.GetInt32(0);
                    string childProdcutId = rdr.GetString(1);
                    string s3 = "DELETE FROM PRODUCT WHERE M_CODE =@childprocutId";
                    asd.Parameters.AddWithValue("@childProdcutId", childProdcutId);
                    asd.Parameters.AddWithValue("@childSysCode", childSysCode);
                    asd.CommandText = s3;
                    rdr.Close();
                    asd.ExecuteNonQuery();
                    deleteFromProduct(childSysCode, 0);
                }
                rdr.Close();
                string s = "DELETE FROM PRODUCT WHERE M_SYSCODE=@syscode";
                cmd.CommandText = s;
                cmd.ExecuteNonQuery();

            }

        }
        public void deleteFromFeatures(int featureid)
        {
            string s = "DELETE FROM FEATURES WHERE FEATURE_ID =@featureid";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@featureid", featureid);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void deleteFromProductFeatures(int syscode, int featureid)
        {
            string s = "DELETE FROM PRODUCT_FEATURES WHERE FEATURE_ID =@featureid AND M_SYSCODE =@syscode";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@syscode", syscode);
            cmd.Parameters.AddWithValue("@featureid", featureid);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void deleteFromCountry(string countryCode)
        {
            string s = "DELETE FROM COUNTRY WHERE Country_Code =@countryCode";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@countryCode", countryCode);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void deleteFromCountryCity(string countryCode, int cityid)
        {
            string s = "DELETE FROM COUNTRY_CITY WHERE Country_Code =@countryCode  AND CityID =@cityid";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@countryCode", countryCode);
            cmd.Parameters.AddWithValue("@cityid", cityid);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void deleteFromManufacturers(int manufacturerid)
        {
            string s = "DELETE FROM MANUFACTURERS WHERE MANUFACTURER_ID =@manufacturerid";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@manufacturerid", manufacturerid);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public void deleteFromProductBrands(int manufacturerid, int syscode, string brandBarcode)
        {
            string s = "DELETE FROM PRODUCT_BRANDS WHERE MANUFACTURER_ID =@manufacturerid AND M_SYSCODE=@syscode " +
                "AND BRAND_BARCODE =@brandBarcode ";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@manufacturerid", manufacturerid);
            cmd.Parameters.AddWithValue("@syscode", syscode);
            cmd.Parameters.AddWithValue("@brandBarcode", brandBarcode);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }

        public void deleteFromOrganisations(int orgid, int deleteStyle)
        {
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@orgid", orgid);
            if (deleteStyle == 1)
            {
                string s2 = "UPDATE ORGANISATIONS SET PARENT_ORG = (SELECT PARENT_ORG FROM ORGANISATIONS WHERE ORG_ID = @orgid) " +
                    "WHERE PARENT_ORG = (SELECT ORG_ID FROM ORGANISATIONS WHERE ORG_ID = @orgid)";
                cmd.CommandText = s2;
                cmd.ExecuteNonQuery();
                string s = "DELETE FROM ORGANISATIONS WHERE ORG_ID=@orgid";
                cmd.CommandText = s;
                cmd.ExecuteNonQuery();
            }
            else
            {
                string sql = "SELECT * FROM ORGANISATIONS WHERE PARENT_ORG = @orgid";
                using var asd = new SqlCommand(sql, con);
                asd.Parameters.AddWithValue("@orgid", orgid);
                using SqlDataReader rdr = asd.ExecuteReader();
                while (rdr.Read())
                {
                    int childOrgid = rdr.GetInt32(0);
                    string s3 = "DELETE FROM ORGANISATIONS WHERE ORG_ID = " + childOrgid;
                    asd.Parameters.AddWithValue("@childOrgid", childOrgid);
                    asd.CommandText = s3;
                    rdr.Close();
                    asd.ExecuteNonQuery();
                    deleteFromOrganisations(childOrgid, 0);
                }
                rdr.Close();
                string s = "DELETE FROM ORGANISATIONS WHERE ORG_ID=@orgid";
                cmd.CommandText = s;
                cmd.ExecuteNonQuery();
            }

        }
        public void deleteFromBrandOrgs(int lotid)
        {
            string s = "DELETE FROM BRAND_ORGS WHERE LOT_ID =@lotid AND M_SYSCODE=@syscode ";
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@lotid", lotid);
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
        }
        public List<LINKINGBRANDORGS> searchWithOrgName(string orgname)
        {
            List<LINKINGBRANDORGS> brandorgs = new List<LINKINGBRANDORGS>();

            string sql = "SELECT ORG_NAME,BRAND_NAME,INNN,OUTTTT,BASEPRICE,UNIT,QUANTITY FROM " +
                "ORGANISATIONS,PRODUCT_BRANDS,BRAND_ORGS WHERE " +
                "ORGANISATIONS.ORG_NAME LIKE " + "'%" +orgname + "%'" + " AND "+
                "ORGANISATIONS.ORG_ID = BRAND_ORGS.ORG_ID AND " +
                "PRODUCT_BRANDS.BRAND_BARCODE = BRAND_ORGS.BRAND_BARCODE";
            using var asd = new SqlCommand(sql, con);
        //    asd.Parameters.AddWithValue("@orgname", ("%" + orgname + "%"));
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                LINKINGBRANDORGS b = new LINKINGBRANDORGS();
                b.ORG_NAME = rdr.GetString(0);
                b.BRAND_NAME = rdr.GetString(1);
                b.INNN = (float)rdr.GetDouble(2);
                b.OUTTTT = (float)rdr.GetDouble(3);
                b.BASEPRICE = (float)rdr.GetDouble(4);
                b.UNIT = (float)rdr.GetDouble(5);
                b.QUANTITY = (float)rdr.GetDouble(6);
                brandorgs.Add(b);
            }
            return brandorgs;
        }
        public List<LINKINGBRANDORGS> searchWithBrandName(string brandname)
        {
            List<LINKINGBRANDORGS> brandorgs = new List<LINKINGBRANDORGS>();
            string sql = "SELECT ORG_NAME,BRAND_NAME,INNN,OUTTTT,QUANTITY, UNIT, BASEPRICE FROM " +
                "ORGANISATIONS,PRODUCT_BRANDS,BRAND_ORGS WHERE " +
                "PRODUCT_BRANDS.BRAND_NAME LIKE " + "'%" + brandname + "%'" + " AND " +
                "ORGANISATIONS.ORG_ID = BRAND_ORGS.ORG_ID AND " +
                "PRODUCT_BRANDS.BRAND_BARCODE = BRAND_ORGS.BRAND_BARCODE";
            using var asd = new SqlCommand(sql, con);
      //      asd.Parameters.AddWithValue("@brandname", ("%" + brandname + "%"));
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                LINKINGBRANDORGS b = new LINKINGBRANDORGS();
                b.ORG_NAME = rdr.GetString(0);
                b.BRAND_NAME = rdr.GetString(1);
                b.INNN = (float)rdr.GetDouble(2);
                b.OUTTTT = (float)rdr.GetDouble(3);
                b.QUANTITY = (float)rdr.GetDouble(4);
                b.UNIT = (float)rdr.GetDouble(5);
                b.BASEPRICE = (float)rdr.GetDouble(6);
                brandorgs.Add(b);
                
            }
            return brandorgs;
        }
        public List<LINKINGPRODUCTFEATURES> searchWithProductName(string productname)
        {
            List<LINKINGPRODUCTFEATURES> productNames = new List<LINKINGPRODUCTFEATURES>();
            string sql = "SELECT M_CODE ,M_NAME, M_CATEGORY  ,FEATURE_NAME  , MINVAL , MAXVAL  FROM " +
                "PRODUCT,FEATURES,PRODUCT_FEATURES WHERE " +
                "PRODUCT.M_NAME LIKE " + "'%" + productname + "%'" + " AND " +
                "PRODUCT.M_SYSCODE = PRODUCT_FEATURES.M_SYSCODE AND " +
                "FEATURES.FEATURE_ID   = PRODUCT_FEATURES.FEATURE_ID";
            using var asd = new SqlCommand(sql, con);
            //      asd.Parameters.AddWithValue("@brandname", ("%" + brandname + "%"));
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                LINKINGPRODUCTFEATURES b = new LINKINGPRODUCTFEATURES();
                b.M_CODE = rdr.GetString(0);
                b.M_NAME = rdr.GetString(1);
                b.M_CATEGORY = rdr.GetString(2);
                b.FEATURE_NAME = rdr.GetString(3);
                b.MINVAL = (float)rdr.GetDouble(4);
                b.MAXVAL = (float)rdr.GetDouble(5);
                productNames.Add(b);
            }
            return productNames;
        }
        public List<LINKINGPRODUCTFEATURES> searchWithFeature(string featurename)
        {
            List<LINKINGPRODUCTFEATURES> productNames = new List<LINKINGPRODUCTFEATURES>();
            string sql = "SELECT M_CODE ,M_NAME, M_CATEGORY  ,FEATURE_NAME  , MINVAL , MAXVAL  FROM " +
                "PRODUCT,FEATURES,PRODUCT_FEATURES WHERE " +
                "FEATURES.FEATURE_NAME LIKE " + "'%" + featurename + "%'" + " AND " +
                "PRODUCT.M_SYSCODE = PRODUCT_FEATURES.M_SYSCODE AND " +
                "FEATURES.FEATURE_ID   = PRODUCT_FEATURES.FEATURE_ID";
            using var asd = new SqlCommand(sql, con);
            //      asd.Parameters.AddWithValue("@brandname", ("%" + brandname + "%"));
            using SqlDataReader rdr = asd.ExecuteReader();
            while (rdr.Read())
            {
                LINKINGPRODUCTFEATURES b = new LINKINGPRODUCTFEATURES();
                b.M_CODE = rdr.GetString(0);
                b.M_NAME = rdr.GetString(1);
                b.M_CATEGORY = rdr.GetString(2);
                b.FEATURE_NAME = rdr.GetString(3);
                b.MINVAL = (float)rdr.GetDouble(4);
                b.MAXVAL = (float)rdr.GetDouble(5);
                productNames.Add(b);
            }
            return productNames;
        }
    }
   
}
