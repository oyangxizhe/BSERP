using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using XizheC;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace XizheC
{
    public  class CUSER
    {
        basec bc = new basec();
   
  
        private string _USID;
        public string USID
        {
            set { _USID = value; }
            get { return _USID; }

        }
        private string _UNAME;
        public string UNAME
        {
            set { _UNAME = value; }
            get { return _UNAME; }

        }
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        private string _GEID;
        public string GEID
        {
            set { _GEID = value; }
            get { return _GEID; }

        }
        private string _ENAME;
        public string ENAME
        {
            set { _ENAME = value; }
            get { return _ENAME; }

        }
        private string _DEPART;
        public string DEPART
        {
            set { _DEPART = value; }
            get { return _DEPART; }

        }
        private string _sql;
        public string sql
        {
            set { _sql = value; }
            get { return _sql; }

        }
        private string _sqlo;
        public string sqlo
        {
            set { _sqlo = value; }
            get { return _sqlo; }

        }
        private string _sqlt;
        public string sqlt
        {
            set { _sqlt = value; }
            get { return _sqlt; }

        }
        private string _sqlth;
        public string sqlth
        {
            set { _sqlth = value; }
            get { return _sqlth; }

        }
        private string _sqlf;
        public string sqlf
        {
            set { _sqlf = value; }
            get { return _sqlf; }

        }
        private string _sqlfi;
        public string sqlfi
        {
            set { _sqlfi = value; }
            get { return _sqlfi; }

        }
        #region setsqlo
        string setsqlo = @"
INSERT INTO 
AUTHORIZATION_USER
(
AUID,
USID,
STATUS,
LOGIN_DATE,
LEAVE_DATE,
YEAR,
MONTH
)  
VALUES 
(
@AUID,
@USID,
@STATUS,
@LOGIN_DATE,
@LEAVE_DATE,
@YEAR,
@MONTH
)";
        #endregion
        #region setsqlt
        string setsqlt = @"
UPDATE BOM_MST SET 
AUID=@AUID
USID=@USID,
STATUS=@STATUS,
LOGIN_DATE=@LOGIN_DATE,
LEAVE_DATE=@LEAVE_DATE,
YEAR=@YEAR
MONTH=@MONTH
)";
        public CUSER()
        {
            sqlo = setsqlo;
            sqlt = setsqlt;
        }
        #endregion
    
        
        #region JUAGE_LOGIN_IF_SUCCESS
        public bool JUAGE_LOGIN_IF_SUCCESS(string UNAME, string PWD)
        {
            bool b = false;
            try
            {
                byte[] B = bc.GetMD5(PWD);
                SqlConnection sqlcon = bc.getcon();
                string sql1 = "SELECT * FROM USERINFO WHERE PWD=@PWD and UNAME=@UNAME";
                SqlCommand sqlcom = new SqlCommand(sql1, sqlcon);
                sqlcom.Parameters.Add("@PWD", SqlDbType.Binary, 50).Value = B;
                sqlcom.Parameters.Add("@UNAME", SqlDbType.VarChar, 50).Value = UNAME;
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                if (sqlcom.ExecuteScalar()!= null)
                {
                    string sql = @"SELECT B.DEPART,B.EMID,B.ENAME,A.USID AS USID,A.UNAME FROM USERINFO A 
LEFT JOIN EMPLOYEEINFO B ON A.EMID =B.EMID WHERE A.UNAME='" + UNAME + "'";
                    DataTable dt = basec.getdts(sql);
                    if (dt.Rows.Count > 0)
                    {
                        DEPART = dt.Rows[0]["DEPART"].ToString();
                        ENAME = dt.Rows[0]["ENAME"].ToString();
                        EMID = dt.Rows[0]["EMID"].ToString();
                        USID = dt.Rows[0]["USID"].ToString();
                    }
                    b = true;
                }
                sqlcon.Close();
            }
            catch (Exception)
            {

            }
            return b;
        }
        #endregion

        public string GETID()
        {
            string v1 = bc.numYM(10, 4, "0001", "SELECT * FROM AUTHORIZATION_USER", "AUID", "AU");
            string GETID = "";
            if (v1 != "Exceed Limited")
            {
                GETID = v1;
            }
            return GETID;
        }
        #region SQlcommandE
        public  void SQlcommandE(string sql)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" +USID + "'");
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@AUID", SqlDbType.VarChar, 20).Value =GEID;
            sqlcom.Parameters.Add("@USID", SqlDbType.VarChar, 20).Value = USID;
            sqlcom.Parameters.Add("@STATUS", SqlDbType.VarChar, 20).Value = "Y";
            sqlcom.Parameters.Add("@LOGIN_DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@LEAVE_DATE", SqlDbType.VarChar, 20).Value = "";
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
      
    }
}
