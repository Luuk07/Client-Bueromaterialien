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
    [CDSTable("CfgActiveDirectory", "CFG", "AD")]
    public class CclRecTest : CclCDSRecBase
    {
        #region Constants
        ///**************************************************
        /// Constants
        private const string I_strCryptoKey = "e950tu dfb-<y.dx epotz sölrdjt a94et dflkgd";

        #endregion Constants

        #region Instance variables
        ///**************************************************
        /// Instance variables
        private string I_strUser;
        private string I_strDomain;
        private int I_TimeOut;
        private string I_strPassword;

        #endregion Instance variables

        #region Properties
        ///**************************************************
        /// Properties
        [CDSField(0, 0, true, false, false, true)] public int ID { get; set; }

        public string User { get { return I_strUser; } set { SetValue(ref I_strUser, value); } }
        public string Domain { get { return I_strDomain; } set { SetValue(ref I_strDomain, value); } }
        public int TimeOut { get { return I_TimeOut; } set { SetValue(ref I_TimeOut, value); } }
        [CDSField(0, 0, false, false, true)] public string Password { get { return I_strPassword; } set { SetValue(ref I_strPassword, value); } }
        [CDSField(256, 0)]
        public string EncryptedPassword
        {
            get { return CstToolsEncryption.Encrypt(Password, I_strCryptoKey); }
            set { Password = CstToolsEncryption.Decrypt(value, I_strCryptoKey); }
        }

        #endregion Properties

        #region Initialization
        ///**************************************************
        /// <summary>
        /// Standard constructor. Initializes the instance.
        /// </summary>
        public CclRecTest() : this(string.Empty, string.Empty, string.Empty, int.MinValue) { }

        ///**************************************************
        /// <summary>
        /// Extended constructor. Initializes the instance.
        /// </summary>
        /// <param name="_strUser">Value for 'ArchivePath'.</param>
        /// <param name="_strDomain">Value for 'ErrorPath'.</param>
        /// <param name="_strPassword">Value for 'ErrorMailSender'.</param>
        /// <param name="_iTimeOut">Value for 'ErrorMailReceiver'.</param>
        public CclRecTest(string _strUser, string _strDomain, string _strPassword, int _iTimeOut)
        {
            User = _strUser;
            Domain = _strDomain;
            Password = _strPassword;
            TimeOut = _iTimeOut;
        }

        #endregion Initialization
    }
}

