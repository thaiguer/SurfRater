using SurfRater.Core.Model.Entities;

namespace SurfRater.Core.Model;

public class ConditionsUpdater
{
    public Beach Beach { get; private set; }

    public ConditionsUpdater(Beach beach)
    {
        Beach = beach;
    }

    public async Task UpdateConditions()
    {
        await Beach.UpdateSurfCondition();
    }
}