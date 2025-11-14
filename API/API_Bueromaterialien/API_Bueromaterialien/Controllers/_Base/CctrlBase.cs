using Microsoft.AspNetCore.Mvc;
using API_Bueromaterialien._Base.Interfaces;
using SharedComponents.Components.EventLog.Classes.Services;
using SharedComponents.Components.EventLog.Interfaces;
using API_Bueromaterialien.Classes.Services;
using System.Runtime.CompilerServices;

namespace Test_WEB_API.Controllers._Base;

public abstract class CctrlBase : ControllerBase
{
    #region Instance variables
    ///**************************************************
    /// Instance variables
    protected ISvcDataStorage I_ifSvcDataStorage;
    protected CclSvcLogContext I_clSvcLogContext;

    #endregion Instance variables

    #region Properties
    ///**************************************************
    /// Properties
    protected abstract string LogContextName { get; }

    #endregion Properties

    #region Initialization
    ///**************************************************
    /// <summary>
    /// Extended constructor. Initializes an instance.
    /// </summary>
    /// <param name="_clConnectionData">The datastorage connection data.</param>
    /// <param name="_ifLogWorkflow">The log to use.</param>
    /// <param name="_ifConfig">The config to use.</param>
    /// <param name="_ifSvcAuthorizationKeys">The authorization keys for token validation.</param>
    /// <param name="_clSvcAOIKeycloak">Encapsulates the Keycloaak API.</param>
    public CctrlBase(IDSConnectionData _ifConnectionData, ISvcEventLog _ifLogWorkflow)
    {
        I_ifSvcDataStorage = new CclSvcDataStorage(_ifConnectionData.ConnData);
        I_clSvcLogContext = _ifLogWorkflow.SpawnNewContext(LogContextName);
    }

    #endregion Initialization


    protected ActionResult<T> CreateFunctionFrame<T>(Func<ActionResult<T>> _funcGetData, [CallerMemberName] string _strSource = "")
    {
        try
        {
            I_clSvcLogContext.LogStart(_strSource);
            return _funcGetData.Invoke();
        }
        catch (Exception excError)
        {
            I_clSvcLogContext.LogError(excError.Message);
            return StatusCode(500, excError.Message);
        }
        finally
        {
            I_clSvcLogContext.LogEnd(_strSource);
        }
    }


    internal T? CreateProcessingFrame<T>(Func<T?> _funcWork, [CallerMemberName] string _strCallingMethod = "")
    {
        T? tResult = default;

        try
        {
            I_clSvcLogContext.LogStart(_strCallingMethod);

            tResult = _funcWork();
        }
        catch (Exception excError)
        {
            I_clSvcLogContext.LogError(excError.Message);
        }
        finally
        {
            I_clSvcLogContext.LogEnd(_strCallingMethod);
        }

        return tResult;
    }
}
