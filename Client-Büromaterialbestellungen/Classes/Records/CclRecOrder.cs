using System;
using CDS.Classes.Attributes;
using CDS.Classes.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Büromaterialbestellungen.Classes.Records
{
    [CDSTable("Order", "EUA_PO", "ORD")]
    public class CclRecOrder : CclCDSRecExtBase
    {
        #region Instance variables
        ///**************************************************
        /// Instance variables
        private string I_strUserID;

        private DateTime I_dtDate;

        #endregion Instance variables

        #region Properties
        ///**************************************************
        /// Properties
        [CDSField(40, 0, false, true)] public string UserID { get { return I_strUserID; } set { SetValue(ref I_strUserID, value); } }
                                       public DateTime Date { get { return I_dtDate; } set { SetValue(ref I_dtDate, value); } }

        #endregion Properties
    }
}

