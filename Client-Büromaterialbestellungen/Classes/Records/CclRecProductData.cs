using CDS.Classes.Attributes;
using CDS.Classes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Büromaterialbestellungen.Classes.Records
{
    [CDSTable("allproductsdata", "DB", "")]
    public class CclRecProductData: CclCDSRecBase
    {
        #region Constants
        ///**************************************************
        /// Constants
      

        #endregion Constants

        #region Instance variables
        ///**************************************************
        /// Instance variables
        private int I_intProductID;
        private string I_strProductName;
        private int I_intAmount;
        private string I_strDiscribtion;
        private string I_strReference;
        private bool I_boolIsConnectionPoint;
        private int I_intKategorieID;


        #endregion Instance variables

        #region Properties
        ///**************************************************
        /// Properties
        [CDSField(0, 0, false, false, false, true)]
        public int ProductID { get { return I_intProductID; } set { SetValue(ref I_intProductID, value); } }
        public string ProductName { get { return I_strProductName; } set { SetValue(ref I_strProductName, value); } }
        public string Discribtion { get { return I_strDiscribtion; } set { SetValue(ref I_strDiscribtion, value); } }
        public string Reference { get { return I_strReference; } set { SetValue(ref I_strReference, value); } }

        public bool IsConnectionPoint { get { return I_boolIsConnectionPoint; } set { SetValue(ref I_boolIsConnectionPoint, value); } }

        public int KategorieID { get { return I_intKategorieID; } set { SetValue(ref I_intKategorieID, value); } }

        //public DateTime OrderDate { get; set; }





        #endregion Properties

        #region Initialization
        ///**************************************************
        /// <summary>
        /// Standard constructor. Initializes the instance.
        /// </summary>
        public CclRecProductData() : this(int.MinValue, string.Empty, string.Empty, string.Empty, false, int.MinValue) { }

        ///**************************************************
        /// <summary>
        /// Extended constructor. Initializes the instance.
        /// </summary>
        /// <param name="_strUser">Value for 'ArchivePath'.</param>
        /// <param name="_strDomain">Value for 'ErrorPath'.</param>
        /// <param name="_strPassword">Value for 'ErrorMailSender'.</param>
        /// <param name="_iTimeOut">Value for 'ErrorMailReceiver'.</param>
        public CclRecProductData(int _intProductID, string _strProductName, string _strDiscribtion, string _strReference, bool _boolIsConnectionPoint, int _intKategorieID)
        {
            ProductID = _intProductID;
            ProductName = _strProductName;
            Discribtion = _strDiscribtion;
            Reference = _strReference;
            IsConnectionPoint = _boolIsConnectionPoint;
            KategorieID = _intKategorieID;


        }

        #endregion Initialization
    }
}
