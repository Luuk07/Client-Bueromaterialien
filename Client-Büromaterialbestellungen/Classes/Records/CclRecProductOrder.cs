using CDS.Classes.Attributes;
using CDS.Classes.Data;
using CDS.Classes.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Büromaterialbestellungen.Classes.Records
{

    //Record for Products

    [CDSTable("product", "DB", "")]
    public class CclRecProductOrder : CclCDSRecBase
    {
        #region Constants
        ///**************************************************
        /// Constants
      

        #endregion Constants

        #region Instance variables
        ///**************************************************
        /// Instance variables
        /// 
        private int I_intOrderID;
        private int I_intAmount;
        private string I_strNote;
        private int I_intProductID;
        private string I_intProductName;
        private string I_strUserName;
        private bool I_boolIsPreOrdered;
        private bool I_boolIsOrdered;
        private bool I_boolIsReceived;
        //private bool I_boolIsDeleted;

        //private string I_strPassword;

        #endregion Instance variables

        #region Properties
        ///**************************************************
        /// Properties
        [CDSField(0, 0, true, true, false, true)]

        public int ID { get; set; }
        public string OrderID { get; set; } = Guid.NewGuid().ToString();
        public int ProductID { get { return I_intProductID; } set { SetValue(ref I_intProductID, value); } }
        public string ProductName { get { return I_intProductName; } set { SetValue(ref I_intProductName, value); } }

        public int Amount { get { return I_intAmount; } set { SetValue(ref I_intAmount, value); } }

        public string Note { get { return I_strNote; } set { SetValue(ref I_strNote, value); } }

        public string UserName { get { return I_strUserName; } set { SetValue(ref I_strUserName, value); } }

        public bool IsPreOrdered { get { return I_boolIsPreOrdered; } set { SetValue(ref I_boolIsPreOrdered, value); } }

        public bool IsOrdered { get { return I_boolIsOrdered; } set { SetValue(ref I_boolIsOrdered, value); } }

        public bool IsReceived { get { return I_boolIsReceived; } set { SetValue(ref I_boolIsReceived, value); } }

        #endregion Properties

        #region Initialization
        ///**************************************************
        /// <summary>
        /// Standard constructor. Initializes the instance.
        /// </summary>
        public CclRecProductOrder() : this(int.MinValue, string.Empty , int.MinValue, string.Empty, int.MinValue, string.Empty, string.Empty, true, false, false) { }

        ///**************************************************
        /// <summary>
        /// Extended constructor. Initializes the instance.
        /// </summary>
        /// <param name="_strUser">Value for 'ArchivePath'.</param>
        /// <param name="_strDomain">Value for 'ErrorPath'.</param>
        /// <param name="_strPassword">Value for 'ErrorMailSender'.</param>
        /// <param name="_iTimeOut">Value for 'ErrorMailReceiver'.</param>
        public CclRecProductOrder(int _intID, string _strOrderID,int _intProductID, string _strProductName, int _intAmount, string _strNote, string _strUserName, bool _boolIsPreOrdered, bool _boolIsOrdered, bool _boolIsReceived)
        {
            ID = _intID;    
            OrderID = _strOrderID;
            ProductID = _intProductID;
            ProductName = _strProductName;
            Amount = _intAmount;
            Note = _strNote;
            
            UserName = _strUserName;
            IsPreOrdered = _boolIsPreOrdered;
            IsOrdered = _boolIsOrdered;
            IsReceived = _boolIsReceived;
            //IsDeleted = _boolIsDeleted;
        }

        #endregion Initialization
    }
}