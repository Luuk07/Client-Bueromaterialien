using System.Net.Mime;

namespace SharedDefines.Defines;

public static class CstDefConstants
{
    #region Constants

    #region Common
    ///**************************************************
    /// Common
    public static readonly DateTime DT_SPRING_START = new DateTime(1900,  3, 20);
    public static readonly DateTime DT_SUMMER_START = new DateTime(1900,  6, 21);
    public static readonly DateTime DT_AUTUMN_START = new DateTime(1900,  9, 23);
    public static readonly DateTime DT_WINTER_START = new DateTime(1900, 12, 21);

    public static readonly DateTime DT_MINVALUE     = new DateTime(1900,  1,  1);

    public const string PATH_TEX_DEFAULT            = @"\\eegsrv094\EEGCPTools\TeX\miktex\bin\x64\miktex-pdftex.exe";
    public const string PATH_R_DEFAULT              = @"\\eegsrv094\EEGCPTools\R\R-4.0.2\bin\Rscript.exe";

    public const int    ID_COUNTRY_GERMANY          =  1;
    public const int    ID_COUNTRY_DENMARK          = 21;
    public const int    ID_COUNTRY_ITALY            = 22;
    public const int    ID_COUNTRY_GREATBRITAIN     = 23;

    #endregion Common

    #region Windows
    ///**************************************************
    /// Windows

    #region Registry
    ///**************************************************
    /// Registry
    public const string REGISTRY_PATH_EEG_BASE                = @"Software\EEG";
    public const string REGISTRY_PATH_EEG_CONFIG              = REGISTRY_PATH_EEG_BASE + @"\Config";
    public const string REGISTRY_PATH_EEG_CONFIG_APPLICATIONS = REGISTRY_PATH_EEG_CONFIG + @"\Applications";
    public const string REGISTRY_PATH_EEG_CONFIG_SERVICES     = REGISTRY_PATH_EEG_CONFIG + @"\Services";

    #endregion Registry

    #region Logon
    ///**************************************************
    /// Logon
    public const int LOGON32_PROVIDER_DEFAULT  = 0;
    public const int LOGON32_LOGON_INTERACTIVE = 2;

    #endregion Logon

    #region Messages
    ///**************************************************
    /// Messages
    public const int  WM_NCLBUTTONDOWN =   0xA1;
    public const uint WM_LBUTTONUP     = 0x0202;
    public const uint WM_MOUSEWHEEL    = 0x020A;

    public const uint WM_HSCROLL       =  0x114;
    public const uint WM_VSCROLL       =  0x115;

    public const uint WM_KEYDOWN       = 0x0100;

    public const int  WM_SETREDRAW     =     11;

    public const int  HT_CAPTION       =    0x2;

    #endregion Messages

    #region Method parameters
    ///**************************************************
    /// Method parameters
    public const int SWP_ASYNCWINDOWPOS = 0x4000;
    public const int SWP_DEFERERASE     = 0x2000;
    public const int SWP_DRAWFRAME      = 0x0020;
    public const int SWP_FRAMECHANGED   = 0x0020;
    public const int SWP_HIDEWINDOW     = 0x0080;
    public const int SWP_NOACTIVATE     = 0x0010;
    public const int SWP_NOCOPYBITS     = 0x0100;
    public const int SWP_NOMOVE         = 0x0002;
    public const int SWP_NOOWNERZORDER  = 0x0200;
    public const int SWP_NOREDRAW       = 0x0008;
    public const int SWP_NOREPOSITION   = 0x0200;
    public const int SWP_NOSENDCHANGING = 0x0400;
    public const int SWP_NOSIZE         = 0x0001;
    public const int SWP_NOZORDER       = 0x0004;
    public const int SWP_SHOWWINDOW     = 0x0040;

    #endregion Method parameters

    #region Media
    ///**************************************************
    /// Media
    public const string MEDIA_TYPE_PNG = "image/png";
    public const string MEDIA_TYPE_JPG = MediaTypeNames.Image.Jpeg;

    #endregion Media

    #endregion Windows

    #region EEG
    ///**************************************************
    /// EEG
    public const string EEG_DOMAIN_GAS_AP_1 = "Gas AP1";
    public const string EEG_DOMAIN_GAS_AP_2 = "Gas AP2";
    public const string EEG_DOMAIN_GAS_AP_3 = "Gas AP3";
    public const string EEG_DOMAIN_GAS_AP_4 = "Gas AP4";

    public const string EEG_NODATA_GUID     = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX";
    public const int    EEG_NODATA_INT      = -1;

    #endregion EEG

    #region Importer
    ///**************************************************
    /// EEG-Importer
    public const string EEGIMP_FLAG_PRODUKT_FULL_HOUR    = "Spot_h";
    public const string EEGIMP_FLAG_PRODUKT_QUARTER_HOUR = "Spot_q";

    #endregion Importer

    #region Pathflags
    ///**************************************************
    /// Pathflags
    public const string PATH_FLAG_CONTRACTOR_ALIAS = "<CA>";
    public const string PATH_FLAG_CURRENT_DATETIME = "<CURRDATETIME>";
    public const string PATH_FLAG_CURRENT_DATE     = "<CURRDATE>";
    public const string PATH_FLAG_CURRENT_TIME     = "<CURRTIME>";
    public const string PATH_FLAG_CURRENT_YEAR     = "<CURRYEAR>";
    public const string PATH_FLAG_CURRENT_MONTH    = "<CURRMONTH>";
    public const string PATH_FLAG_CURRENT_DAY      = "<CURRDAY>";
    public const string PATH_FLAG_CURRENT_HOUR     = "<CURRHOUR>";
    public const string PATH_FLAG_CURRENT_MINUTE   = "<CURRMINUTE>";
    public const string PATH_FLAG_CURRENT_SECOND   = "<CURRSECOND>";
    public const string PATH_FLAG_LAST_YEAR        = "<LASTYEAR>";
    public const string PATH_FLAG_LAST_MONTH       = "<LASTMONTH>";
    public const string PATH_FLAG_FILE_DATETIME    = "<FILEDATETIME>";
    public const string PATH_FLAG_FILE_DATE        = "<FILEDATE>";
    public const string PATH_FLAG_FILE_TIME        = "<FILETIME>";
    public const string PATH_FLAG_FILE_YEAR        = "<FILEYEAR>";
    public const string PATH_FLAG_FILE_MONTH       = "<FILEMONTH>";
    public const string PATH_FLAG_FILE_DAY         = "<FILEDAY>";
    public const string PATH_FLAG_FILE_HOUR        = "<FILEHOUR>";
    public const string PATH_FLAG_FILE_MINUTE      = "<FILEMINUTE>";
    public const string PATH_FLAG_FILE_SECOND      = "<FILESECOND>";
    public const string PATH_FLAG_EDI_RECEIVER     = "<EDIRECEIVER>";
    public const string PATH_FLAG_EDI_SENDER       = "<EDISENDER>";
    public const string PATH_FLAG_EDI_RECEIVER2SN  = "<EDIR2SN>";
    public const string PATH_FLAG_EDI_SENDER2SN    = "<EDIS2SN>";
    public const string PATH_FLAG_EDIFACT          = "<EDIFACT>";
    public const string PATH_FLAG_CSV              = "<CSV>";
    public const string PATH_FLAG_WILDCARD         = "<?>";

    #endregion Pathflags

    #region EEGMonitor
    ///**************************************************
    /// EEGMonitor
    public const string EEGMON_FLAG_ERRORLOG = "_Error_";

    #endregion EEGMonitor

    #region Contacts
    ///**************************************************
    /// Contacts
    public const string EEGCONT_FLAG_MAIN     = "MAIN";
    public const string EEGCONT_FLAG_INVOICE  = "INV";
    public const string EEGCONT_FLAG_VACATION = "VAC";

    #endregion Contacts

    #endregion Constants
}