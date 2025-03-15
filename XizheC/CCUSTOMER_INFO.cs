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

namespace XizheC
{
    public class CCUSTOMER_INFO
    {
        basec bc = new basec();

        #region nature
        public string _GETID;
        public string GETID
        {
            set { _GETID = value; }
            get { return _GETID; }

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
        private string _sqlsi;
        public string sqlsi
        {
            set { _sqlsi = value; }
            get { return _sqlsi; }

        }
        private string _MAKERID;
        public string MAKERID
        {
            set { _MAKERID = value; }
            get { return _MAKERID; }

        }

        private static bool _IFExecutionSUCCESS;
        public static bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        private string _ErrowInfo;
        public string ErrowInfo
        {

            set { _ErrowInfo = value; }
            get { return _ErrowInfo; }

        }

        #endregion
        DataTable dtx2 = new DataTable();
        #region sql
        string setsql = @"

";

        string setsqlo = @"


";

        string setsqlt = @"

INSERT INTO CUSTOMERINFO_MST
(
CUID,
CNAME,
CUKEY,
DATE,
MAKERID,
YEAR,
MONTH,
DAY,
PAYMENT,
PAYMENT_CLAUSE,
CUSTOMER_ID
)
VALUES
(
@CUID,
@CNAME,
@CUKEY,
@DATE,
@MAKERID,
@YEAR,
@MONTH,
@DAY,
@PAYMENT,
@PAYMENT_CLAUSE,
@CUSTOMER_ID
)
";
        string setsqlth = @"
UPDATE CUSTOMERINFO_MST SET 
CNAME=@CNAME,
CUKEY=@CUKEY,
DATE=@DATE,
MAKERID=@MAKERID,
YEAR=@YEAR,
MONTH=@MONTH,
DAY=@DAY,
PAYMENT=@PAYMENT,
PAYMENT_CLAUSE=@PAYMENT_CLAUSE,
CUSTOMER_ID=@CUSTOMER_ID

";

        string setsqlf = @"


)
";
        string setsqlfi = @"

";
        string setsqlsi = @"

)
";
        #endregion
        public CCUSTOMER_INFO()
        {
            string year, month, day;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            day = DateTime.Now.ToString("dd");
            //GETID =bc.numYM(10, 4, "0001", "SELECT * FROM WORKORDER_PICKING_MST", "WPID", "WP");

            sql = setsql;
            sqlo = setsqlo;
            sqlt = setsqlt;
            sqlth = setsqlth;
            sqlf = setsqlf;
            sqlfi = setsqlfi;
            sqlsi = setsqlsi;
        }
    }
}
