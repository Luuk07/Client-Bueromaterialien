using Büromaterialbestellungen.Classes.Records;
using CDS.Classes;
using CDS.Classes.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Büromaterialbestellungen.Classes.Services
{
    internal class CclSvcTest
    {
        #region Properties
        protected CclContRegisteredDB WorkDB { get; }

        #endregion Properties

        #region Instance variables
        ///**************************************************
        /// Instance variables
        private CclCDSTable<CclRecTest> I_clTableDistributors;



        #endregion Instance variables

        #region Initialization
        ///**************************************************
        /// <summary>
        /// Extended constructor. Initializes the instance.
        /// </summary>
        /// <param name="_clCDSDatabase">The CDS database container.</param>
        /// <param name="_strApplicationID">The application id.</param>
        internal CclSvcTest(CclContRegisteredDB _clCDSDatabase, string _strApplicationID)
        {
            WorkDB = _clCDSDatabase;
            I_clTableDistributors = new CclCDSTable<CclRecTest>(WorkDB.CreateDataAccess());
        }

        #endregion Initialization
        internal CclRecTest LoadSettings()
        {
            I_clTableDistributors.LoadData();
            if (I_clTableDistributors.Count == 0)
                I_clTableDistributors.Add(new CclRecTest());

            return I_clTableDistributors[0];
        }


        internal void SaveData()
        {
            I_clTableDistributors.SaveData();
        }
    }
}
