using CDSCore.Classes.Container;
using CDSCore.Classes.Services;
using CDSCore.Defines;
using CDSCore.Interfaces;
using DataRecords.Records.Common.Configurations;

namespace SharedBaseClasses.Classes.Services;
public abstract class CclSvcDataStorageBase
{
    #region Instance variables
    ///**************************************************
    /// Instance variables
    protected CclSvcCDSDataStorage     I_clSvcDBBase;    
    protected CclContCDSConnectionData I_clBaseCBConnData;
    protected CclContCDSConnectionData I_clDBConnData;

    protected string                   I_strApplicationID;

    #endregion Instance variables

    #region Initialization
    ///**************************************************
    /// <summary>
    /// Extended constructor. Initializes the instance.
    /// </summary>
    /// <param name="_clBaseDBConnData">Connection data for the main data storage.</param>
    /// <param name="_strApplicationID">The application id.</param>
    public CclSvcDataStorageBase(CclContCDSConnectionData _clBaseDBConnData, string _strApplicationID)
    {
        I_strApplicationID = _strApplicationID;
        I_clBaseCBConnData = _clBaseDBConnData;
        I_clSvcDBBase      = new(I_clBaseCBConnData);
        I_clDBConnData     = LoadDBConfig(I_clBaseCBConnData, _strApplicationID);
    }

    #endregion Initialization

    #region Methods

    #region Public
    ///**************************************************
    /// <summary>
    /// Loads the path to the given applications help document.
    /// </summary>
    /// <param name="_clBaseDBConnData">The connection data to use.</param>
    /// <param name="_strAppID">The id of the documents application.</param>
    /// <returns>The path to the given applications help document if there is a document available, an empty string otherwise.</returns>
    public string? LoadHelpDocPath()
    {
        ICDSDataList<CclRecCfgHelpDocPaths> ifTableDocPath = I_clSvcDBBase.CreateDataList<CclRecCfgHelpDocPaths>();

        ifTableDocPath.SelectData().Where("HDP_AppID", SQLFieldCompare.Equals, I_strApplicationID).Go();

        return (ifTableDocPath.AsList.Count == 0) ? string.Empty
                                                  : ifTableDocPath.AsList[0].DocPath;
    }

    #endregion Public

    #region Private
    ///**************************************************
    /// <summary>
    /// Loads the database configuration of the given application.
    /// </summary>
    /// <param name="_clBaseDBConnData">The connection data for the base datasource.</param>
    /// <param name="_strApplicationID">The application id of the configuration to load.</param>
    /// <returns>The database configuration of the given application.</returns>
    private CclContCDSConnectionData LoadDBConfig(CclContCDSConnectionData _clBaseDBConnData, string _strApplicationID)
    {
        ICDSDataList<CclRecCfgDBConnection> ifTableConnectionCfg = I_clSvcDBBase.CreateDataList<CclRecCfgDBConnection>();

        ifTableConnectionCfg.SelectData().Where("DBC_ApplikationID", SQLFieldCompare.Equals, _strApplicationID).Go();

        if (ifTableConnectionCfg.AsList.Count == 0)
            CreateDefaultDBConfig(ifTableConnectionCfg, _clBaseDBConnData.StorageType);

        CclRecCfgDBConnection clConfig = ifTableConnectionCfg.AsList[0];

        return new CclContCDSConnectionData()
                   {
                       Database          = string.IsNullOrEmpty(clConfig.Database)   ? string.Empty : clConfig.Database,
                       DataSource        = string.IsNullOrEmpty(clConfig.DataSource) ? string.Empty : clConfig.DataSource,
                       UserID            = string.IsNullOrEmpty(clConfig.UserID)     ? string.Empty : clConfig.UserID,
                       Password          = string.IsNullOrEmpty(clConfig.Password)   ? string.Empty : clConfig.Password,
                       Port              =  clConfig.Port,
                       StorageType       =  clConfig.StorageType
                   };
    }

    ///**************************************************
    /// <summary>
    /// Creates a default db configuration of the given storage type for the given application.
    /// </summary>
    /// <param name="_clBaseDBConnData">The connection data for the base datasource.</param>
    /// <param name="_strApplicationID">The application id for the configuration to create.</param>
    /// <param name="_enType">The storage type of the configuration.</param>
    private void CreateDefaultDBConfig(ICDSDataList<CclRecCfgDBConnection> _ifDLConfigs, CDSStorageType _enType)
    {
        switch (_enType)
        {
            case CDSStorageType.MariaDB:
                CreateDefaultDBConfigMariaDB(_ifDLConfigs);
                break;
            case CDSStorageType.Oracle:
                CreateDefaultDBConfigOracle(_ifDLConfigs);
                break;
            default:
                throw new ArgumentOutOfRangeException($"Keine Standardkonfiguration für {_enType} gefunden.");
        }
    }

    ///**************************************************
    /// <summary>
    /// Creates a default db configuration for the given application.
    /// </summary>
    /// <param name="_clTableCfg">The datasource configuration table.</param>
    private void CreateDefaultDBConfigMariaDB(ICDSDataList<CclRecCfgDBConnection> _clTableCfg)
    {
        _clTableCfg.Add(new CclRecCfgDBConnection()
                            {
                                ApplikationID  = I_strApplicationID,
                                ConnectionName = "EEG",
                                UserID         = "root",
                                DataSource     = "127.0.0.1",
                                Database       = "eeg_intern",
                                Pooling        = true,
                                Port           = 3306,
                                MinPoolSize    = 0,
                                MaxPoolSize    = 0,
                                StorageType    = CDSStorageType.MariaDB,
                                Password       = "V1r!conium"
                            });
        _clTableCfg.SaveData();
    }

    ///**************************************************
    /// <summary>
    /// Creates a default db configuration for the given application.
    /// </summary>
    /// <param name="_clTableCfg">The datasource configuration table.</param>
    private void CreateDefaultDBConfigOracle(ICDSDataList<CclRecCfgDBConnection> _clTableCfg)
    {
        _clTableCfg.Add(new CclRecCfgDBConnection()
                            {
                                ApplikationID  = I_strApplicationID,
                                ConnectionName = "EEG",
                                UserID         = "student",
                                DataSource     = "STUDENT",
                                Database       = "STUDENTORACLE",
                                Pooling        = true,
                                Port           = 1521,
                                MinPoolSize    = 0,
                                MaxPoolSize    = 0,
                                StorageType    = CDSStorageType.Oracle,
                                Password       = "Informatikerchaos48"
                            });
        _clTableCfg.SaveData();
    }

    #endregion Private

    #endregion Methods
}
