using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

public class CompareShipByTime
{
    public CompareShipByTime(IShip ship1, IShip ship2, IList<IEnvironment> environments)
    {
        Ship1 = ship1;
        Ship2 = ship2;
        Route = new Route(environments);
        Result1 = Route.GoRoute(ship1);
        Result2 = Route.GoRoute(ship2);
    }

    private IShip Ship1 { get; }
    private IShip Ship2 { get; }
    private Route Route { get; }
    private Result Result1 { get; }
    private Result Result2 { get; }
    public IShip? CompareShipsByTime()
    {
        if (Result1 is not Result.RouteResult.RouteSuccess result1RouteSuccess)
        {
            if (Result2 is not Result.RouteResult.RouteSuccess)
            {
                return null;
            }

            return Ship2;
        }

        if (Result2 is not Result.RouteResult.RouteSuccess result2RouteSuccess)
        {
            return Ship1;
        }

        if (result1RouteSuccess.Time < result2RouteSuccess.Time)
        {
            return Ship1;
        }

        if (result1RouteSuccess.Time > result2RouteSuccess.Time)
        {
            return Ship2;
        }

        return null;
    }
}