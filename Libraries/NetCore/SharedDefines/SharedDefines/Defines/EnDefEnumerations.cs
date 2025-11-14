using System.ComponentModel;

namespace SharedDefines.Defines;

#region Enumerations

#region Common
///**************************************************
/// Common
public enum AgeCompare        {Younger, Equals, Older}
public enum DockPositions     {None, Top, Right, Bottom, Left, Fill}
public enum ExportTypes       {Mail, FTP}
public enum FontStyles        {Standard, Bold, Italic}
public enum PathExtenderTypes {CommodityFiletypeContractorDate, FileDate}
public enum PathFlags         {All, CurrentDateTime, FileDateTime, FileType, Edifact, ExtEdifact, Wildcard}
public enum RelativePositions {Center, Top, TopRight, Right, BottomRight, Bottom, BottomLeft, Left, TopLeft}
public enum Seasons           {Spring, Summer, Autumn, Winter}
public enum RunState          {Idle, Running, Paused}
public enum ProblemState      {Ok, Warning, Problem}
public enum TimeSpans         {Second, Minute, Hour, Day, Week, Month, Year}
public enum TextAlign         {Left, Right, Justify}
public enum ParamType         {Boolean, String, Integer, Float, Double, Decimal}
public enum ProcessResult     {Ok, Aborted}
public enum MouseEvents       {LeftButtonDown, LeftButtonUp, RightButtonDown, RightButtonUp}

public enum Timings
{
    [Description("Jede Minute")]       Minute,
    [Description("Alle fünf Minuten")] FiveMinutes,
    [Description("Alle zehn Minuten")] TenMinutes,
    [Description("Stundenanfang")]     StartOfHour,
    [Description("Stundenende")]       EndOfHour,
    [Description("Tagesanfang")]       StartOfDay,
    [Description("Tagesende")]         EndOfDay,
    [Description("Wochenanfang")]      StartOfWeek,
    [Description("Wochenende")]        EndOfWeek,
    [Description("Monatsanfang")]      StartOfMonth,
    [Description("Monatsende")]        EndOfMonth,
    [Description("Quartalsanfang")]    StartOfQuarter,
    [Description("Quartalsende")]      EndOfQuarter,
    [Description("Jahresanfang")]      StartOfYear,
    [Description("Jahresende")]        EndOfYear,
    [Description("Monatsmitte")]       CenterOfMonth
}

public enum PointsInTime
{
    [Description("Volle fünf Minuten")]  FiveMinutes,
    [Description("Volle zehn Minuten")]  TenMinutes,
    [Description("Volle Viertelstunde")] QuarterHour,
    [Description("Halbe Stunde")]        HalfHour,
    [Description("Volle Stunde")]        FullHour,
    [Description("Mittags")]             HighNoon,
    [Description("Mitternacht")]         Midnight,
    [Description("Wochenanfang")]        StartOfWeek,
    [Description("Monatsanfang")]        StartOfMonth,
    [Description("Monatsmitte")]         CenterOfMonth,
    [Description("Quartalsanfang")]      StartOfQuarter,
    [Description("Jahresanfang")]        StartOfYear
}

public enum YearQuarters
{
    [Description("Unbekannt")] Unknown,
    [Description("Quartal 1")] First,
    [Description("Quartal 2")] Second,
    [Description("Quartal 3")] Third,
    [Description("Quartal 4")] Fourth
}

public enum Days
{
    [Description("Unbekannt")]  Unknown,
    [Description("Montag")]     Monday,
    [Description("Dienstag")]   Tuesday,
    [Description("Mittwoch")]   Wednesday,
    [Description("Donnerstag")] Thursday,
    [Description("Freitag")]    Friday,
    [Description("Samstag")]    Saturday,
    [Description("Sontag")]     Sunday
}

public enum Months
{
    [Description("Unbekannt")] Unknown,
    [Description("Januar")]    January,
    [Description("Februar")]   February,
    [Description("März")]      March,
    [Description("April")]     April,
    [Description("Mai")]       May,
    [Description("Juni")]      June,
    [Description("Juli")]      July,
    [Description("August")]    August,
    [Description("September")] September,
    [Description("Oktober")]   October,
    [Description("November")]  November,
    [Description("Dezember")]  December
}

public enum UserState
{
    [Description("Leerer Eintrag")]      None,
    [Description("Urlaub")]              Vacation,
    [Description("Urlaub (halber Tag)")] VacationHalfDay,
    [Description("Urlaubsantrag")]       VacationRequest,
    [Description("Krank")]               Ill,
    [Description("Zeitausgleich")]       Compensation,
    [Description("Dienstfrei")]          OffDuty,
    [Description("Sonderurlaub")]        SpecialLeave,
    [Description("Geburtstag")]          Birthday
}

public enum FileTypes
{
    [Description(".csv")]             CSV,
    [Description(".xls;.xlsm;.xlsx")] Excel,
    [Description(".txt")]             PlainText,
    [Description(".*")]               All
}

public enum Commodities
{
    [Description("Strom")]     Power,
    [Description("Gas")]       Gas,
    [Description("HKN")]       HKN,
    [Description("Unbekannt")] Unknown
}

public enum MainPositions
{
    [Description("Links")]  Left,
    [Description("Rechts")] Right,
    [Description("Oben")]   Top,
    [Description("Unten")]  Bottom
}

#endregion Common

#region Contacts
///**************************************************
/// Contacts
public enum ContactType  {Unknown, Mail, Phone, PhoneOffice, PhoneMobile, Fax}
public enum AddressTypes {Unknown, Invoice, Office, Private}
public enum Gender       {Unknown, Female, Male, Other}

#endregion Contacts

#region EEGCockpit
///**************************************************
/// EEGCockpit
public enum InvoiceProcOptions   {SendMail, Print, Ignore}
public enum EEGSProjectType      {Process, Project}
public enum EEGSTaskType         {Common, Private}

public enum PMNodeTypes          {Process, Project, Structure, User}
public enum PMTaskTypes          {Common, Private}

public enum RGScriptElementTypes {Function, R, TeX}

public enum EEGCPluginTypes      {Executable, PDF, Directory, Image, Excel, Word, ExtApps}
public enum EEGCPluginGroup
{
    [Description("Programme")]         Executable,
    [Description("PDFs")]              PDF,
    [Description("Verzeichnis-Links")] Directory,
    [Description("Bilder")]            Image,
    [Description("Excel-Tabellen")]    Excel,
    [Description("Word-Dokumente")]    Word,
    [Description("Externe Programme")] ExtApps
}

#endregion EEGCockpit

#region EEGCommSvr
///**************************************************
/// EEGCommSvr
public enum ProcessTypes {Transfer, Converter, Maintenance, Monitor, Import, Generator}
public enum SubTypes
{
    Filesystem2Filesystem, FTP2Filesystem, HTTP2Filesystem, Filesystem2Mail, Mail2Filesystem, Excel2CSV, Filesystem2Archive, Archive2Filesystem, FileDelete, CSV2CSV, Filesystem2FTP,
    Monitor, XLS2CSV, CSV2Edifact, ProcessNames, CompareData, DBImport, Excel2DB, Reports
}
public enum EEGCSSyncMode { Sync, AsyncRunOncePerCycle, AsyncRunContinuous };

#endregion EEGCommSvr

#region EEGMonitor
///**************************************************
/// EEGMonitor
public enum LogScanMode { CurrentState, DeepScan }

#endregion EEGMonitor

#region Invoices
///**************************************************
/// Invoices
public enum InvoiceTypes
{
    [Description("Ausgleichsenergie Strom")]          AusgleichsenergieStrom,
    [Description("Ausgleichsenergie Strom FL")]       AusgleichsenergieStromFL,
    [Description("Ausgleichsenergie Strom Vertrieb")] AusgleichsenergieStromVertrieb,
    [Description("Spot Gas")]                         SpotGas,
    [Description("Spot Strom Vertrieb DBA")]          SpotStromVertriebDBA,
    [Description("Spot Strom Netz DBA")]              SpotStromNetzDBA,
    [Description("Spot Strom Vertrieb")]              SpotStromVertrieb,
    [Description("Spot Strom Netz")]                  SpotStromNetz,
    [Description("Termin Gas")]                       TerminGas,
    [Description("Termin Strom")]                     TerminStrom,
    [Description("Ausgleichsenergie Gas")]            AusgleichsenergieGas,
    [Description("VHP Entgelte")]                     VHPEntgelte,
    [Description("BHKW Spot Strom")]                  BHKWSpotStrom
}

public enum InvoiceTransactionTypes
{
    [Description("Unbekannt")] Unknown,
    [Description("Ankauf")]    Purchase,
    [Description("Verkauf")]   Sale
}

public enum DispatchType { Ignore, Print, Mail }

#endregion Invoices

#region Company Structure
///**************************************************
/// Company Structure
public enum CSTREmployeeFlagTypes
{
    [Description("Team")]      Team,
    [Description("Projekt")]   Project,
    [Description("Sonstiges")] Other
}

#endregion Company Structure

#region EventLog
///**************************************************
/// EventLog
public enum EventType {Error, Warning, Info}

#endregion EventLog

#region Windows services
///**************************************************
/// Windows services
public enum ServiceState
{
    SERVICE_STOPPED          = 0x00000001,
    SERVICE_START_PENDING    = 0x00000002,
    SERVICE_STOP_PENDING     = 0x00000003,
    SERVICE_RUNNING          = 0x00000004,
    SERVICE_CONTINUE_PENDING = 0x00000005,
    SERVICE_PAUSE_PENDING    = 0x00000006,
    SERVICE_PAUSED           = 0x00000007
}

#endregion Windows services

#region Databases
///**************************************************
/// Databases
public enum EEGStdDatabases {ECR4P, ECR4PGas, ESR4P, ESR4PGas, ECR4T, ECR4TGas, ESR4T, ESR4TGas}

#endregion Databases

#region DataPackageHandler
///**************************************************
/// DataPackageHandler
public enum PackageOperations {Create, Copy, Move, Rename, Delete, Save}
public enum PackageTypes      {PlainText, CSV, Excel, DBTable, Mail}

#endregion DataPackageHandler

#region BPM
///**************************************************
/// BPM
public enum TaskCategories   {Structure, Trigger, Collector, Dispatcher, Filter, Processor};
public enum TaskTypes        {Collector, Splitter, Synchroniser, Filter, Dispatcher, Processor, Trigger, Origin, Terminator};
public enum TaskStates       {Idle, Running};
public enum PortOrientations {Top, Right, Bottom, Left}

#endregion BPM

#endregion Enumerations
