using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Components.Tokens;

namespace Core;
internal static class EnumHelper
{
    public static IEnumerable<TokenType>GetCardTokenTypes()
    {
        foreach (TokenType tokenType in Enum.GetValues<TokenType>())
        {
            if (tokenType == TokenType.Gold) continue;
            yield return tokenType;
        }
    }
}
