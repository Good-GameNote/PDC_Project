using System;
using System.Collections.Generic;

interface IStat_Pirece
{
    public Stat Piercing { get; }
}

interface IStat_Splash
{
    public Stat Size { get; }
}

interface IStat_AddPjt
{
    public Stat AddPjtCount { get; }
}

interface IStat_Duration
{
    public Stat Duration { get; }
}
interface IStat_DebuffRate
{
    public Stat DebuffRate { get; }
}

