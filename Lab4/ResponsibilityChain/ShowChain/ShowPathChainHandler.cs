using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ShowChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ConnectChain;

public class ShowPathChainHandler : ShowArgumentsChainBase
{
    public override ParseArgumentResult Handle(Request request, FileShowModel.Builder builder)
    {
        builder.WithFilePath(request.Arguments.Current);
        var mFlag = new ShowModeChainHandler();
        ParseArgumentResult result = new ParseArgumentResult.ParseArgumentSuccess();

        while (request.Arguments.MoveNext())
        {
            result = mFlag.Handle(request, builder);
            if (result is ParseArgumentResult.ParseArgumentFail flagFail)
            {
                return new ParseArgumentResult.ParseArgumentFail(flagFail.Message);
            }
        }

        return result;
    }
}