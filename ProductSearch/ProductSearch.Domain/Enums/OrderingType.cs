using System.ComponentModel;

namespace ProductSearch.Domain.Enums;

public enum OrderingType
{
    [Description("HighestPrice")]
    HighestPrice = 1,

    [Description("LowestPrice")]
    LowestPrice,

    [Description("NewAZ")]
    NewestAtoZ,

    [Description("NewZA")]
    NewestZtoA
}