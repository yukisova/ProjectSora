public abstract class AController
{
    private bool isRun;
    private bool isInit;
    private bool isBeforeRunUpdate;
    private bool isAfterRunUpdate;
    public void GameUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }
        if (!isRun)
        {
            OnBeforeRunUpdate();
        }
        else
        {
            OnAfterRunUpdate();
        }
        AlwaysUpdate();
    }

    protected virtual void OnInit(){}
    
    protected virtual void OnBeforeRunStart(){}
    protected virtual void OnBeforeRunUpdate()
    {
        if (!isBeforeRunUpdate)
        {
            isBeforeRunUpdate = true;
            OnBeforeRunUpdate();
        }
    }
    protected virtual void OnAfterRunStart(){}
    protected virtual void OnAfterRunUpdate()
    {
        if (!isAfterRunUpdate)
        {
            isAfterRunUpdate = true;
            OnAfterRunUpdate();
        }
    }
    protected virtual void AlwaysUpdate(){}

    public void TurnOnController()
    {
        isRun = true;
    }
    public void TurnOffController()
    {
        isRun = false;
    }
}